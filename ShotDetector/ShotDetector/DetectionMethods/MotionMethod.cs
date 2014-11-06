using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DirectShowLib;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class MotionMethod : aShotDetectionMethod{

    private byte[] current;
    private byte[] previous;

    private int subsize;    //size of a subblock
    private int windowSize; //size of the search window in SUBBLOCKS
    private int frameNumber;

    public MotionMethod(int _subsize, int _windowSize):base() {
        this.subsize = _subsize;
        this.windowSize = _windowSize;
        this.frameNumber = 0;
        this.current = null;
        this.previous = null;
    }


    public unsafe override int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen){
        previous = current;
        current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, current.Length < BufferLen ? current.Length : BufferLen);

        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");

        //skip first frame
        if (previous == null)
            return 0;
        
        //calculate avg for all subblocks in current frame
        //TODO multithreaded
        byte[,][] window = new byte[videoHeight/subsize,videoWidth/subsize][]; //hold the average pixel values for each subblock
        int blockX = 0, blockY = 0; //indexes of the subblock (assume that a ++ operation is faster than multiplication)

        for (int y = 0; y < videoHeight; y+= subsize ){
            blockX = 0;
            for (int x = 0; x < videoWidth; x += subsize) {
                window[blockY, blockX] = getAvg(x, y, current); ;
                blockX++;
            }
            blockY++;
        }

        //Estimate motion for each subblock
        int videoWidthBlocks = videoWidth / subsize; //videowidth in SUBBLOCKS
        int videoHeightBlocks = videoHeight /subsize; //videoheight in SUBBLOCKS

        for (int y = 0; y < videoHeightBlocks; y++ ) {
            for (int x = 0; x < videoWidthBlocks; x++) {

                //calculate the average of the subblock (from previous frame)
                byte[] avgToFind = getAvg(x, y, previous);

                //determine the start and stop position of the window in SUBBLOCKS
                int startX = x - windowSize < 0 ? 0 : x - windowSize;
                int startY = y - windowSize < 0 ? 0 : y - windowSize;
                int stopX  = x + windowSize > videoWidthBlocks  ? videoWidthBlocks  : x + windowSize;
                int stopY  = y + windowSize > videoHeightBlocks ? videoHeightBlocks : y + windowSize;

                //keep track of the best match in SUBBLOCKS
                int best_X = startX;
                int best_Y = startY;
                int bestDifference = getDifference(avgToFind, window[best_Y, best_X] );

                //get the best match
                for (int wy = startY; wy < stopY; wy++) {
                    for (int wx = startX; wx < stopX; wx++) {

                        int candidateDifference = getDifference(avgToFind, window[wy,wx]);
                        if (bestDifference > candidateDifference){
                            best_X = wx;
                            best_Y = wy;
                            bestDifference = candidateDifference;
                        }
                    }
                }

                //Console.WriteLine("Motion vector found for block " + x + ";" + y);
            }
        }

        //motion too big => movement

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
