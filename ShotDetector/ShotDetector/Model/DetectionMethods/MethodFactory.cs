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
    public static string[] METHODS = { "Pixel", "Motion", "Global hist", "Local hist", "Twin Comparison", "None" };

    /// <summary>
    /// Constructor
    /// </summary>
    public MethodFactory() {}

    public aShotDetectionMethod getPixelMethod(ShotCollection shots,IFrameObserver fo, int distance, double fraction) {
        shots.addParameter(distance);
        shots.addParameter(fraction);
        aShotDetectionMethod method = new PixelMethod(distance, fraction, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getMotionMethod(ShotCollection shots,IFrameObserver fo, int subSize, int windowSize) {
        shots.addParameter(subSize);
        shots.addParameter(windowSize);
        aShotDetectionMethod method = new LogMotionMethod(subSize, windowSize, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getGlobalHistogramMethod(ShotCollection shots,IFrameObserver fo, int binCount, double fraction) {
        shots.addParameter(binCount);
        shots.addParameter(fraction);
        aShotDetectionMethod method = new GlobalHistogramMethod(fraction, binCount, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getLocalHistogramMethod(ShotCollection shots,IFrameObserver fo, int binCount, double fraction, int blockCount) {
        shots.addParameter(binCount);
        shots.addParameter(fraction);
        shots.addParameter(blockCount);
        aShotDetectionMethod method = new LocalHistogram(fraction, binCount, blockCount, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getTwinComparisonMethod(ShotCollection shots, IFrameObserver fo,int nrOfBins) {
        shots.addParameter(nrOfBins);
        aShotDetectionMethod method = new TwinComparison(nrOfBins, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getEmptyMethod() {
        return new EmptyMethod();
    }

    public aShotDetectionMethod GrabFrames(ShotCollection shots) {
        return new frameShotGrabber(shots);
    }

}