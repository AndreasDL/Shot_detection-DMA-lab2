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
        shots.addParameter("distance",distance);
        shots.addParameter("fraction",fraction);
        aShotDetectionMethod method = new PixelMethod(distance, fraction, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getAutoLogMotionMethod(ShotCollection shots,IFrameObserver fo, int subSize, int windowSize, int speedup) {
        shots.addParameter("subSize",subSize);
        shots.addParameter("winSize",windowSize);
        shots.addParameter("speedup",speedup);
        aShotDetectionMethod method = new AutoLogMotionMethod(subSize, windowSize,speedup, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getLogMotionMethod(ShotCollection shots, IFrameObserver fo, int subSize, int windowSize, int threshold, double fraction) {
        shots.addParameter("subSize",subSize);
        shots.addParameter("winSize",windowSize);
        shots.addParameter("threshold",threshold);
        shots.addParameter("fraction",fraction);
        aShotDetectionMethod method = new LogMotionMethod(subSize, windowSize, shots, fraction, threshold);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getGlobalHistogramMethod(ShotCollection shots,IFrameObserver fo, int binCount, double fraction) {
        shots.addParameter("binCount",binCount);
        shots.addParameter("fraction",fraction);
        aShotDetectionMethod method = new GlobalHistogramMethod(fraction, binCount, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getLocalHistogramMethod(ShotCollection shots,IFrameObserver fo, int binCount, double fraction, int blockCount) {
        shots.addParameter("binCount",binCount);
        shots.addParameter("fraction",fraction);
        shots.addParameter("blockCount",blockCount);
        aShotDetectionMethod method = new LocalHistogram(fraction, binCount, blockCount, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getTwinComparisonMethod(ShotCollection shots, IFrameObserver fo,int nrOfBins, int nrOfBLock) {
        shots.addParameter("nrOfBins",nrOfBins);
        shots.addParameter("nrOfBlocks",nrOfBLock);
        aShotDetectionMethod method = new TwinComparison(nrOfBins, nrOfBLock, shots);
        method.addFrameObserver(fo);
        return method;
    }

    public aShotDetectionMethod getEmptyMethod() {
        return new EmptyMethod();
    }

    public aShotDetectionMethod GrabFrames(ShotCollection shots) {
        return new GrabFrameMethods(shots);
    }

}