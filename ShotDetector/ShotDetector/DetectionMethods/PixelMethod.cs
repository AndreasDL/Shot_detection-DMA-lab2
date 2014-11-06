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

public class PixelMethod : aShotDetectionMethod,ISampleGrabberCB {

    private byte[] current;
    private byte[] previous;
    private int delta2;
    private double delta3;
    private int frameNumber;

    public PixelMethod(int _delta2, double _delta3): base(){
        this.delta2 = _delta2;
        this.delta3 = _delta3;
        this.frameNumber = 0;
        this.current = null;
        this.previous = null;
    }

    public unsafe override int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen){
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");

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

            if (threshReached * 3.0 / (BufferLen * 1.0) > delta3) {
                base.shotDetected(SampleTime,frameNumber);
            }
        }

        frameNumber++;
        return 0;
    }

}