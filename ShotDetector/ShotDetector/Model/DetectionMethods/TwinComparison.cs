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

    private List<long> differences;
    private List<int[]> histograms;

    private int[] current_histogram;
    private int[] previous_histogram;

    private int nrOfBins;
    private int divider;
    private int lastShot;

    public TwinComparison(int _nrOfBins, ShotCollection shots) : base(shots) {
        this.differences = new List<long>();
        this.histograms = new List<int[]>();
        this.nrOfBins = _nrOfBins;
        this.divider = 255 / nrOfBins;
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {

        Console.WriteLine(frameNumber);

        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");
        previous_histogram = current_histogram;

        //////////////////////////////////////////
        ////// Copy IntPtr to byte array
        //////////////////////////////////////////

        byte[] current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        
        //////////////////////////////////////////
        ////// Compute current histogram
        //////////////////////////////////////////  
   
        /// Initialize al values to zero
        current_histogram = new int[nrOfBins * 3];           // We choose to combine the histogram of R, G and B values in 1 large array
        for (int i = 0; i < 3*nrOfBins; i++) {
            current_histogram[i] = 0;
        }

        /// Fill the histogram according to the bin frequency
        for (int i = 0; i < BufferLen - 3; i += 3) {
            current_histogram[current[i] / divider]++;          // R position in histogram
            current_histogram[current[i + 1] / divider + 1]++;  // G position in histogram
            current_histogram[current[i + 2] / divider + 2]++;  // B position in histogram
        }

        /// Add histogram to histogram list
        histograms.Add(current_histogram);

        /////////////////////////////////////////////////
        ////// Calculate differences between histograms
        /////////////////////////////////////////////////  

        //Only do this block of code, when the previous frame is filled in (starting from the second frame), to detect shots
        if (previous_histogram != null)
        {
            long twoHistsDiff = 0;

            for (int i = 0; i < nrOfBins * 3 - 3; i += 3)
            {
                twoHistsDiff += Math.Abs(current_histogram[i] - previous_histogram[i]);
                twoHistsDiff += Math.Abs(current_histogram[i + 1] - previous_histogram[i + 1]);
                twoHistsDiff += Math.Abs(current_histogram[i + 2] - previous_histogram[i + 2]);
            }

            differences.Add(twoHistsDiff);

        }
        else
        {
            //first shot starts at frame 0
            lastShot = 0;
            return true;
        }

        if (frameNumber == 2677)
        {
            List<int> dummy = new List<int>();
            dummy = processData();
        }

        return false;
    }

    public List<int> processData(){
        List<int> cutFrameNumbers = new List<int>();

        /////////////////////////////////////////////////
        ////// Compute mean and standard deviation
        /////////////////////////////////////////////////  

        double mean = 0.0;
        double stdev = 0.0;

        Console.Write("Calculating mean difference... ");
        for (int i = 0; i < differences.Count; i++)
        {
            mean += differences.ElementAt(i);
        }
        mean /= (1.0*differences.Count);
        Console.WriteLine("Mean calculated: " + mean);

        Console.Write("Calculating standard deviation... ");
        for (int i = 0; i < differences.Count; i++)
        {
            stdev += Math.Pow((mean-differences.ElementAt(i))*1.0,2.0);
        }
        stdev /= ((differences.Count * 1.0) - 1.0);
        stdev = Math.Pow(stdev, 1.0 / 2.0);
        Console.WriteLine("Calculated standard deviation: " + stdev);

        /////////////////////////////////////////////////
        ////// Determine cuts (hard and gradual)
        /////////////////////////////////////////////////
  
        double thresh_low = 9.0 * mean; // Might be better if this is changed into max(mean,median)
        double thresh_high = mean + 5.0 * stdev;

        long diffToStart = 0;
        int startIndex = 0;
        bool checkingtransition = false;
        
        for (int i = 0; i < differences.Count; i++)
        {
            if (differences.ElementAt(i) > thresh_high && !checkingtransition)
            {
                // (Hard) cut detected
                cutFrameNumbers.Add(i);
            }
            else if (differences.ElementAt(i) > thresh_low)
            {
                if(!checkingtransition){
                // Possible start of gradual cut
                    checkingtransition = true;
                    startIndex = i;
                } else {

                    diffToStart = 0;
                    for (int j = 0; j < nrOfBins * 3 - 3; j += 3)
                    {
                        diffToStart += Math.Abs(histograms.ElementAt(startIndex)[i] - Math.Abs(histograms.ElementAt(j)[i]);
                        diffToStart += Math.Abs(histograms.ElementAt(startIndex)[i + 1] - Math.Abs(histograms.ElementAt(j)[i + 1]);
                        diffToStart += Math.Abs(histograms.ElementAt(startIndex)[i + 2] - Math.Abs(histograms.ElementAt(j)[i + 2]);
                    }

                    if(diffToStart > thresh_high){  // Maybe && i-5 > startIndex to make sure a gradual transition is long enough
                        // Detect cut
                        cutFrameNumbers.Add(i);
                        checkingtransition = false;
                    } else if(diffToStart < thresh_low){
                        // Discard cut
                        checkingtransition = false;
                    }

                }


            }
        }



            return cutFrameNumbers;
    }
}