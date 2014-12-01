using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EmptyMethod: aShotDetectionMethod {
    public EmptyMethod() : base(null) { }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        return false;
    }
}
