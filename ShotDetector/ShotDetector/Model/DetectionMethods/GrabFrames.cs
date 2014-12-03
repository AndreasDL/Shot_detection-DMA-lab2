using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// This method grabs all frames it encounters, this is used to retrieve the frameShots that are displayed in the gui
/// </summary>
class GrabFrameMethods: aShotDetectionMethod {
    int i; //keep track of the detected shots

    /// <summary>
    /// This method grabs all frames it encounters, this is used to retrieve the frameShots that are displayed in the gui
    /// </summary>
    /// <param name="shots">shot collection that needs to be filled</param>
    public GrabFrameMethods(ShotCollection shots):base(shots) {
        i = 0;
    }

    public override bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen) {
        //prevent out of range exceptions (a shotCollection might have a fake last shot at position = framecount 
        if (i < shots.getShots().Count - 1) {

            //get frame
            IntPtr temp = Marshal.AllocHGlobal(BufferLen);
            CopyMemory(temp, pBuffer, (uint)BufferLen);
            
            //save bitmap
            shots.getShot(i).setBitmap(new Bitmap(this.videoWidth, this.videoHeight, -m_stride, PixelFormat.Format24bppRgb, (IntPtr)(temp.ToInt32() + BufferLen - m_stride)));

            //next
            i++;
        }

        //alway return false, no new shots are detected here
        return false;
    }
}
