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
        this.delta3 = 2 * _delta3;//delta3 is between 0 and 2, since difference are counted twice (because of absolute values), rescaled to 0->1, so reverse scaling here
        this.current = null;
        this.previous = null;
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen){
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64 / run on 32bit pc");

        previous = current;
        current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        //Only do this block of code, when the previous frame is filled in (starting from the second frame)
        if (previous != null) {
            int twoPixDiff;
            int threshReached = 0;
            for (int i = 0; i < BufferLen - 3; i += 3) {
                twoPixDiff = 0;
                twoPixDiff += Math.Abs(current[i] - previous[i]);
                twoPixDiff += Math.Abs(current[i + 1] - previous[i + 1]);
                twoPixDiff += Math.Abs(current[i + 2] - previous[i + 2]);

                if (twoPixDiff > delta2) threshReached++;
            }

            if (threshReached * 3.0 / (BufferLen * 1.0) > (delta3) //bufferlen = videoWidth * videoHeight * 3
                && frameNumber > lastShot + 10)  //ignore bursts
            {
                lastShot = frameNumber;
                return true;
            } else {
                return false;
            }
        } else { //first shot starts ate frame 0
            lastShot = 0;
            return true;
        }
    }

}