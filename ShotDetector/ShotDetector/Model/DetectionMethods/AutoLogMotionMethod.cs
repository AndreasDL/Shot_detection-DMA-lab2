using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DirectShowLib;
using System.Diagnostics;
using System.Runtime.InteropServices;
/// <summary>
/// This method uses a logaritmic motion estimation to detect shots, 
/// it tries to avoid parameters by keeping track of the average differences and when the difference > X* average then a shot is detected.
/// This method is simple, yet produces good results.
/// </summary>
public class AutoLogMotionMethod: aShotDetectionMethod {
    private byte[] current;  //current frame
    private byte[] previous; //previous frame
    private int subsize;     //size of a subblock
    private int windowSize;  //size of the search window in SUBBLOCKS
    private long avgDiff;    //keeps track of average difference in the frame
    private int lastShot;    //frame number of last detected shot
    private int speedup;     //speedup param, if speedup = 2 then the for loop will skip one subblock. higher speedup means that fewer blocks are checked

    /// <summary>
    /// This method uses a logaritmic motion estimation to detect shots, 
    /// it tries to avoid parameters by keeping track of the average differences and when the difference > X* average then a shot is detected.
    /// This method is simple, yet produces good results.
    /// </summary>
    /// <param name="_subsize">the width/height of a subblock</param>
    /// <param name="_windowSize">the size of the search window</param>
    /// <param name="speedup">the speedup, higher speedup will skip more blocks</param>
    /// <param name="shots">the collection to store the shots in</param>
    public AutoLogMotionMethod(int _subsize, int _windowSize,int speedup, ShotCollection shots)
        : base(shots) {
        this.subsize = _subsize;
        this.windowSize = _windowSize * _subsize; //save the window size in pixels
        this.current = null;
        this.previous = null;
        this.speedup = speedup;
    }

    //see the aShotDetectMethod parent class
    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");

        //move through
        previous = current;

        //new frame
        current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);


        bool isShot = false;
        if (previous != null) { //if there is a previous block to compare

            long currDiff = 0; //difference between previous and current frame kept for the whole frame

            for (int y = 0; y < videoHeight; y += speedup*subsize) { //note the speedup
                for (int x = 0; x < videoWidth; x += speedup*subsize) {
                    
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

                    //keep track of the total difference in the frame
                    currDiff += bestDifference;
                }
            }


            //if total difference > 3* the average => shot
            //also ignore shots within 10 frames of each other, (burst suppression)
            if (currDiff > 3 * avgDiff && frameNumber > lastShot + 10) {
                isShot = true;
                lastShot = frameNumber;
                avgDiff = currDiff;
            }

            //keep a weighted average of the difference
            avgDiff = (int) ((avgDiff * 7 + currDiff * 3 ) / 10);

            return isShot;
        } else {
            //first frame => shot
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
        for (int y = startY ; y < startY+subsize ; y++){
            for (int x = startX; x < startX + subsize; x++) {
                diff+= getAbsDifferencePixel(getPixel(searchX,searchY,current),getPixel(startX,startY,previous));
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
