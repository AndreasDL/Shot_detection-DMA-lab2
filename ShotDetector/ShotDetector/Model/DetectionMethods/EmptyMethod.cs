﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EmptyMethod: aShotDetectionMethod {

    public EmptyMethod(ShotCollection shots) : base(shots) {}

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        return false;
    }
}