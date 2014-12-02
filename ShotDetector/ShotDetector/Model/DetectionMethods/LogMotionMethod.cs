using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class LogMotionMethod : aShotDetectionMethod {
    private byte[] current; //current frame
    private byte[] previous;
    private int subsize;    //size of a subblock
    private int windowSize; //size of the search window in SUBBLOCKS

    private int lastShot;
    private int threshold;
    private double fraction;

    public LogMotionMethod(int _subsize, int _windowSize, ShotCollection shots, double fraction, int threshold)
        : base(shots) {
        this.subsize = _subsize;
        this.windowSize = _windowSize; //save the window size in pixels
        this.current = null;
        this.previous = null;
        this.fraction = fraction;
        this.threshold = threshold;
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");

        //move through
        previous = current;

        //new frame
        current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        return _DetectShot();
    }

    private bool _DetectShot() {
        bool isShot = false;
        int TooFarCount = 0;

        if (previous != null) {
            //init
            int offset = windowSize / 4;
            int[] offsetX = { 0, -offset, 0, offset, -offset, offset, -offset, 0, offset }; //start with center block, because it always exists, no checks required for init
            int[] offsetY = { 0, -offset, -offset, -offset, 0, 0, offset, offset, offset };
            
            for (int y = 0; y < videoHeight; y += subsize) {
                for (int x = 0; x < videoWidth; x += subsize) {
                    //init
                    int searchX = x, searchY = y;
                    int bestoffset = 0;
                    long bestDifference = 0;
                    offset = windowSize / 4;

                    //find best match using log search
                    while (offset > 1) {

                        //find best difference
                        //init
                        bestoffset = 0;
                        bestDifference = getDifference(x,y,searchX,searchY);

                        //loop
                        int i = 1;
                        while (i < 9 && bestDifference != 0) { //stop if difference is zero
                            int tempX = searchX + offsetX[i];
                            int tempY = searchY + offsetY[i];

                            if (tempX > 0 && tempX < videoWidth - windowSize && tempY > 0 && tempY < videoHeight - windowSize) {
                                
                                //new diff
                                long diff = getDifference(x,y,tempX,tempY);

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

                    if ( (bestDifference *1.0) / (1.0*subsize*subsize)  > threshold) {
                        TooFarCount+=3;//divide by mstride, which is 3*the pixels count, avoid multiplication
                    }
                }
            }

            if (TooFarCount / m_stride > fraction && frameNumber > lastShot + 10) {
                isShot = true;
                lastShot = frameNumber;
            }

            return isShot;
        } else {
            lastShot = 0;
            return true;
        }
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
        return Math.Abs( (int)curr[0] - (int)old[0]) + Math.Abs( (int)curr[1] - (int)old[1]) + Math.Abs((int)curr[2] - (int)old[2]);
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
