/****************************************************************************
While the underlying libraries are covered by LGPL, this sample is released 
as public domain.  It is distributed in the hope that it will be useful, but 
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
or FITNESS FOR A PARTICULAR PURPOSE.  
*****************************************************************************/

// Two very important things to know when using this class:
// 1) Make sure you DxPlay.Dispose before shutting down the app (to avoid hanging)
// 2) Make sure you Marshal.FreeCoTaskMem items returned from DxPlay.SnapShot (to avoid leaking)

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

namespace ShotDetector {
    internal class DxPlay : IDisposable {
        enum GraphState {
            Stopped,
            Paused,
            Running,
            Exiting
        }

        // File name we are playing
        private string m_sFileName;

        // graph builder interfaces
        private IFilterGraph2 m_FilterGraph;
        private IMediaControl m_mediaCtrl;
        private IMediaEvent m_mediaEvent;
        private int m_videoWidth, m_videoHeight, m_stride, m_ImageSize; // Last one is in bytes
        public int m_Count = 0;//frame count
        
        // Event used by Media Event thread
        private ManualResetEvent m_mre;
        // Current state of the graph (can change async)
        volatile private GraphState m_State = GraphState.Stopped;

        private int detectionMethod = 0;
        private aShotDetectionMethod method = null;
        private MethodFactory factory;

        // Event that is called when a clip finishs playing
        public event DxPlayEvent StopPlay;
        public delegate void DxPlayEvent(Object sender);

        // Release everything.
        public void Dispose() {
            CloseInterfaces();
        }
        ~DxPlay() {
            CloseInterfaces();
        }

        // Play an avi file into a window.  Allow for snapshots.
        // (Control to show video in, Avi file to play
        public DxPlay(Control hWin, string FileName, int detectionMethod) {
            factory = new MethodFactory();
            setDetectionMethod(detectionMethod);

            try {
                int hr;
                IntPtr hEvent;

                // Save off the file name
                m_sFileName = FileName;

                // Set up the graph
                SetupGraph(hWin, FileName);

                // Get the event handle the graph will use to signal
                // when events occur
                hr = m_mediaEvent.GetEventHandle(out hEvent);
                DsError.ThrowExceptionForHR(hr);

                // Wrap the graph event with a ManualResetEvent
                m_mre = new ManualResetEvent(false);
#if USING_NET11
                m_mre.Handle = hEvent;
#else
                m_mre.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(hEvent, true);
#endif

                // Create a new thread to wait for events
                Thread t = new Thread(new ThreadStart(this.EventWait));
                t.Name = "Media Event Thread";
                t.Start();
            } catch {
                Dispose();
                throw;
            }
        }

        // Wait for events to happen.  This approach uses waiting on an event handle.
        // The nice thing about doing it this way is that you aren't in the windows message
        // loop, and don't have to worry about re-entrency or taking too long.  Plus, being
        // in a class as we are, we don't have access to the message loop.
        // Alternately, you can receive your events as windows messages.  See
        // IMediaEventEx.SetNotifyWindow.
        private void EventWait() {
            // Returned when GetEvent is called but there are no events
            const int E_ABORT = unchecked((int)0x80004004);

            int hr;
            IntPtr p1, p2;
            EventCode ec;

            do {
                // Wait for an event
                m_mre.WaitOne(-1, true);

                // Avoid contention for m_State
                lock (this) {
                    // If we are not shutting down
                    if (m_State != GraphState.Exiting) {
                        // Read the event
                        for (
                            hr = m_mediaEvent.GetEvent(out ec, out p1, out p2, 0);
                            hr >= 0;
                            hr = m_mediaEvent.GetEvent(out ec, out p1, out p2, 0)
                            ) {
                            // Write the event name to the debug window
                            Debug.WriteLine(ec.ToString());

                            // If the clip is finished playing
                            if (ec == EventCode.Complete) {
                                // Call Stop() to set state
                                Stop();

                                // Throw event
                                if (StopPlay != null) {
                                    StopPlay(this);
                                }
                            }

                            // Release any resources the message allocated
                            hr = m_mediaEvent.FreeEventParams(ec, p1, p2);
                            DsError.ThrowExceptionForHR(hr);
                        }

                        // If the error that exited the loop wasn't due to running out of events
                        if (hr != E_ABORT) {
                            DsError.ThrowExceptionForHR(hr);
                        }
                    } else {
                        // We are shutting down
                        break;
                    }
                }
            } while (true);
        }
        // Return the currently playing file name
        public string FileName {
            get {
                return m_sFileName;
            }
        }
        
        public void setDetectionMethod(int detectionMethod) {
            this.detectionMethod = detectionMethod;
            method = factory.getMethod(detectionMethod);
        }
        // start playing
        public void Start() {
            // If we aren't already playing (or shutting down)
            if (m_State == GraphState.Stopped || m_State == GraphState.Paused) {
                int hr = m_mediaCtrl.Run();
                DsError.ThrowExceptionForHR(hr);

                m_State = GraphState.Running;
            }
        }
        // Pause the capture graph.
        public void Pause() {
            // If we are playing
            if (m_State == GraphState.Running) {
                int hr = m_mediaCtrl.Pause();
                DsError.ThrowExceptionForHR(hr);

                m_State = GraphState.Paused;
            }
        }
        // Pause the capture graph.
        public void Stop() {
            // Can only Stop when playing or paused
            if (m_State == GraphState.Running || m_State == GraphState.Paused) {
                int hr = m_mediaCtrl.Stop();
                DsError.ThrowExceptionForHR(hr);

                m_State = GraphState.Stopped;
            }
        }
        // Reset the clip back to the beginning
        public void Rewind() {
            int hr;

            IMediaPosition imp = m_FilterGraph as IMediaPosition;
            hr = imp.put_CurrentPosition(0);
        }
        
