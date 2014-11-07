using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DirectShowLib;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class MotionMethod : aShotDetectionMethod{
    private byte[] current; //current frame

    private int subsize;    //size of a subblock
    private int windowSize; //size of the search window in SUBBLOCKS
    private int frameNumber;//frame number
    private byte[,][] currWindow; //current avg values
    private byte[,][] prevWindow; //previous avg values
    int prevMotion; //total motion of the previous frame
    int currMotion; //total motion of the current frame
    int avgMotion;

    //debug
    int bulletsfired = 0;//debug
    int[] debugshots = { 60, 111, 185, 235, 295, 354, 447, 497, 554, 616, 678, 785, 867, 945, 1002, 1052, 1128, 1151, 1342, 1364, 1402, 1456, 1507, 1537, 1552, 1570, 1620, 1662, 1737, 1771, 1845, 1884, 1935, 1972, 2009 };    
    
    public MotionMethod(int _subsize, int _windowSize,ShotCollection shots):base(shots) {
        this.subsize = _subsize;
        this.windowSize = _windowSize;
        this.frameNumber = 0;
        this.current = null;
        this.currWindow = null;
        this.prevWindow = null;
        this.prevMotion = 0;
        this.avgMotion = 0;
    }
    public unsafe override int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen){
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");

        current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        prevWindow = currWindow;//keep the avgs that have been calculated before
        currWindow = new byte[videoHeight/subsize,videoWidth/subsize][]; //hold the average pixel values for each subblock

        prevMotion = currMotion;
        currMotion = 0;

        //calculate avg for all subblocks in current frame
        int blockX = 0, blockY = 0; //indexes of the subblock (assume that a ++ operation is faster than multiplication)
        for (int y = 0; y < videoHeight; y+= subsize ){
            blockX = 0;
            for (int x = 0; x < videoWidth; x += subsize) {
                currWindow[blockY, blockX] = getAvg(x, y, current); ;
                blockX++;
            }
            blockY++;
        }


        //skip first frame
        if (prevWindow != null) {

            //Estimate motion for each subblock
            int videoWidthBlocks = videoWidth / subsize; //videowidth in SUBBLOCKS
            int videoHeightBlocks = videoHeight / subsize; //videoheight in SUBBLOCKS
            int blockCount = videoHeightBlocks * videoWidthBlocks; // amount of blocks in a frame, used to calculate average
            int motionX = 0, motionY = 0; //motionVectors

            for (int y = 0; y < videoHeightBlocks; y++) {
                for (int x = 0; x < videoWidthBlocks; x++) {

                    //calculate the average of the subblock (from previous frame)
                    byte[] avgToFind = prevWindow[y, x];

                    //determine the start and stop position of the window in SUBBLOCKS
                    int startX = x - windowSize < 0 ? 0 : x - windowSize;
                    int startY = y - windowSize < 0 ? 0 : y - windowSize;
                    int stopX = x + windowSize > videoWidthBlocks ? videoWidthBlocks : x + windowSize;
                    int stopY = y + windowSize > videoHeightBlocks ? videoHeightBlocks : y + windowSize;

                    //keep track of the best match in SUBBLOCKS
                    int best_X = startX;
                    int best_Y = startY;
                    int bestDifference = getDifference(avgToFind, currWindow[best_Y, best_X]);

                    //get the best match
                    for (int wy = startY; wy < stopY; wy++) {
                        for (int wx = startX; wx < stopX; wx++) {

                            int candidateDifference = getDifference(avgToFind, currWindow[wy, wx]);
                            if (bestDifference > candidateDifference) {
                                best_X = wx;
                                best_Y = wy;
                                bestDifference = candidateDifference;
                            }
                        }
                    }

                    //getMotion vector
                    motionX += Math.Abs(best_X - x);
                    motionY += Math.Abs(best_Y - y);//abs to avoid that positive and negative movements cancel eachother out
                }
            }
            currMotion = motionX + motionY;
            int difference = Math.Abs(currMotion - prevMotion);

            if (difference > 5*avgMotion) {
                shotDetected(SampleTime, frameNumber);
                Console.WriteLine("frame " + frameNumber + " total: " + currMotion + " DIFF: " + Math.Abs(currMotion - prevMotion) + " AVG: " + avgMotion);
                avgMotion = difference; //assume that motion is somewhat consistent for the duration of a shot
            }

            //debug
            if (frameNumber == debugshots[bulletsfired]) {
                bulletsfired++;
                Console.WriteLine("frame " + frameNumber + " total: " + currMotion + " DIFF: " + Math.Abs(currMotion - prevMotion) + " AVG: " + avgMotion + " should be a shot");
            }

            avgMotion = (int)(avgMotion * 0.9 + difference * 0.1);
        }

        frameNumber++;
        return 0;
    }

    /* 
     * Returns the 3 values of a pixel at position x,y
     * x = the x position in PIXELS
     * y = the y position in PIXELS
     * frame => the frame
    */
    private byte[] getPixel(int x, int y, byte[] frame) {
        int position = y * m_stride + 3 * x;
        byte[] pixel = { frame[position], frame[position+ 1], frame[position + 2] };
        
        return pixel;
    }
    /*
     * Return the average pixel values of a subblock starting at position _x ; _y
     * _x = the x position in PIXELS
     * _y = the y position in PIXELS
     * frame: the frame
     * subsize = the subsize, the size of the subblock
    */ 
    private byte[] getAvg(int _x, int _y, byte[] frame) {
        uint[] pixel = {0,0,0};
        uint pixelCount = 0;

        for (int y = _y; y < _y + subsize; y++){
            for (int x = _x; x < _x + subsize; x++) {
                byte[] currPixel = getPixel(x, y, frame);
                pixel[0] += currPixel[0];
                pixel[1] += currPixel[1];
                pixel[2] += currPixel[2];

                pixelCount++;
            }
        }
        pixel[0] /= pixelCount;
        pixel[1] /= pixelCount;
        pixel[2] /= pixelCount;

        byte[] pixelAsByte = { (byte)pixel[0], (byte)pixel[1], (byte)pixel[2] };
        return pixelAsByte;
    }
    /*
     * Returns the difference of each pixel component between two pixels, this is used to determine the closest match between subblocks
     * old = the average of the subblock in the previous frame
     * curr = the average of the subblock in the current frame
    */
    private int getDifference(byte[] old, byte[] curr){
        return Math.Abs(curr[0] - old[0]) + Math.Abs(curr[1] - old[1]) + Math.Abs(curr[2] - old[2]);
    }
}
