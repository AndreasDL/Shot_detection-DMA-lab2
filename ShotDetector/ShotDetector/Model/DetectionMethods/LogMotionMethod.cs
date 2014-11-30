using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DirectShowLib;
using System.Diagnostics;
using System.Runtime.InteropServices;
/// <summary>
/// This method uses motion estimation to detect shots
/// </summary>
public class LogMotionMethod: aShotDetectionMethod {
    private byte[] current; //current frame
    private byte[] previous;
    private int subsize;    //size of a subblock
    private int windowSize; //size of the search window in SUBBLOCKS
    private long avgDiff;
    private int lastShot;
    private byte[,][] currWindow; //current avg values
    private byte[,][] prevWindow; //previous avg values

    public LogMotionMethod(int _subsize, int _windowSize, ShotCollection shots)
        : base(shots) {
        this.subsize = _subsize;
        this.windowSize = _windowSize * _subsize; //save the window size in pixels
        this.current = null;
        this.previous = null;
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        //move through
        previous = current;
        prevWindow = currWindow;

        //new frame
        current = new byte[(videoHeight * videoWidth) * 3];
        currWindow = new byte[videoHeight / subsize, videoWidth / subsize][]; //hold the average pixel values for each subblock
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        return _DetectShot();
    }

    private bool _DetectShot() {
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");
        bool isShot = false;

        //calculate avg for all subblocks in current frame
        int blockX = 0, blockY = 0; //indexes of the subblock (assume that a ++ operation is faster than multiplication)
        for (int y = 0; y < videoHeight; y += subsize) {
            blockX = 0;
            for (int x = 0; x < videoWidth; x += subsize) {
                currWindow[blockY, blockX] = getAvg(x, y, current); ;
                blockX++;
            }
            blockY++;
        }


        if (previous != null) {
            //init
            int offset = windowSize / 4;
            int[] offsetX = { 0, -offset, 0, offset, -offset, offset, -offset, 0, offset }; //start with center block, because it always exists, no checks required for init
            int[] offsetY = { 0, -offset, -offset, -offset, 0, 0, offset, offset, offset };
            long currDiff = 0;
            
            for (int y = 0; y < videoHeight; y += subsize) {
                for (int x = 0; x < videoWidth; x += subsize) {
                    //init
                    int searchX = x, searchY = y;
                    int bestoffset = 0;
                    long bestDifference = 0;

                    //find best match using log search
                    while (offset > 1) {

                        //find best difference
                        //init
                        bestoffset = 0;
                        bestDifference = getAbsDifferencePixel(currWindow[y,x], prevWindow[y + offsetY[0] , x + offsetX[0]]);
                        
                        //loop
                        int i = 1;
                        while (i < 9 && bestDifference != 0) { //stop if difference is zero
                            int tempX = searchX + offsetX[i];
                            int tempY = searchY + offsetY[i];

                            if (tempX > 0 && tempX < videoWidth -windowSize && tempY > 0 && tempY < videoHeight - windowSize) {
                                //new diff
                                long diff = getAbsDifferencePixel(currWindow[y,x], prevWindow[tempY , tempX]);

                                //better?
                                if (diff < bestDifference) {
                                    bestDifference = diff;
                                    bestoffset = i;
                                }
                            }
                            i++;
                        }

                        //new x &y
                        searchX += offsetX[bestoffset];
                        searchY += offsetY[bestoffset];

                        //new offset
                        offset /= 2;
                        offsetX = new int[] {0, -offset, 0, offset, -offset, offset, -offset, 0, offset };
                        offsetY = new int[] {0, -offset, -offset, -offset, 0, 0, offset, offset, offset };
                    }

                    currDiff += getDifference(x, y, searchX, searchY);
                    //bestDifference * subsize;
                }
            }


            if (currDiff > 5 * avgDiff && frameNumber > lastShot + 10) {
                isShot = true;
                lastShot = frameNumber;
                avgDiff = currDiff;
            }

            avgDiff = (int) ((avgDiff * 9 + currDiff ) / 10);


            return isShot;
        } else {
            lastShot = 0;
            return true;
        }
    }


    /* 
     * Returns the 3 values of a pixel at position x,y
     * x = the x position in PIXELS
     * y = the y position in PIXELS
     * frame => the frame
    */
    private byte[] getPixel(int x, int y, byte[] frame) {
        int position = y * m_stride + 3 * x;
        byte[] pixel = { frame[position], frame[position + 1], frame[position + 2] };

        return pixel;
    }

    private long getDifference(int startX, int startY, int searchX, int searchY) {
        long diff = 0;
        for (int y = startY ; y < startY+subsize ; y++){
            for (int x = startX; x < startX + subsize; x++) {
                diff+= getAbsDifferencePixel(getPixel(searchX,searchY,current),getPixel(startX,startY,previous));
            }
        }

        return diff;
    }


    /*
 * Returns the difference of each pixel component between two pixels, this is used to determine the closest match between subblocks
 * old = the average of the subblock in the previous frame
 * curr = the average of the subblock in the current frame
*/
    private long getAbsDifferencePixel(byte[] old, byte[] curr) {
        return Math.Abs(curr[0] - old[0]) + Math.Abs(curr[1] - old[1]) + Math.Abs(curr[2] - old[2]);
    }

    /*
 * Return the average pixel values of a subblock starting at position _x ; _y
 * _x = the x position in PIXELS
 * _y = the y position in PIXELS
 * frame: the frame
 * subsize = the subsize, the size of the subblock
*/
    private byte[] getAvg(int _x, int _y, byte[] frame) {
        uint[] pixel = { 0, 0, 0 };
        uint pixelCount = 0;

        for (int y = _y; y < _y + subsize; y++) {
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

}