        // Convert a point to the raw pixel data to a .NET bitmap
        public Bitmap IPToBmp(IntPtr ip) {
            // We know the Bits Per Pixel is 24 (3 bytes) because we forced it 
            // to be with sampGrabber.SetMediaType()
            int iBufSize = m_videoWidth * m_videoHeight * 3;

            return new Bitmap(
                m_videoWidth,
                m_videoHeight,
                -m_stride,
                PixelFormat.Format24bppRgb,
                (IntPtr)(ip.ToInt32() + iBufSize - m_stride)
                );
        }

        // Build the capture graph for grabber and renderer.</summary>
        // (Control to show video in, Filename to play)
        private void SetupGraph(Control hWin, string FileName) {
            int hr;

            // Get the graphbuilder object
            m_FilterGraph = new FilterGraph() as IFilterGraph2;

            // Get a ICaptureGraphBuilder2 to help build the graph
            ICaptureGraphBuilder2 icgb2 = new CaptureGraphBuilder2() as ICaptureGraphBuilder2;

            try {
                // Link the ICaptureGraphBuilder2 to the IFilterGraph2
                hr = icgb2.SetFiltergraph(m_FilterGraph);
                DsError.ThrowExceptionForHR(hr);

                // Add the filters necessary to render the file.  This function will
                // work with a number of different file types.
                IBaseFilter sourceFilter = null;
                hr = m_FilterGraph.AddSourceFilter(FileName, FileName, out sourceFilter);
                DsError.ThrowExceptionForHR(hr);

                // Get the SampleGrabber interface
                ISampleGrabber m_sampGrabber = (ISampleGrabber)method;
                IBaseFilter baseGrabFlt = (IBaseFilter)m_sampGrabber;

                // Add it to the filter
                hr = m_FilterGraph.AddFilter(baseGrabFlt, "Ds.NET Grabber");
                DsError.ThrowExceptionForHR(hr);

                // Connect the pieces together, use the default renderer
                hr = icgb2.RenderStream(null, null, sourceFilter, baseGrabFlt, null);
                DsError.ThrowExceptionForHR(hr);

                // Now that the graph is built, read the dimensions of the bitmaps we'll be getting
                SaveSizeInfo(m_sampGrabber);

                // Configure the Video Window
                IVideoWindow videoWindow = m_FilterGraph as IVideoWindow;
                ConfigureVideoWindow(videoWindow, hWin);

                // Grab some other interfaces
                m_mediaEvent = m_FilterGraph as IMediaEvent;
                m_mediaCtrl = m_FilterGraph as IMediaControl;
            } finally {
                if (icgb2 != null) {
                    Marshal.ReleaseComObject(icgb2);
                    icgb2 = null;
                }
            }
#if DEBUG
            // Double check to make sure we aren't releasing something
            // important.
            GC.Collect();
            GC.WaitForPendingFinalizers();
#endif
        }
        // Configure the video window
        private void ConfigureVideoWindow(IVideoWindow videoWindow, Control hWin) {
            int hr;

            // Set the output window
            hr = videoWindow.put_Owner(hWin.Handle);
            DsError.ThrowExceptionForHR(hr);

            // Set the window style
            hr = videoWindow.put_WindowStyle((WindowStyle.Child | WindowStyle.ClipChildren | WindowStyle.ClipSiblings));
            DsError.ThrowExceptionForHR(hr);

            // Make the window visible
            hr = videoWindow.put_Visible(OABool.True);
            DsError.ThrowExceptionForHR(hr);

            // Position the playing location
            Rectangle rc = hWin.ClientRectangle;
            hr = videoWindow.SetWindowPosition(0, 0, rc.Right, rc.Bottom);
            DsError.ThrowExceptionForHR(hr);
        }

        // Save the size parameters for use in SnapShot
        private void SaveSizeInfo(ISampleGrabber sampGrabber) {
            int hr;

            // Get the media type from the SampleGrabber
            AMMediaType media = new AMMediaType();

            hr = sampGrabber.GetConnectedMediaType(media);
            DsError.ThrowExceptionForHR(hr);

            try {

                if ((media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero)) {
                    throw new NotSupportedException("Unknown Grabber Media Format");
                }

                // Get the struct
                VideoInfoHeader videoInfoHeader = new VideoInfoHeader();
                Marshal.PtrToStructure(media.formatPtr, videoInfoHeader);

                // Grab the size info
                m_videoWidth = videoInfoHeader.BmiHeader.Width;
                m_videoHeight = videoInfoHeader.BmiHeader.Height;
                m_stride = videoInfoHeader.BmiHeader.ImageSize / m_videoHeight;
                m_ImageSize = videoInfoHeader.BmiHeader.ImageSize;

                method.setSizes(m_videoHeight, m_videoWidth);

            } finally {
                DsUtils.FreeAMMediaType(media);
                media = null;
            }
        }
        // Shut down capture
        private void CloseInterfaces() {
            int hr;

            lock (this) {
                if (m_State != GraphState.Exiting) {
                    m_State = GraphState.Exiting;

                    // Release the thread (if the thread was started)
                    if (m_mre != null) {
                        m_mre.Set();
                    }
                }

                if (m_mediaCtrl != null) {
                    // Stop the graph
                    hr = m_mediaCtrl.Stop();
                    m_mediaCtrl = null;
                }

                if (method != null) {
                    Marshal.ReleaseComObject(method);
                    method = null;
                }

                if (m_FilterGraph != null) {
                    Marshal.ReleaseComObject(m_FilterGraph);
                    m_FilterGraph = null;
                }
            }
            GC.Collect();
        }

    }
}
