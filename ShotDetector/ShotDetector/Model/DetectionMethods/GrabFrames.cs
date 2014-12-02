﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class GrabFrameMethods: aShotDetectionMethod {
    int i;

    public GrabFrameMethods(ShotCollection shots):base(shots) {
        i = 0;
    }


    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {

        if (i < shots.getShots().Count - 1) {
            IntPtr temp = Marshal.AllocHGlobal(BufferLen);
            CopyMemory(temp, pBuffer, (uint)BufferLen);
            shots.getShot(i).setBitmap(new Bitmap(this.videoWidth, this.videoHeight, -m_stride, PixelFormat.Format24bppRgb, (IntPtr)(temp.ToInt32() + BufferLen - m_stride)));

            i++;
        }

        return false;
    }
}