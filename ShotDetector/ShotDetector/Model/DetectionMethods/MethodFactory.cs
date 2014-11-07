using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MethodFactory {
    public static string[] METHODS = { "Pixel", "Motion", "Global hist", "Local hist", "Generalized", "None" };
    private ShotCollection shots;

    public MethodFactory(ShotCollection shots) {
        this.shots = shots;
    }

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
                //method = new Method2(frameBuffer);
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