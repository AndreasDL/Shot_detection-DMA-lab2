using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This method uses a logaritmic motion search to detect shots
/// </summary>
class LogMotionMethod: aShotDetectionMethod {
    private byte[] current;   //current frame
    private byte[] previous;  //previous frame
    private int subsize;      //size of a subblock
    private int windowSize;   //size of the search window in SUBBLOCKS

    private int lastShot;     //frame number of the last detected shot
    private int threshold;    //used threshold
    private double fraction;  //used fraction
    private int speedup;


    /// <summary>
    /// This method uses a logaritmic motion estimation to detect shots, 
    /// it tries to avoid parameters by keeping track of the average differences and when the difference > X* average then a shot is detected.
    /// This method is simple, yet produces good results.
    /// </summary>
    /// <param name="subsize">the width/height of a subblock</param>
    /// <param name="windowSize">the size of the search window</param>
    /// <param name="shots">the collection to store the shots in</param>
    /// <param name="fraction">fraction of blocks above the threshold</param>
    /// <param name="threshold">the threshold to generate a hit</param>
    public LogMotionMethod(int subsize, int windowSize, ShotCollection shots, double fraction, int threshold, int speedup)
        : base(shots) {
        this.subsize = subsize;
        this.windowSize = windowSize;
        this.current = null;
        this.previous = null;
        this.fraction = fraction;
        this.threshold = threshold;
        this.speedup = speedup;
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");

        //move through
        previous = current;

        //new frame
        current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        bool isShot = false;
        int TooFarCount = 0;

        if (previous != null) { //if there is a previous block to compare
            for (int y = 0; y < videoHeight; y += speedup * subsize) {
                for (int x = 0; x < videoWidth; x += speedup * subsize) {

                    //init                   
                    int offset = windowSize / 4; //reset the offset
                    //start with center block, because it always exists, no checks required for init
                    int[] offsetX = { 0, -offset, 0, offset, -offset, offset, -offset, 0, offset };
                    int[] offsetY = { 0, -offset, -offset, -offset, 0, 0, offset, offset, offset };

                    int searchX = x, searchY = y; //first offset == 0
                    int bestoffset = 0;
                    long bestDifference = 0; //best found match has bestDifference difference :)

                    //find best match using log search
                    while (offset > 1) {

                        //find best difference
                        bestoffset = 0; //index 0 is chosen as start index
                        bestDifference = getDifference(x, y, searchX, searchY);

                        //loop
                        int i = 1;
                        while (i < 9 && bestDifference != 0) { //stop if difference is zero, speedup :D
                            int tempX = searchX + offsetX[i]; //new candidate
                            int tempY = searchY + offsetY[i];

                            //if the candidate is within the frame
                            if (tempX > 0 && tempX < videoWidth - windowSize && tempY > 0 && tempY < videoHeight - windowSize) {
                                //new diff
                                long diff = getDifference(x, y, tempX, tempY);

                                //better?
                                if (diff < bestDifference) {
                                    bestDifference = diff;
                                    bestoffset = i;
                                }
                            }

                            //next
                            i++;
                        }

                        //new x &y
                        searchX += offsetX[bestoffset];
                        searchY += offsetY[bestoffset];

                        //new offset
                        offset /= 2;
                        offsetX = new int[] { 0, -offset, 0, offset, -offset, offset, -offset, 0, offset };
                        offsetY = new int[] { 0, -offset, -offset, -offset, 0, 0, offset, offset, offset };
                    }

                    if ((bestDifference * speedup) / (1.0 * subsize * subsize) > threshold) {
                        TooFarCount += 3;//divide by mstride, which is 3*the pixels count, avoid multiplication
                    }
                }
            }

            if ((speedup * TooFarCount) / m_stride > fraction && frameNumber > lastShot + 10) {
                isShot = true;
                lastShot = frameNumber;
            }

            return isShot;
        } else {
            lastShot = 0;
            return true;
        }
    }


    /// <summary>
    /// returns the absolute difference between two subblocks
    /// </summary>
    /// <param name="startX">upper left x coordinate of the first block </param>
    /// <param name="startY">upper left y coordinate of the first block</param>
    /// <param name="searchX">upper left x coordinate of the second block</param>
    /// <param name="searchY">upper left y coordinate of the second block</param>
    /// <returns>the sommation of differences between all pixel values</returns>
    private long getDifference(int startX, int startY, int searchX, int searchY) {
        long diff = 0;
        for (int y = startY; y < startY + subsize; y++) {
            for (int x = startX; x < startX + subsize; x++) {
                diff += getAbsDifferencePixel(getPixel(searchX, searchY, current), getPixel(startX, startY, previous));
            }
        }
        return diff;
    }


    /// <summary>
    /// Returns the difference of each pixel component between two pixels, this is used to determine the closest match between subblocks
    /// </summary>
    /// <param name="old">the average of the subblock in the previous frame</param>
    /// <param name="curr">the average of the subblock in the current frame</param>
    /// <returns>the difference of each pixel component between two pixels, this is used to determine the closest match between subblocks</returns>
    private long getAbsDifferencePixel(byte[] old, byte[] curr) {
        return Math.Abs(curr[0] - old[0]) + Math.Abs(curr[1] - old[1]) + Math.Abs(curr[2] - old[2]);
    }

}
