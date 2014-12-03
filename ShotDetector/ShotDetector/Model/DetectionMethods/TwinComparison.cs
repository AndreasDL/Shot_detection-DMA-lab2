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
/// <summary>
/// This method does nothing, when this method is picked, no shot detection is applied
/// </summary>
public class TwinComparison: aShotDetectionMethod {

    private List<int[]> previous_histograms;
    private List<int[]> current_histograms;
    private List<List<int[]>> allHistograms;

    private List<long> differences;

    private int nrOfBlocks;
    private int nrOfBins;
    private int divider;
    private double alfa, beta, gamma, delta;

    //a = 1.5 ; b = 0 ; c = 1 : d = 2
    //Lower Threshold = alfa * mean difference + beta * stdev
    //Upper Threshold = gamma * mean difference + delta * stdev
    public TwinComparison(int nrOfBins, int nrOfBlocks, ShotCollection shots, double alfa, double beta, double gamma, double delta)
        : base(shots) {
        this.nrOfBins = nrOfBins;
        this.nrOfBlocks = nrOfBlocks;
        this.alfa = alfa;
        this.beta = beta;
        this.gamma = gamma;
        this.delta = delta;
        
        this.divider = (int)(Math.Ceiling(255.0 / nrOfBins));
        this.differences = new List<long>();
        this.allHistograms = new List<List<int[]>>();
        this.previous_histograms = null;
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");

        //////////////////////////////////////////
        ////// Copy IntPtr to byte array
        //////////////////////////////////////////

        byte[] current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        int number = (int)Math.Sqrt((double)nrOfBlocks);
        int endCols = videoWidth - (videoWidth % number);//Ignore last x pixels if they don't match
        int endRows = videoHeight - (videoHeight % number);
        int sizeCols = endCols / number;
        int sizeRows = endRows / number;
        previous_histograms = current_histograms;
        current_histograms = new List<int[]>();

        //////////////////////////////////////////
        ////// Compute current histogram
        //////////////////////////////////////////  

        for (int i = 0; i < endRows; i = i + sizeRows) {
            for (int j = 0; j < endCols; j = j + sizeCols) {
                // hist is the histogram of the current block
                int[] hist = new int[nrOfBins * 3];
                for (int k = 0; k < hist.Length; k++) { hist[k] = 0; }//hist entries are initialized to 0

                for (int x = i; x < sizeRows + i; x++) {
                    for (int y = j; y < sizeCols + j; y++) {

                        byte[] currPixel = getPixel(y, x, current);
                        hist[(int)(currPixel[0] / divider)]++;
                        hist[(int)(currPixel[1] / divider) + 1]++;//+ nrOfBins]++;
                        hist[(int)(currPixel[2] / divider) + +2]++;//2 * nrOfBins]++;

                    }
                }

                current_histograms.Add(hist);
            }

        }
        allHistograms.Add(current_histograms);

        /////////////////////////////////////////////////
        ////// Calculate differences between histograms
        /////////////////////////////////////////////////  

        //Only do this block of code, when the previous frame is filled in (starting from the second frame), to detect shots
        if (frameNumber != 0) {
            long twoHistsDiff = 0;

            for (int k = 0; k < current_histograms.Count; k++) {
                for (int i = 0; i < nrOfBins * 3 - 1; i++) {
                    twoHistsDiff += Math.Abs(current_histograms[k][i] - previous_histograms[k][i]);
                }
            }

            differences.Add(twoHistsDiff);

        } else {//hardcoded first shot starts at frame 0
            //first shot starts at frame 0
            return true;
        }

        //other frame are never true, they are only discovered after processing the data
        return false;
    }

    public List<int> processData() {
        List<int> cutFrameNumbers = new List<int>();

        /////////////////////////////////////////////////
        ////// Compute mean and standard deviation
        /////////////////////////////////////////////////  

        double mean = 0.0;
        double stdev = 0.0;

        for (int i = 0; i < differences.Count; i++) {
            mean += differences.ElementAt(i);
        }
        mean /= (1.0 * differences.Count);
        for (int i = 0; i < differences.Count; i++) {
            stdev += Math.Pow((Math.Abs(mean - differences.ElementAt(i)) * 1.0), 2);
        }
        stdev /= ((differences.Count * 1.0) - 1.0);
        stdev = Math.Pow(stdev, 1.0 / 2.0);

        List<long> sorted = differences;
        sorted.OrderBy(l => l).ToList();
        double median = sorted.ElementAt(sorted.Count / 2);

        /////////////////////////////////////////////////
        ////// Determine cuts (hard and gradual)
        /////////////////////////////////////////////////

        double thresh_low = alfa * mean + beta * stdev;
        double thresh_high = gamma * mean + delta * stdev;
        long diffSum = 0;

        for (int i = 0; i < differences.Count; i++) {

            if (differences.ElementAt(i) > thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10)) {
                //hard cut
                cutFrameNumbers.Add(i + 1);
            } else if (differences.ElementAt(i) > thresh_low && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10)) {
                //possible soft cut

                if (diffSum > thresh_high) {

                    while (i < differences.Count && differences.ElementAt(i) >= thresh_low && differences.ElementAt(i) < thresh_high) {
                        diffSum += differences.ElementAt(i);
                        i++;
                    }

                    if (differences.ElementAt(i) > thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10)) {
                        // Exited while loop because of hard cut.
                        cutFrameNumbers.Add(i + 1);
                    } else if (diffSum > thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10)) {
                        //soft cut
                        cutFrameNumbers.Add(i + 1);
                        diffSum = 0;
                    }

                }

            }


        }

        for (int i = 0; i < cutFrameNumbers.Count; i++) {
            Shot s = new Shot(cutFrameNumbers.ElementAt(i), shots.getShots().Count, null);
            shots.addShot(s);
        }

        return cutFrameNumbers;
    }




}