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
    private ShotCollection shots;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="shots">the shot collection that must contain all the detected shots</param>
    public MethodFactory(ShotCollection shots) {
        this.shots = shots;
    }

    /// <summary>
    /// Creates a shotDetectionMethod
    /// </summary>
    /// <param name="index">the index that represents the shot detection method</param>
    /// <returns></returns>
    public aShotDetectionMethod getMethod(int index) {
        aShotDetectionMethod method = null;

        switch (index) {
            case 0: //Pixel
                int delta2 = 256;
                double delta3 = 0.25;
                method = new PixelMethod(delta2, delta3,shots);
                break;
            case 1: //Motion
                int subsize = 8;
                int windowSize = 3;
                method = new MotionMethod(subsize, windowSize,shots);
                break;
            case 2://global hist
                double threshold = 1.5;          // The threshold will be chosen as the fraction of pixels that ended up in a different bin of the histogram.
                int nrOfBins = 51; //5 values wide
                method = new HistogramMethod(threshold, nrOfBins,shots);
                break;
            case 3://local hist
                //method = new Method3(frameBuffer);
                break;
            case 4://generalized
                //method = new Method4(frameBuffer);;
                break;
            case 5:
                method = new EmptyMethod(shots);
                break;
        }

        return method;
    }
}