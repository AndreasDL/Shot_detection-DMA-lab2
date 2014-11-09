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
/// This method uses a global histogram to detect shots
/// </summary>
public class HistogramMethod: aShotDetectionMethod, ISampleGrabberCB {

    private int[] current_histogram;
    private int[] previous_histogram;
    private double threshold;
    private int nrOfBins;
    private int divider;

    public HistogramMethod(double _threshold, int _nrOfBins,ShotCollection shots)
        : base(shots) {
        this.threshold = _threshold;
        this.nrOfBins = _nrOfBins;
        this.divider = 255 / nrOfBins;
        this.current_histogram = null;
        this.previous_histogram = null;
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");

        previous_histogram = current_histogram;

        // Compute current histogram
        byte[] current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        current_histogram = new int[nrOfBins * 3];           // We choose to combine the histogram of R, G and B values in 1 large array
        for (int i = 0; i < BufferLen - 3; i += 3) {
            current_histogram[current[i] / divider]++;          // R position in histogram
            current_histogram[current[i + 1] / divider + 1]++;  // G position in histogram
            current_histogram[current[i + 2] / divider + 2]++;  // B position in histogram
        }

        //////////////////////////////

        //Only do this block of code, when the previous frame is filled in (starting from the second frame)
        if (previous_histogram != null) {
            int twoHistsDiff = 0;
            for (int i = 0; i < nrOfBins * 3 - 3; i += 3) {
                twoHistsDiff += Math.Abs(current_histogram[i] - previous_histogram[i]);
                twoHistsDiff += Math.Abs(current_histogram[i + 1] - previous_histogram[i + 1]);
                twoHistsDiff += Math.Abs(current_histogram[i + 2] - previous_histogram[i + 2]);
            }

            if (twoHistsDiff > threshold * BufferLen) {
                return true;
            }else{
                return false;
            }
        } else {
            return true;
        }
    }

}