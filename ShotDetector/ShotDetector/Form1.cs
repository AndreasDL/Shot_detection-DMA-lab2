﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShotDetector {
    public partial class ShotDetector : Form, IShotObserver, IFrameObserver {
        enum State {
            Uninit,
            Stopped,
            Paused,
            Playing
        }
        private State m_State = State.Uninit;
        private DxPlay m_play;
        private DxScan m_scan;

        private string videoFileName;
        private MethodFactory factory;
        private ShotCollection results;
        private long frameCount;
        private int currRow;
        private Thread searchTread;

        public ShotDetector() {
            InitializeComponent();
            this.factory = new MethodFactory();
            for (int i = 1 ; i <= 20 ; i++){
                this.cmbLocalHistNrOfBlocks.Items.Add(i * i);
            }
            cmbLocalHistNrOfBlocks.SelectedIndex = 2;
            this.frameCount = 0;
            this.tabControl1.SelectedIndex = 1;
            this.results = null;
            this.m_play = null;
            this.m_scan = null;
            this.videoFileName = "";
            this.currRow = -1; //selected row in dgvResults
        }

        //videofile
        private void browseFile(object sender, EventArgs e) {
            ofdBrowse.InitialDirectory = "C:\\";
            ofdBrowse.Filter = "video files (*.avi)|*.avi|All files (*.*)|*.*";
            ofdBrowse.FilterIndex = 2;
            ofdBrowse.RestoreDirectory = true;

            if (ofdBrowse.ShowDialog() == DialogResult.OK) {
                videoFileName = ofdBrowse.FileName;
                dgvResults.Rows.Clear();
                btnStart.Enabled = true;

                btnStartPixel.Enabled = true;
                btnStartMotion.Enabled = true;
                btnStartLocalHistogram.Enabled = true;
                btnStartGlobalHist.Enabled = true;

                start_Click(sender, e);
            }
        }
        private void Quit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //Start - Stop - Rewind
        private void start_Click(object sender, EventArgs e) {
            if (videoFileName == "") {
                browseFile(sender, e);//will start the playing
                //start_Click(sender, e);
            } else { 
           
                // If necessary, close the old file
                if (m_State == State.Stopped) {
                    // Did the filename change?
                    if (videoFileName != m_play.FileName) {
                        // File name changed, close the old file
                        m_play.Dispose();
                        m_play = null;
                        m_State = State.Uninit;
                    }
                }

                // If we have no file open
                if (m_play == null) {
                    try {
                        // Open the file, provide a handle to play it in
                        m_play = new DxPlay(panel1, videoFileName);
                        // Let us know when the file is finished playing
                        m_play.StopPlay += new DxPlay.DxPlayEvent(m_play_StopPlay);
                        m_State = State.Stopped;
                    } catch (COMException ce) {
                        MessageBox.Show("Failed to open file: " + ce.Message, "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // If we were stopped, start
                if (m_State == State.Stopped) {
                    btnStart.Text = "Stop";
                    //m_play.Start();
                    m_play.playShot(0, m_play.getFrameCount());
                    btnPause.Enabled = true;
                    m_State = State.Playing;
                }
                    // If we are playing or paused, stop
                else if (m_State == State.Playing || m_State == State.Paused) {
                    m_play.Stop();
                    btnPause.Enabled = false;
                    btnStart.Text = "Start";
                    btnPause.Text = "Pause";
                    m_State = State.Stopped;
                    this.btnPause.Enabled = false;
                }
            }

        }
        private void pause_Click(object sender, System.EventArgs e) {
            
            // If we are playing, pause
            if (m_State == State.Playing) {
                m_play.Pause();
                btnPause.Text = "Resume";
                m_State = State.Paused;
            }
                // If we are paused, start
            else {
                m_play.Start();
                btnPause.Text = "Pause";
                m_State = State.Playing;
            }
        }
        // Called when the video is finished playing
        private void m_play_StopPlay(Object sender) {
            // This isn't the right way to do this, but heck, it's only a sample
            CheckForIllegalCrossThreadCalls = false;

            btnPause.Enabled = false;
            btnStart.Text = "Start";
            btnPause.Text = "Pause";

            CheckForIllegalCrossThreadCalls = true;

            m_State = State.Stopped;
        }

        //export
        private void exportXML(object sender, EventArgs e) {
            String outputPath = "C:\\test.xml";

            if (this.m_play != null) {
                sfdBrowse.InitialDirectory = "C:\\";
                sfdBrowse.Filter = "xml document (*.xml)|*.xml";
                sfdBrowse.FilterIndex = 2;
                sfdBrowse.RestoreDirectory = true;
                sfdBrowse.Title = "Save as";

                if (sfdBrowse.ShowDialog() == DialogResult.OK) {
                    outputPath = sfdBrowse.FileName;
                    new Thread(() => { //thread = no lagg on GUI
                        Thread.CurrentThread.IsBackground = true;
                        ShotCollection results = this.m_scan.getMethod().getShotCollection();

                        results.setLastFrame(this.m_scan.getFrameCount());
                        results.setfile(outputPath);
                        results.setLastFrame(m_play.getFrameCount());

                        results.export(outputPath);

                    }).Start();
                }
            } else {
                MessageBox.Show("Video hasn't started yet, press Start to start playing!");
            }
        }
        //ground truth
        private void calcRecallandPrecision(object sender, EventArgs e) {
            String groundTruthPath = "C:\\testfiles_dma\\csi_GT.xml";

            if (this.m_play != null) {
                ofdBrowse.InitialDirectory = "C:\\";
                ofdBrowse.Filter = "video files (*.avi)|*.avi|All files (*.*)|*.*";
                ofdBrowse.FilterIndex = 2;
                ofdBrowse.RestoreDirectory = true;
                ofdBrowse.Title = "Open a ground Truth file (.xml)";

                if (ofdBrowse.ShowDialog() == DialogResult.OK) {
                    groundTruthPath = ofdBrowse.FileName;
                    new Thread(() => { //thread : no lagg on GUI
                        Thread.CurrentThread.IsBackground = true;
                        //get groundtruth
                        ShotCollection truth = new ShotCollection(groundTruthPath);
                        ShotCollection results = this.results;// this.m_scan.getMethod().getShotCollection();

                        MessageBox.Show("Recall: " + results.calcRecall(truth) + " Precision: " + results.calcPrecision(truth));
                    }).Start();
                }

            } else {
                MessageBox.Show("Video hasn't started yet, press Start to start playing!");
            }
        }

        //start methods
        private void startPixel_Click(object sender, EventArgs e) {
            int distance = Convert.ToInt32(txtPixelDistance.Text);
            double fraction = Convert.ToDouble(txtPixelFraction.Text);

            if (distance > 0 && distance <= 768 && fraction > 0 && fraction <= 1) {
                ShotCollection shots = new ShotCollection();
                shots.addObserver(this);//make sure the datagridview gets updated
                DxScan scanner = new DxScan(videoFileName, factory.getPixelMethod(shots,this, distance, fraction));

                RunMethod(scanner , "Pixel");
            } else {
                MessageBox.Show("Please check your input parameters");
            }
        }
        private void startMotion_Click(object sender, EventArgs e) {
            int subsize = Convert.ToInt32(txtMotionSubSize.Text);
            int windowsize = Convert.ToInt32(txtMotionWindowSize.Text);

            if (subsize >= 1 && subsize <= 32 && windowsize >= 1 && windowsize <= 4) {
                ShotCollection shots = new ShotCollection();
                shots.addObserver(this);//make sure the datagridview gets updated
                DxScan scanner = new DxScan(videoFileName, factory.getMotionMethod(shots,this, subsize, windowsize));

                RunMethod(scanner, "Motion");
            } else {
                MessageBox.Show("Please check your input parameters");
            }
        }
        private void startGlobalHist_Click(object sender, EventArgs e) {
            int binCount = Convert.ToInt32(txtGlobalBinCount.Text);
            double fraction = Convert.ToDouble(txtGlobalFraction.Text);

            if (binCount > 0 && binCount <= 256 && fraction > 0 && fraction <= 1) {
                ShotCollection shots = new ShotCollection();
                shots.addObserver(this);//make sure the datagridview gets updated
                DxScan scanner = new DxScan(videoFileName, factory.getGlobalHistogramMethod(shots,this, binCount, fraction));

                RunMethod(scanner, "Global Histogram");
            } else {
                MessageBox.Show("Please check your input parameters");
            }
        }
        private void StartLocalHistogram_Click(object sender, EventArgs e) {
            int binCount = Convert.ToInt32(txtGlobalBinCount.Text);
            double fraction = Convert.ToDouble(txtGlobalFraction.Text);

            if (binCount > 0 && binCount <= 256 && fraction > 0 && fraction <= 1) {
                //always right, since it comes from combobox
                int nrOfBlocks = Convert.ToInt32(cmbLocalHistNrOfBlocks.SelectedIndex) + 1;
                nrOfBlocks *= nrOfBlocks;

                ShotCollection shots = new ShotCollection();
                shots.addObserver(this);//make sure the datagridview gets updated
                DxScan scanner = new DxScan(videoFileName, factory.getLocalHistogramMethod(shots,this, binCount, fraction, nrOfBlocks));

                RunMethod(scanner, "Local Histogram");
            } else {
                MessageBox.Show("Please check your input parameters");
            }
        }

        private void RunMethod(DxScan scanner,String methodName) {
            if ( this.results == null 
                || MessageBox.Show("Running this method will clear the results. Are you sure you cant to continue ?", "Are you sure", MessageBoxButtons.YesNoCancel) == DialogResult.Yes ) {

                //disable other start buttons
                btnStartGlobalHist.Enabled = false;
                btnStartLocalHistogram.Enabled = false;
                btnStartMotion.Enabled = false;
                btnStartPixel.Enabled = false;
                openToolStripMenuItem.Enabled = false;
                btnCalc.Enabled = false;
                btnExport.Enabled = false;

                //cleanup
                dgvResults.Rows.Clear();
                this.results = new ShotCollection(); //temp used while video is playing

                //notify user
                this.toolStripStatusLabel1.Text = "Shot Detection (" + methodName + ") Running ...";
                this.frameCount = scanner.getFrameCount();
                this.toolStripProgressBar1.Value = 0;
                this.toolStripProgressBar1.Visible = true;
                tabControl1.SelectedIndex = 0; //show annotations

                //run
                var sw = Stopwatch.StartNew();

                //start detection
                scanner.Start();

                //wait for completion
                scanner.WaitUntilDone();
                this.results = scanner.getMethod().getShotCollection();//replaced with this one , which also contains the parameters

                //feedback
                sw.Stop();
                long time = sw.ElapsedMilliseconds;
                this.toolStripStatusLabel1.Text = methodName + " Shot Detection Completed in " + time / 1000.0 + " seconds";
                this.toolStripProgressBar1.Visible = false;

                //enable other buttons
                btnStartPixel.Enabled = true;
                btnStartMotion.Enabled = true;
                btnStartLocalHistogram.Enabled = true;
                btnStartGlobalHist.Enabled = true;
                openToolStripMenuItem.Enabled = true;
                calculateRecallToolStripMenuItem.Enabled = true;
                exportResultToXmlToolStripMenuItem.Enabled = true;
                btnCalc.Enabled = true;
                btnExport.Enabled = true;
            
            }
        }
        //progressbar
        delegate void ProgressCallback(long frameNumber);
        public void updateProgress(long frameNumber) {
            if (this.dgvResults.InvokeRequired) {
                ProgressCallback pcb = new ProgressCallback(updateProgress);
                this.Invoke(pcb, new object[] { frameNumber });
            } else {
                this.toolStripProgressBar1.Value = Convert.ToInt32(100 * frameNumber / frameCount);
            }
        }

        //datagrids
        private void cellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            long startFrame =(long)(Convert.ToInt32(dgvResults.Rows[e.RowIndex].Cells[1].Value));//startframe
            long stopFrame = m_play.getFrameCount();
            if (dgvResults.Rows.Count > e.RowIndex +1 ) {//if stopframe is determined
                stopFrame = (long)(Convert.ToInt32(dgvResults.Rows[e.RowIndex + 1].Cells[1].Value)) - 1;
            }

            Console.WriteLine("Click in " + e.RowIndex + " as row! shot starts at: " + startFrame);
            if (m_play == null) {
                try {
                    // Open the file, provide a handle to play it in
                    m_play = new DxPlay(panel1, videoFileName);
                    // Let us know when the file is finished playing
                    m_play.StopPlay += new DxPlay.DxPlayEvent(m_play_StopPlay);
                    m_State = State.Stopped;
                } catch (COMException ce) {
                    MessageBox.Show("Failed to open file: " + ce.Message, "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            m_State = State.Playing;
            btnStart.Text = "Stop";
            m_play.playShot(startFrame, stopFrame);
            btnPause.Enabled = true;
            m_State = State.Stopped;
        }
        private void resultSelectedIndexChanged(object sender, EventArgs e) {
            int newRow = this.dgvResults.CurrentRow.Index;

            if (newRow != this.currRow) {//only if the row changed
                Shot s = this.results.getShot(newRow);

                //update the picture
                this.pictureBox1.Image = new Bitmap(s.getFrameShot(),new Size(this.pictureBox1.Width,this.pictureBox1.Height));

                this.currRow = newRow;
            }
        }
        private void searchTag(object sender, EventArgs e) {
            
            if (this.results != null) {
                String tag = txtSearch.Text;
                if (tag != "") {
                    //searchTread = new Thread(() => {
                        dgvResults.Rows.Clear();
                        updateSearch(results.searchShots(tag));
                    //});
                    //searchTread.Start();
                } else {
                    /*if (searchTread != null) {
                        searchTread.Abort();
                        searchTread = null;
                    }*/
                    foreach (Shot shot in this.results.getShots()) {
                        dgvResults.Rows.Add(new string[] { "" + dgvResults.RowCount, "" + shot.getStartFrame(), shot.getTagString() });
                    }
                    dgvResults.FirstDisplayedCell = dgvResults.Rows[dgvResults.Rows.Count - 1].Cells[0];
                }
            }
        }
        //update gui
        delegate void UpdateGridCallback(Shot shot);
        public void updateList(Shot shot) {
            //updates the datagrid view
            if (this.dgvResults.InvokeRequired) {
                UpdateGridCallback u = new UpdateGridCallback(updateList);
                this.Invoke(u, new object[] { shot });
            } else {
                this.results.addShot(shot);
                dgvResults.Rows.Add(new string[] { "" + dgvResults.RowCount, "" + shot.getStartFrame(), shot.getTagString() });
                dgvResults.FirstDisplayedCell = dgvResults.Rows[dgvResults.Rows.Count - 1].Cells[0];
            }
        }
        //get search results in gui
        delegate void UpdateSearchCallback(List<Shot> shots);
        public void updateSearch(List<Shot> shots) {
            //updates the datagrid view
            if (this.dgvResults.InvokeRequired) {
                UpdateSearchCallback u = new UpdateSearchCallback(updateSearch);
                this.Invoke(u, new object[] { shots });
            } else {
                foreach (Shot shot in shots) {
                    dgvResults.Rows.Add(new string[] { "" + dgvResults.RowCount, "" + shot.getStartFrame(), shot.getTagString() });
                }
                if (dgvResults.Rows.Count > 0) {
                    dgvResults.FirstDisplayedCell = dgvResults.Rows[dgvResults.Rows.Count - 1].Cells[0];
                }
            }
        }
        //sync tags with shotCollection
        private void DataGridChanged(object sender, EventArgs e) {
            if (e != null && this.results != null) {
                System.Windows.Forms.DataGridViewCellEventArgs args = (System.Windows.Forms.DataGridViewCellEventArgs)e;

                //update in model
                this.results.getShot(args.RowIndex).setTagString(Convert.ToString(this.dgvResults.Rows[args.RowIndex].Cells[args.ColumnIndex].Value));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            String outputPath = "";
            sfdBrowse.InitialDirectory = "C:\\";
            sfdBrowse.Filter = "bitmap (*.bmp)|*.bmp";
            sfdBrowse.FilterIndex = 2;
            sfdBrowse.RestoreDirectory = true;
            sfdBrowse.Title = "Save as";

            if (sfdBrowse.ShowDialog() == DialogResult.OK) {
                outputPath = sfdBrowse.FileName;

                new Thread(() => { //thread = no lagg on GUI
                    Thread.CurrentThread.IsBackground = true;
                    results.getShot(this.dgvResults.CurrentRow.Index).getFrameShot().Save(outputPath);
                }).Start();

            }

        }

    }
}
