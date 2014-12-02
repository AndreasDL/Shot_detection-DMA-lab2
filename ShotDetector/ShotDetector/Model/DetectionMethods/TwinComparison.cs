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
   

    private int[] current_histogram;
    private int[] previous_histogram;

    private int nrOfBins;
    private int divider;
    private int lastShot;

    private int number, endCols, endRows, sizeCols, sizeRows, nrOfBlocks;


    public TwinComparison(int _nrOfBins, int _nrOfBlocks, ShotCollection shots) : base(shots) {
        this.differences = new List<long>();
        this.nrOfBins = _nrOfBins;
        this.divider = (int)(Math.Ceiling(255.0 / nrOfBins)); 
        this.previous_histograms = null;
        this.current_histograms = null;
        this.nrOfBlocks = _nrOfBlocks;
        this.allHistograms = new List<List<int[]>>();
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {

        //Console.WriteLine(frameNumber);

        Debug.Assert(IntPtr.Size == 4, "Change all instances of IntPtr.ToInt32 to .ToInt64");
        previous_histogram = current_histogram;

        //////////////////////////////////////////
        ////// Copy IntPtr to byte array
        //////////////////////////////////////////

        byte[] current = new byte[(videoHeight * videoWidth) * 3];
        Marshal.Copy(pBuffer, current, 0, BufferLen);

        this.number = (int)Math.Sqrt((double)nrOfBlocks);
        this.endCols = videoWidth - (videoWidth % number);//Ignore last x pixels if they don't match
        this.endRows = videoHeight - (videoHeight % number);
        this.sizeCols = endCols / number;
        this.sizeRows = endRows / number;
        previous_histograms = current_histograms;
        current_histograms = new List<int[]>();
    
        //////////////////////////////////////////
        ////// Compute current histogram
        //////////////////////////////////////////  

        for (int i = 0; i < endRows; i = i + sizeRows)
        {
            for (int j = 0; j < endCols; j = j + sizeCols)
            {
                // hist is the histogram of the current block
                int[] hist = new int[nrOfBins * 3];
                for (int k = 0; k < hist.Length; k++) { hist[k] = 0; }//hist entries are initialized to 0

                for (int x = i; x < sizeRows + i; x++)
                {
                    for (int y = j; y < sizeCols + j; y++)
                    {

                        byte[] currPixel = getPixel(y, x, current);
                        hist[(int)(currPixel[0] / divider)]++;
                        hist[(int)(currPixel[1] / divider) + nrOfBins]++;
                        hist[(int)(currPixel[2] / divider) + 2 * nrOfBins]++;

                    }
                }

                current_histograms.Add(hist);
            }

        }
        allHistograms.Add(current_histograms);


        /// Add histogram to histogram list
        //histograms.Add(current_histogram);

        /////////////////////////////////////////////////
        ////// Calculate differences between histograms
        /////////////////////////////////////////////////  

        //Only do this block of code, when the previous frame is filled in (starting from the second frame), to detect shots
        if (frameNumber != 0)
        {
            long twoHistsDiff = 0;

            for (int k = 0; k < current_histograms.Count; k++)
            {
                for (int i = 0; i < nrOfBins * 3 - 1; i++)
                {
                    twoHistsDiff += Math.Abs(current_histograms[k][i] - previous_histograms[k][i]);
                }
            }

            differences.Add(twoHistsDiff);

        }
        else
        {
            //first shot starts at frame 0
            lastShot = 0;
            return true;
        }

        if (frameNumber == 2672)
        {
            List<int> dummy = new List<int>();
            Console.WriteLine("Will now process data");
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
            stdev += Math.Pow((Math.Abs(mean-differences.ElementAt(i))*1.0),2);
        }
        stdev /= ((differences.Count * 1.0) - 1.0);
        stdev = Math.Pow(stdev, 1.0 / 2.0);
        Console.WriteLine("Calculated standard deviation: " + stdev);

        List<long> sorted = differences;
        sorted.OrderBy(l => l).ToList();
        double median = sorted.ElementAt(sorted.Count / 2);


        /////////////////////////////////////////////////
        ////// Determine cuts (hard and gradual)
        /////////////////////////////////////////////////

        double thresh_low = 1.5 * mean;
        
        double thresh_high = mean + 2 * stdev;

        long diffToStart = 0;
        int startIndex = 0;
        bool checkingtransition = false;

        long diffSum = 0;

        for (int i = 0; i < differences.Count; i++)
        {

            if (differences.ElementAt(i) > thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10))
            {
                Console.WriteLine("HARD");
                cutFrameNumbers.Add(i + 1);
            } else if (differences.ElementAt(i) > thresh_low && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10))
            {
                Console.WriteLine("Possible soft cut...");

                if (diffSum > thresh_high)
                {

                    while (i < differences.Count && differences.ElementAt(i) >= thresh_low && differences.ElementAt(i) < thresh_high)
                    {
                        diffSum += differences.ElementAt(i);
                        i++;
                    }

                    if (differences.ElementAt(i) > thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10))
                    {
                        // Exited while loop because of hard cut.
                        Console.WriteLine("HARD (WHILE)");
                        cutFrameNumbers.Add(i + 1);
                    }
                    else if (diffSum > thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10))
                    {
                        Console.WriteLine("SOFT");
                        cutFrameNumbers.Add(i + 1);
                        diffSum = 0;
                    }

                }

            }


        }

        /*

            for (int i = 0; i < differences.Count; i++)
            {
                if (differences.ElementAt(i) > thresh_high && !checkingtransition && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10))    // We suppose a shot doesn't come in the next 10 frames.
                {
                    // (Hard) cut detected
                    Console.WriteLine("HARD");
                    cutFrameNumbers.Add(i + 1);
                }
                else if (differences.ElementAt(i) > thresh_low)
                {
                    if (!checkingtransition)
                    {
                        // Possible start of gradual cut
                        checkingtransition = true;
                        startIndex = i;
                    }
                    else
                    {

                        diffToStart = 0;
                        Console.WriteLine("Possible soft cut");



                        for (int k = 0; k < allHistograms.ElementAt(i).Count; k++)
                        {
                            for (int r = 0; r < nrOfBins * 3 - 1; r++)
                            {
                                diffToStart += Math.Abs(allHistograms.ElementAt(startIndex).ElementAt(k)[r] - allHistograms.ElementAt(i).ElementAt(k)[r]);

                            }
                        }

                        Console.WriteLine(diffToStart + " >? " + thresh_high);

                        if (diffToStart > thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10))
                        {  // Maybe && i-5 > startIndex to make sure a gradual transition is long enough
                            // Detect cut
                            int stop = (i) - ((i) - startIndex) / 2 + 1;
                            Console.WriteLine("SOFT");
                            cutFrameNumbers.Add(stop);     // should be startindex.
                            checkingtransition = false;

                        }
                        else if (diffToStart < thresh_low && (i - startIndex) >= 15)
                        {
                            // Discard cut
                            checkingtransition = false;
                        }

                    }


                }
            }
         * 
         */

        for(int i=0; i<cutFrameNumbers.Count; i++){
            Shot s = new Shot(cutFrameNumbers.ElementAt(i), shots.getShots().Count, null);
            shots.addShot(s);
        }

        return cutFrameNumbers;
    }




       private byte[] getPixel(int x, int y, byte[] frame) {
        int position = y * m_stride + 3 * x;

        byte[] pixel = { frame[position], frame[position + 1], frame[position + 2] };

        return pixel;
    }

}