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
using ShotDetector;

public abstract class aShotDetectionMethod: SampleGrabber, ISampleGrabberCB {
    //protected => also accesible from child classes
    protected int videoWidth;  //width of the frame in PIXELS
    protected int videoHeight; //height of the video in PIXELS
    protected int m_stride;    //width of the frame, in BYTES (each pixel has 3 bytes)
    protected ShotCollection shots; //The collected shots
    protected List<IFrameObserver> obs; //the observers that need to be modified
    protected int frameNumber; //the frame number

    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

    /// <summary> Constructor that creates the basic needed elements </summary>
    /// <param name="shots">the shotCollection to save the different shots</param>
    public aShotDetectionMethod(ShotCollection shots): base() {
        this.obs = new List<IFrameObserver>();
        this.frameNumber = 0;

        AMMediaType media;
        int hr;

        // Set the media type to Video/RBG24
        media = new AMMediaType();
        media.majorType = MediaType.Video;
        media.subType = MediaSubType.RGB24;
        media.formatType = FormatType.VideoInfo;
        hr = ((ISampleGrabber)this).SetMediaType(media);
        DsError.ThrowExceptionForHR(hr);

        DsUtils.FreeAMMediaType(media);
        media = null;

        // Configure the samplegrabber
        hr = ((ISampleGrabber)this).SetBufferSamples(true);
        DsError.ThrowExceptionForHR(hr);

        ////////////////////////////////////////////////////
        // Choose to call BufferCB instead of SampleCB
        hr = ((ISampleGrabber)this).SetCallback((ISampleGrabberCB)this, 1);
        DsError.ThrowExceptionForHR(hr);
        ////////////////////////////////////////////////////
        this.shots = shots;
    }

    public void addFrameObserver(IFrameObserver observer) {
        if (observer != null) {
            obs.Add(observer);
        }
    }

    private void notifyObservers() {
        foreach (IFrameObserver observer in obs) {
            observer.updateProgress(frameNumber);
        }
    }
    /// <summary>sample callback, NOT USED.</summary>
    /// <param name="SampleTime">the position of the frame in the video in seconds</param>
    /// <param name="pSample">the sample</param>
    /// <returns>error code if zero then it's all ok</returns>
    int ISampleGrabberCB.SampleCB(double SampleTime, IMediaSample pSample) {
        Marshal.ReleaseComObject(pSample);
        return 0;
    }

    /// <summary> Set the video sizes </summary>
    /// <param name="_videoHeight">the height of the video in PIXELS</param>
    /// <param name="_videoWidth">the width of the video in PIXELS</param>
    public void setSizes(int _videoHeight, int _videoWidth) {
        this.videoHeight = _videoHeight;
        this.videoWidth = _videoWidth;
        this.m_stride = videoWidth * 3;
    }

    /// <Summary>Returns the collected shots</Summary>
    /// <returns>the collected shots</returns>
    public ShotCollection getShotCollection() {
        return this.shots;
    }

    /// <summary> this function is called for each frame </summary>
    /// <param name="SampleTime">the time of the frame (if you want a frame count, then you must count in the method)</param>
    /// <param name="pBuffer">a pointer to the first byte of the image (each pixel has 3 bytes and the frame is m_strade wide so byte[m_stide*5 + 7*3] is the first component of pixel with y=5, x = 7</param>
    /// <param name="bufferLen>number of bytes in pBuffer</param>
    /// <returns>error code if zero then it's all ok</returns>
    public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen){
        //call the method
        if (DetectShot(SampleTime, pBuffer, BufferLen)) {

            IntPtr temp = Marshal.AllocHGlobal(BufferLen);
            CopyMemory(temp,pBuffer, (uint)BufferLen);

            Bitmap frameShot = new Bitmap(
                this.videoWidth, this.videoHeight, -m_stride, PixelFormat.Format24bppRgb, 
                (IntPtr)(temp.ToInt32() + BufferLen - m_stride) 
            );

            Shot s = new Shot(frameNumber, shots.getShots().Count, frameShot);
            shots.addShot(s);
        }

        frameNumber++; //keep track of frame number
        if (frameNumber % 200 ==0) //don't do this for everyframe (causes huge overhead)
            notifyObservers();
        return 0;
    }

    /// <summary>Put the detection code in this method, the method above is used to keep track of the framenumber and update the gui </summary>
    /// <param name="SampleTime">the time of the frame (if you want a frame count, then you must count in the method)</param>
    /// <param name="pBuffer">a pointer to the first byte of the image (each pixel has 3 bytes and the frame is m_strade wide so byte[m_stide*5 + 7*3] is the first component of pixel with y=5, x = 7</param>
    /// <param name="BufferLen">number of bytes in pBuffer</param>
    /// <returns></returns>
    public abstract bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen);

}