using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MethodFactory {
    public static string[] METHODS = { "Pixel", "Motion", "Global hist", "Local hist", "Generalized", "None" };

    public aShotDetectionMethod getMethod(int index) {
        aShotDetectionMethod method = null;

        switch (index) {
            case 0: //Pixel
                int delta2 = 256;
                double delta3 = 0.25;
                method = new PixelMethod(delta2, delta3);
                break;
            case 1: //Motion
                int subsize = 16;
                int windowSize = 0;
                method = new MotionMethod(subsize, windowSize);
                break;
            case 2://global hist
                double threshold = 0.40;          // The threshold will be chosen as the fraction of pixels that ended up in a different bin of the histogram.
                int nrOfBins = 32;
                method = new HistogramMethod(threshold, nrOfBins);
                break;
            case 3://local hist
                //method = new Method3(frameBuffer);
                break;
            case 4://generalized
                //method = new Method4(frameBuffer);;
                break;
            case 5:
                method = new EmptyMethod();
                break;
        }

        return method;
    }
}