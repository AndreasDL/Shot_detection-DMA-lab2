using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtractframeMethod: aShotDetectionMethod {
    private string filename;

    public ExtractframeMethod(ShotCollection shots, String filename) : base(shots) {
        this.filename = filename;
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        //save incomming buffer to file system

        return false;
    }
}
