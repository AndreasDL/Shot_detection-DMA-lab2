using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;

using DirectShowLib;
/// <summary>
/// This method compares pixels to detect shots
/// </summary>
public class PixelMethod : aShotDetectionMethod {
    private byte[] current;
    private byte[] previous;
    private int delta2;
    private double delta3;
    private int lastShot;

    public PixelMethod(int _delta2, double _delta3, ShotCollection shots): base(shots){
        this.delta2 = _delta2;
        this.delta3 = 2 * _delta3; //delta3 between 0 and 2, since differences are counted twice (because of absolute values), rescaled to 0->1, so reverse scaling here
        this.current = null;
        this.previous = null;
    }

    /// <summary> this function is called for each frame </summary>
    /// <param name="SampleTime">the time of the frame (if you want a frame count, then you must count in the method)</param>
    /// <param name="pBuffer">a pointer to the first byte of the image (each pixel has 3 bytes and the frame is m_stride wide so byte[m_stide*5 + 7*3] is the first component of pixel with y=5, x = 7</param>
    /// <param name="bufferLen>number of bytes in pBuffer</param>
    /// <returns>error code (if zero then everything is ok)</returns>
    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen){
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64 / run on 32bit pc");

        // Hand over frame to previous frame and store new frame.
        previous = current;
        current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        //Only do this block of code, when the previous frame is filled in (= starting from the second frame)
        if (previous != null) {
            int twoPixDiff; // Difference between 2 pixels
            int threshReached = 0;  // Counter for how many pixel differences reached the threshold.
            for (int i = 0; i < BufferLen - 3; i += 3) {
                // Calculate R, G an B difference for a pixel
                twoPixDiff = 0;
                twoPixDiff += Math.Abs(current[i] - previous[i]);
                twoPixDiff += Math.Abs(current[i + 1] - previous[i + 1]);
                twoPixDiff += Math.Abs(current[i + 2] - previous[i + 2]);

                // If this pixel reached the threshold: increment counter
                if (twoPixDiff > delta2) threshReached++;
            }

            // If more than delta3 percent of the pixels reached the threshold: a shot is detected.
            if (threshReached * 3.0 / (BufferLen * 1.0) > (delta3) //bufferlen = videoWidth * videoHeight * 3
                && frameNumber > lastShot + 10)  //ignore bursts
            {
                lastShot = frameNumber;
                return true;
            } else {
                return false;
            }
        } else { //first shot starts at frame 0
            lastShot = 0;
            return true;
        }
    }

}