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

    private Queue<byte[]> frameBuffer;

    public Method0(Queue<byte[]> _frameBuffer)
    {
        this.frameBuffer = _frameBuffer;
    }

    public void run()
    {
        Console.WriteLine("This is method 0.");
    }

}