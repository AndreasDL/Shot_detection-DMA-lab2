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
public class TwinComparison : aShotDetectionMethod
{

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
        : base(shots)
    {
        this.nrOfBins = nrOfBins;
        this.nrOfBlocks = nrOfBlocks;
        this.alfa = alfa;
        this.beta = beta;
        this.gamma = gamma;
        this.delta = delta;

        this.divider = (int)(Math.Ceiling(255.0 / nrOfBins));   // Every pixel value (0 <-> 255) will be divided by this divider to place it in the correct bin.
        this.differences = new List<long>();                    // This list stores the differences between all subsequent histograms for the entire video
        this.allHistograms = new List<List<int[]>>();
        this.previous_histograms = null;
    }

    /// <summary> this function is called for each frame </summary>
    /// <param name="SampleTime">the time of the frame (if you want a frame count, then you must count in the method)</param>
    /// <param name="pBuffer">a pointer to the first byte of the image (each pixel has 3 bytes and the frame is m_stride wide so byte[m_stide*5 + 7*3] is the first component of pixel with y=5, x = 7</param>
    /// <param name="bufferLen>number of bytes in pBuffer</param>
    /// <returns>error code (if zero then everything is ok)</returns>
    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen)
    {
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

        for (int i = 0; i < endRows; i = i + sizeRows)      // Iterate over all blocks
        {
            for (int j = 0; j < endCols; j = j + sizeCols)
            {
                // hist is the histogram of the current block
                int[] hist = new int[nrOfBins * 3];
                for (int k = 0; k < hist.Length; k++) { hist[k] = 0; }  //hist entries are initialized to 0

                for (int x = i; x < sizeRows + i; x++)      // Iterate over all pixels in the selected block
                {
                    for (int y = j; y < sizeCols + j; y++)
                    {
                        // Get the current pixel and store the values in the correct bins
                        byte[] currPixel = getPixel(y, x, current);     
                        hist[(int)(currPixel[0] / divider)]++;
                        hist[(int)(currPixel[1] / divider) + 1]++;
                        hist[(int)(currPixel[2] / divider) + +2]++;

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
        if (frameNumber != 0)
        {
            long twoHistsDiff = 0;

            // Calculate difference between histograms of current frame and histograms of previous frame
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
        {//hardcoded first shot starts at frame 0
            //first shot starts at frame 0
            return true;
        }

        //other frames are never true, they are only discovered after processing the data
        return false;
    }

    /// <summary> This function is called at the end of the movie. It processes the differences to determine where the cuts are situated in the video. </summary>
    /// <returns>A List of integers. This list contains the frame numbers of the cuts. </returns>
    public List<int> processData()
    {
        List<int> cutFrameNumbers = new List<int>();

        /////////////////////////////////////////////////
        ////// Compute mean and standard deviation
        /////////////////////////////////////////////////  

        double mean = 0.0;
        double stdev = 0.0;

        for (int i = 0; i < differences.Count; i++)
        {
            mean += differences.ElementAt(i);
        }
        mean /= (1.0 * differences.Count);
        for (int i = 0; i < differences.Count; i++)
        {
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
        long diffSum;

        for (int i = 0; i < differences.Count; i++)
        {
            // To locate a soft cut, this diffSum is used. From the possible start of a soft cut, the differences between the histograms are added to this variable.
            // If this diffSum exceeds the upper threshold, a soft cut should be detected.
            diffSum = 0;

            if (differences.ElementAt(i) >= thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10))
            {
                // Hard cut if difference between two frames exceeds higher threshold
                cutFrameNumbers.Add(i + 1);
            }
            else if (differences.ElementAt(i) > thresh_low && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10))
            {
                // Possible soft cut if difference between two frames exceeds lower, but not higher threshold

                int transitionLength = 0;   // We keep track of the transition length to make sure a soft cut is at least 10 frames long.

                while (i < differences.Count && differences.ElementAt(i) >= thresh_low && differences.ElementAt(i) < thresh_high)
                {
                    diffSum += differences.ElementAt(i);    // Keep adding the difference to diffsum.
                    i++;    // Increment differences iterator
                    transitionLength++;     // Increment transition length
                }

                // If while loop exited because off difference > higher threshold: hard cut
                if (differences.ElementAt(i) > thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10))
                {
                    // Exited while loop because of hard cut.
                    cutFrameNumbers.Add(i + 1);
                } // If while exited because diffSum > higher threshold: soft cut
                else if (diffSum >= thresh_high && (cutFrameNumbers.Count == 0 || i - cutFrameNumbers.ElementAt(cutFrameNumbers.Count - 1) >= 10) && transitionLength >= 10)
                {
                    //soft cut
                    cutFrameNumbers.Add(i+1);
                }

            }


        }

        // Add all detected shots to the list of shots
        for (int i = 0; i < cutFrameNumbers.Count; i++)
        {
            Shot s = new Shot(cutFrameNumbers.ElementAt(i), shots.getShots().Count, null);
            shots.addShot(s);
        }

        // Return list with shot frame numbers.
        return cutFrameNumbers;
    }




}