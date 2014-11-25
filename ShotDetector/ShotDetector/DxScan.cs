/****************************************************************************
While the underlying libraries are covered by LGPL, this sample is released 
as public domain.  It is distributed in the hope that it will be useful, but 
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
or FITNESS FOR A PARTICULAR PURPOSE.  
*****************************************************************************/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

using DirectShowLib;
using System.Windows.Forms;

namespace ShotDetector {
    internal class DxScan: IDisposable {

        /// <summary> graph builder interface. </summary>
        private IFilterGraph2 m_FilterGraph = null;
        private IMediaControl m_mediaCtrl = null;
        private IMediaEvent m_MediaEvent = null;

        /// <summary> Dimensions of the image, calculated once in constructor. </summary>
        private int m_videoWidth;
        private int m_videoHeight;
        private int m_stride;
        private aShotDetectionMethod method = null;

        /// <summary> File name to scan</summary>
        public DxScan(string fileName, aShotDetectionMethod method){
            this.method = method;

            try {
                // Set up the capture graph
                SetupGraph(fileName);
            } catch {
                Dispose();
                throw;
            }

        }

        /// <summary> release everything. </summary>
        public void Dispose() {
            CloseInterfaces();
        }
        // Destructor
        ~DxScan() {
            CloseInterfaces();
        }


        /// <summary> capture the next image </summary>
        public void Start() {
            int hr = m_mediaCtrl.Run();
            DsError.ThrowExceptionForHR(hr);
        }


        public void WaitUntilDone() {
            int hr;
            EventCode evCode;
            const int E_Abort = unchecked((int)0x80004004);

            do {
                System.Windows.Forms.Application.DoEvents();
                hr = this.m_MediaEvent.WaitForCompletion(100, out evCode);
            } while (hr == E_Abort);
            DsError.ThrowExceptionForHR(hr);
        }

        /// <summary> build the capture graph for grabber. </summary>
        private void SetupGraph(string FileName) {
            int hr;

            ISampleGrabber sampGrabber = null;
            IBaseFilter baseGrabFlt = null;
            IBaseFilter capFilter = null;
            IBaseFilter nullrenderer = null;

            // Get the graphbuilder object
            m_FilterGraph = new FilterGraph() as IFilterGraph2;
            m_mediaCtrl = m_FilterGraph as IMediaControl;
            m_MediaEvent = m_FilterGraph as IMediaEvent;

            IMediaFilter mediaFilt = m_FilterGraph as IMediaFilter;

            try {
                // Add the video source
                hr = m_FilterGraph.AddSourceFilter(FileName, "Ds.NET FileFilter", out capFilter);
                DsError.ThrowExceptionForHR(hr);

                // Get the SampleGrabber interface
                sampGrabber = /*new SampleGrabber() as ISampleGrabber;/*/ (ISampleGrabber)method;
                baseGrabFlt = sampGrabber as IBaseFilter;

                ConfigureSampleGrabber(sampGrabber);

                // Add the frame grabber to the graph
                hr = m_FilterGraph.AddFilter(baseGrabFlt, "Ds.NET Grabber");
                DsError.ThrowExceptionForHR(hr);

                // ---------------------------------
                // Connect the file filter to the sample grabber

                // Hopefully this will be the video pin, we could check by reading it's mediatype
                IPin iPinOut = DsFindPin.ByDirection(capFilter, PinDirection.Output, 0);

                // Get the input pin from the sample grabber
                IPin iPinIn = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Input, 0);

                hr = m_FilterGraph.Connect(iPinOut, iPinIn);
                DsError.ThrowExceptionForHR(hr);

                // Add the null renderer to the graph
                nullrenderer = new NullRenderer() as IBaseFilter;
                hr = m_FilterGraph.AddFilter(nullrenderer, "Null renderer");
                DsError.ThrowExceptionForHR(hr);

                // ---------------------------------
                // Connect the sample grabber to the null renderer

                iPinOut = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Output, 0);
                iPinIn = DsFindPin.ByDirection(nullrenderer, PinDirection.Input, 0);

                hr = m_FilterGraph.Connect(iPinOut, iPinIn);
                DsError.ThrowExceptionForHR(hr);

                // Turn off the clock.  This causes the frames to be sent
                // thru the graph as fast as possible
                hr = mediaFilt.SetSyncSource(null);
                DsError.ThrowExceptionForHR(hr);

                // Read and cache the image sizes
                SaveSizeInfo(sampGrabber);
            } finally {
                if (capFilter != null) {
                    Marshal.ReleaseComObject(capFilter);
                    capFilter = null;
                }
                if (nullrenderer != null) {
                    Marshal.ReleaseComObject(nullrenderer);
                    nullrenderer = null;
                }
            }
        }

        /// <summary> Read and store the properties </summary>
        private void SaveSizeInfo(ISampleGrabber sampGrabber) {
            int hr;

            // Get the media type from the SampleGrabber
            AMMediaType media = new AMMediaType();
            hr = sampGrabber.GetConnectedMediaType(media);
            DsError.ThrowExceptionForHR(hr);

            if ((media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero)) {
                throw new NotSupportedException("Unknown Grabber Media Format");
            }

            // Grab the size info
            VideoInfoHeader videoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(media.formatPtr, typeof(VideoInfoHeader));
            m_videoWidth = videoInfoHeader.BmiHeader.Width;
            m_videoHeight = videoInfoHeader.BmiHeader.Height;
            m_stride = m_videoWidth * (videoInfoHeader.BmiHeader.BitCount / 8);

            method.setSizes(m_videoHeight, m_videoWidth);

            DsUtils.FreeAMMediaType(media);
            media = null;
        }

        /// <summary> Set the options on the sample grabber </summary>
        private void ConfigureSampleGrabber(ISampleGrabber sampGrabber) {
            AMMediaType media;
            int hr;

            // Set the media type to Video/RBG24
            media = new AMMediaType();
            media.majorType = MediaType.Video;
            media.subType = MediaSubType.RGB24;
            media.formatType = FormatType.VideoInfo;
            hr = sampGrabber.SetMediaType(media);
            DsError.ThrowExceptionForHR(hr);

            DsUtils.FreeAMMediaType(media);
            media = null;

            // Choose to call BufferCB instead of SampleCB
            hr = sampGrabber.SetCallback(method, 1);
            DsError.ThrowExceptionForHR(hr);
        }

        /// <summary> Shut down capture </summary>
        private void CloseInterfaces() {
            int hr;

            try {
                if (m_mediaCtrl != null) {
                    // Stop the graph
                    hr = m_mediaCtrl.Stop();
                    m_mediaCtrl = null;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex);
            }

            if (m_FilterGraph != null) {
                Marshal.ReleaseComObject(m_FilterGraph);
                m_FilterGraph = null;
            }
            GC.Collect();

            if (method != null) {
                Marshal.ReleaseComObject(method);
                method = null;
            }
        }

        public long getFrameCount() {
            IMediaSeeking ims = m_FilterGraph as IMediaSeeking;
            ims.SetTimeFormat(TimeFormat.Frame);
            long duration;
            ims.GetDuration(out duration);
            return duration;
        }

        public aShotDetectionMethod getMethod(){
            return this.method;
        }
    }
}
