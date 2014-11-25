using System;
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
    public partial class ShotDetector : Form, IObserver {
        enum State {
            Uninit,
            Stopped,
            Paused,
            Playing
        }
        private State m_State = State.Uninit;
        private DxPlay m_play = null;
        private string fileName = "c:\\testfiles_dma\\csi.avi";
        private DxScan m_scan = null;
        private MethodFactory factory;

        public ShotDetector() {
            InitializeComponent();
            this.factory = new MethodFactory();

        }

        //videofile
        private void browseFile(object sender, EventArgs e) {
            ofdBrowse.InitialDirectory = "C:\\";
            ofdBrowse.Filter = "video files (*.avi)|*.avi|All files (*.*)|*.*";
            ofdBrowse.FilterIndex = 2;
            ofdBrowse.RestoreDirectory = true;

            if (ofdBrowse.ShowDialog() == DialogResult.OK) {
                fileName = ofdBrowse.FileName;
            }
        }
        private void Quit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //Start - Stop - Rewind
        private void start_Click(object sender, EventArgs e) {
            // If necessary, close the old file
            if (m_State == State.Stopped) {
                // Did the filename change?
                if (fileName != m_play.FileName) {
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
                    m_play = new DxPlay(panel1, fileName);
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
                tsmPlay.Text = "Stop";
                m_play.Start();
                btnPause.Enabled = true;
                m_State = State.Playing;
                this.btnPause.Enabled = true;
            }
                // If we are playing or paused, stop
            else if (m_State == State.Playing || m_State == State.Paused) {
                m_play.Stop();
                btnPause.Enabled = false;
                btnStart.Text = "Start";
                tsmPlay.Text = "Start";
                btnPause.Text = "Pause";
                pauseToolStripMenuItem.Text = "Pause";
                m_State = State.Stopped;
                this.btnPause.Enabled = false;
            }
        }
        private void pause_Click(object sender, System.EventArgs e) {
            
            // If we are playing, pause
            if (m_State == State.Playing) {
                m_play.Pause();
                btnPause.Text = "Resume";
                pauseToolStripMenuItem.Text = "Resume";
                m_State = State.Paused;
            }
                // If we are paused, start
            else {
                m_play.Start();
                pauseToolStripMenuItem.Text = "Pause";
                btnPause.Text = "Pause";
                pauseToolStripMenuItem.Text = "Pause";
                m_State = State.Playing;
            }
        }

        // Called when the video is finished playing
        private void m_play_StopPlay(Object sender) {
            // This isn't the right way to do this, but heck, it's only a sample
            CheckForIllegalCrossThreadCalls = false;

            btnPause.Enabled = false;
            btnStart.Text = "Start";
            tsmPlay.Text = "Start";
            btnPause.Text = "Pause";
            pauseToolStripMenuItem.Text = "Pause";

            CheckForIllegalCrossThreadCalls = true;

            m_State = State.Stopped;
        }

        //update gui
        delegate void UpdateGridCallback(Shot shot);
        public void updateList(Shot shot) { 
            //updates the datagrid view
            if (this.dgvResults.InvokeRequired) {
                UpdateGridCallback u = new UpdateGridCallback(updateList);
                this.Invoke(u, new object[] {shot});
            } else {
                dgvResults.Rows.Add(new string[] { "" + dgvResults.RowCount, "" + shot.getStartFrame(), shot.getTagString() });
                dgvResults.FirstDisplayedCell = dgvResults.Rows[dgvResults.Rows.Count -1 ].Cells[0];
            }
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
                        results.setfile(fileName);
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
                        ShotCollection results = this.m_scan.getMethod().getShotCollection();

                        MessageBox.Show("Recall: " + results.calcRecall(truth) + " Precision: " + results.calcPrecision(truth));
                    }).Start();
                }

            } else {
                MessageBox.Show("Video hasn't started yet, press Start to start playing!");
            }
        }

        //sync tags with shotCollection
        private void DataGridChanged(object sender, EventArgs e){
            if (e != null && m_play != null) {
                System.Windows.Forms.DataGridViewCellEventArgs args = (System.Windows.Forms.DataGridViewCellEventArgs)e;

                //update in model
                m_scan.getMethod().getShotCollection().getShot(args.RowIndex).setTagString(Convert.ToString(this.dgvResults.Rows[args.RowIndex].Cells[args.ColumnIndex].Value));
            }
        }

        private void startPixel_Click(object sender, EventArgs e) {

            ShotCollection shots = new ShotCollection();
            shots.addParameter(256);
            shots.addParameter(0.25);
            shots.addObserver(this);

            aShotDetectionMethod method = factory.getMethod(0, shots);

            DxScan scanner = new DxScan(fileName, method);

            var sw = Stopwatch.StartNew();
            scanner.Start();
            scanner.WaitUntilDone();
            sw.Stop();
            long time = sw.ElapsedMilliseconds;
            Console.WriteLine("method took" + time / 1000.0 + "seconds");
        }
    }
}
