using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Factory that creates the different methods
/// </summary>
public class MethodFactory {
    /// <summary>
    /// table that contains all the methods, the index of the method name is used in the getMethod
    /// </summary>
    public static string[] METHODS = { "Pixel", "Motion", "Global hist", "Local hist", "Generalized", "None" };

    /// <summary>
    /// list of the param names foreach method:
    ///     getParamnames()[0] => (first param) => { name, description, type, minValue, maxValue }
    /// </summary>
    public static string[][][] METHODINFO = new String[][][]{
        new String[][] {//pixel
            new String[] {"delta2" , "difference in pixels needed to generate a 'hit'", "int", "0" , "256"},
            new String[] {"delta3" , "% of pixels that was hit or had a big enough distance " , "double", "0","1"},
        },new String[][] {//motion
            new String[] {"subsize" , "the size of the subblock, higher for less accurate motion searching", "int", "0" , "32"},
            new String[] {"windowsize" , "the size of the searchWindow, expressed in subblocks, higher for longer searches", "int", "1","4"}
        },new String[][] {//global hist
            new String[] {"changedFraction" , "the fraction that ends up in a different bin of the histogram", "double", "0" , "2"},
            new String[] {"binCount" , "number of different bins" , "int", "1","256"}
        },new String[][] {//local hist
            new String[] {"changedFraction" , "the fraction that ends up in a different bin of the histogram", "double", "0" , "2"},
            new String[] {"binCount" , "number of different bins" , "int", "1","256"},
            new String[] {"nrOfBlocks", "the number of different blocks used, e.g. 1,2,4,9,16,25,36..." , "int^2", "1", "100"}
        },new String[0][],//general
        new String[0][]//empty
    };


    /// <summary>
    /// Constructor
    /// </summary>
    public MethodFactory() {}

    /// <summary>
    /// Creates a shotDetectionMethod
    /// </summary>
    /// <param name="index">the index that represents the shot detection method</param>
    /// <returns></returns>
    public aShotDetectionMethod getMethod(int index, ShotCollection shots) {
        aShotDetectionMethod method = null;

        switch (index) {
            case 0: //Pixel
                int delta2 = 256;
                double delta3 = 0.25;

                shots.addParameter(delta2);
                shots.addParameter(delta3);

                method = new PixelMethod(delta2, delta3,shots);
                break;
            case 1: //Motion
                int subsize = 8;
                int windowSize = 2;
                shots.addParameter(subsize);
                shots.addParameter(windowSize);

                method = new MotionMethod(subsize, windowSize,shots);
                break;
            case 2://global hist
                double threshold = 0.25;          // The threshold will be chosen as the fraction of pixels that ended up in a different bin of the histogram.
                int nrOfBins = 51; //5 values wide
                shots.addParameter(threshold);
                shots.addParameter(nrOfBins);
                method = new GlobalHistogramMethod(threshold, nrOfBins,shots);
                break;
            case 3://local hist
                double thresh = 0.4;          // The threshold will be chosen as the fraction of pixels that ended up in a different bin of the histogram.
                int nrBins = 32;
                int nrOfBlocks = 9;
                shots.addParameter(thresh);
                shots.addParameter(nrBins);
                shots.addParameter(nrOfBlocks);

                method = new LocalHistogram(thresh, nrBins, nrOfBlocks,shots);
                break;
            case 4://generalized
                //method = new Method4(frameBuffer);;
                //break;
            case 5:
                method = new EmptyMethod(shots);
                break;
        }

        return method;
    }
}