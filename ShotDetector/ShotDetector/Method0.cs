using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;

using DirectShowLib;

public class Method0 : Method
{

    byte[] current;
    byte[] previous;
    private int delta2;
    private double delta3;
    private int bufferLen;

    public Method0(byte[] _current, byte[]_previous, int _bufferLen, int _delta2, double _delta3)
    {
        this.current = _current;
        this.previous = _previous;
        this.delta2 = _delta2;
        this.delta3 = _delta3;
        this.bufferLen = _bufferLen;
    }

    public bool run()
    {

        int twoPixDiff;
        int threshReached = 0;
        for (int i = 0; i < bufferLen-3; i+=3)
        {
            twoPixDiff = 0;
            twoPixDiff += Math.Abs(current[i]-previous[i]);
            twoPixDiff += Math.Abs(current[i+1] - previous[i+1]);
            twoPixDiff += Math.Abs(current[i+2] - previous[i+2]);

            if (twoPixDiff > delta2) threshReached++;
        }

        if (threshReached*1.0 / (bufferLen*1.0 / 3.0) > delta3)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}