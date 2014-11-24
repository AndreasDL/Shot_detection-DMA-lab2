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

namespace ShotDetector {
    public partial class ShotDetector : Form, IObserver {
        enum State {
            Uninit,
            Stopped,
            Paused,
            Playing
        }
        State m_State = State.Uninit;
        DxPlay m_play = null;
        private string fileName = "c:\\testfiles_dma\\csi.avi";

        public ShotDetector() {
            InitializeComponent();
            this.cmbMethod.Items.AddRange(MethodFactory.METHODS ); //set the detection methods
            cmbMethod.SelectedIndex = 1; //default = motion
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
                    m_play = new DxPlay(panel1, fileName, cmbMethod.SelectedIndex, this);
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
        private void rewind_Click(object sender, System.EventArgs e) {
            if (m_play != null) {
                m_play.Rewind();
                dgvResults.Rows.Clear();
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

            // Rewind clip to beginning to allow DxPlay.Start to work again.
            //m_play.Rewind(); //doesn't work

            MessageBox.Show("Method took: " + m_play.getCurrentShotDetectionMethod().getTime() + " ms");
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
        //update model
        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e) {
            if (m_play != null) {
                m_play.setDetectionMethod(cmbMethod.SelectedIndex);
            }

            //TODO event listeners
            this.argPanel.Controls.Clear();
            int locX = 0;
            String[][] args = MethodFactory.METHODINFO[cmbMethod.SelectedIndex];
            foreach (String[] arg in args) {
                //label
                Label argName = new Label();
                argName.Text = arg[0];
                argName.AutoSize = true;
                argName.Location = new Point(locX,3);
                argName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.argPanel.Controls.Add(argName);
                locX += argName.Size.Width;
                
                if (arg.Length > 1) {
                    ToolTip tipz = new ToolTip();
                    tipz.SetToolTip(argName, arg[1]);

                    //textz
                    TextBox value = new TextBox();
                    value.Text = "   ";
                    value.Location = new Point(locX, 0);
                    value.Size = new Size(35, value.Size.Height);
                    value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                    this.argPanel.Controls.Add(value);
                    locX += value.Size.Width;
                }

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
                        ShotCollection results = this.m_play.getShotCollection();

                        results.setLastFrame(this.m_play.getFrameCount());
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
                        ShotCollection results = this.m_play.getShotCollection();

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
                //Console.WriteLine("something changed at " + args.ColumnIndex + " " + args.RowIndex);
                //update in model
                m_play.getShotCollection().getShot(args.RowIndex).setTagString(Convert.ToString(this.dgvResults.Rows[args.RowIndex].Cells[args.ColumnIndex].Value));
            }
        }
    }
}
