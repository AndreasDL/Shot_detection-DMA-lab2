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

public abstract class aShotDetectionMethod: SampleGrabber, ISampleGrabberCB {
    //protected => also accesible from child classes
    protected int videoWidth; //width of the frame in PIXELS
    protected int videoHeight;//height of the video in PIXELS
    protected int m_stride;//width of the frame, in BYTES (each pixel has 3 bytes)
    protected ShotCollection shots;
    protected List<IObserver> observers;
    protected int frameNumber;

    public aShotDetectionMethod(ShotCollection shots): base() {
        this.observers = new List<IObserver>();
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
    // sample callback, NOT USED.
    int ISampleGrabberCB.SampleCB(double SampleTime, IMediaSample pSample) {
        Marshal.ReleaseComObject(pSample);
        return 0;
    }

    public void setSizes(int _videoHeight, int _videoWidth) {
        this.videoHeight = _videoHeight;
        this.videoWidth = _videoWidth;
        this.m_stride = videoWidth * 3;
    }

    /*this method is called when a shot is detected
     * sampleTime: the time of the shot
     * frameNumber: number of the first frame from the shot
    */
    private void shotDetected(double sampleTime, int frameNumber) {
        shots.addShot(new Shot(frameNumber, sampleTime));
    }

    public ShotCollection getShotCollection() {
        return this.shots;
    }

    public void addObserver(IObserver observer) {
        observers.Add(observer);
    }
    private void notifyObservers() {
        foreach (IObserver o in observers)
            o.updateTrackbar(frameNumber);
    }

    /* this function is called for each frame
     * SampleTime: the time of the frame (if you want a frame count, then you must count in the method)
     * pBuffer: a pointer to the first byte of the image (each pixel has 3 bytes and the frame is m_strade wide so byte[m_stide*5 + 7*3] is the first component of pixel with y=5, x = 7
     * bufferLen: number of bytes in pBuffer
    */
    public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen){
        
        //call the method
        if (DetectShot(SampleTime, pBuffer, BufferLen))
            shotDetected(SampleTime,frameNumber);

        frameNumber++; //keep track of frame number
        notifyObservers(); //notify observers (e.g. update the trackbar of the gui)
        return 0;
    }

    /*
     * Put the detection code in this method, the method above is used to keep track of the framenumber and update the gui
     * SampleTime: the time of the frame (if you want a frame count, then you must count in the method)
     * pBuffer: a pointer to the first byte of the image (each pixel has 3 bytes and the frame is m_strade wide so byte[m_stide*5 + 7*3] is the first component of pixel with y=5, x = 7
     * bufferLen: number of bytes in pBuffer
     */
    public abstract bool DetectShot(double SampleTime, IntPtr pBuffer, int BufferLen);

}