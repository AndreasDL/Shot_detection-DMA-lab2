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

public class LocalHistogram: aShotDetectionMethod {
    private List<int[]> previous_histograms;
    private List<int[]> current_histograms;
    
    private double threshold;
    private int nrOfBins;
    private int divider;
    private int number, endCols, endRows, sizeCols, sizeRows, nrOfBlocks;

    public LocalHistogram(double _threshold, int _nrOfBins, int _nrOfBlocks,ShotCollection shots): base(shots) {
        this.threshold = _threshold;
        this.nrOfBins = _nrOfBins;
        this.divider = (int)(Math.Ceiling(255.0 / nrOfBins));
        this.nrOfBlocks = _nrOfBlocks;

        this.previous_histograms = null;
        this.current_histograms = null;

    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen){
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");

        this.number = (int)Math.Sqrt((double)nrOfBlocks);
        this.endCols = videoWidth - (videoWidth % number);//Ignore last x pixels if they don't match
        this.endRows = videoHeight - (videoHeight % number);
        this.sizeCols = endCols / number;
        this.sizeRows = endRows / number;

        byte[] current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        previous_histograms = current_histograms;
        current_histograms = new List<int[]>();

        // Create nrOfBlocks histograms of the current frame
        for (int i = 0; i < endRows; i = i + sizeRows) {
            for (int j = 0; j < endCols; j = j + sizeCols) {
                
                // hist is the histogram of the current block
                int[] hist = new int[nrOfBins * 3];
                for (int k = 0; k < hist.Length; k++) { hist[k] = 0; }//hist entries are initialized to 0

                for (int x = i; x < sizeRows + i; x++) {
                    for (int y = j; y < sizeCols + j; y++) {

                        byte[] currPixel = getPixel(y, x, current);
                        hist[(int)(currPixel[0] / divider)]++;
                        hist[(int)(currPixel[1] / divider) + nrOfBins]++;
                        hist[(int)(currPixel[2] / divider) + 2 * nrOfBins]++;

                    }
                }

                current_histograms.Add(hist);
            }
        }

        if (frameNumber != 0) {
            double twoHistsDiff = 0;
            for (int k = 0; k < current_histograms.Count; k++) {
                for (int i = 0; i < nrOfBins * 3 - 1; i++) {
                    twoHistsDiff += Math.Abs(current_histograms[k][i] - previous_histograms[k][i]);
                }
            }
            return twoHistsDiff > threshold * BufferLen;
        }else{
            return true;
        }
    }

    private byte[] getPixel(int x, int y, byte[] frame) {
        int position = y * m_stride + 3 * x;

        byte[] pixel = { frame[position], frame[position + 1], frame[position + 2] };

        return pixel;
    }

}