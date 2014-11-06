using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ShotDetector {
    public partial class ShotDetector : Form {
        enum State {
            Uninit,
            Stopped,
            Paused,
            Playing
        }
        State m_State = State.Uninit;
        DxPlay m_play = null;

        public ShotDetector() {
            InitializeComponent();
            this.cmbMethod.Items.AddRange(MethodFactory.METHODS ); //set the detection methods
            cmbMethod.SelectedIndex = 1;
        }

        private void browseFile(object sender, EventArgs e) {
            ofdBrowse.InitialDirectory = "C:\\";
            ofdBrowse.Filter = "video files (*.avi)|*.avi|All files (*.*)|*.*";
            ofdBrowse.FilterIndex = 2;
            ofdBrowse.RestoreDirectory = true;

            if (ofdBrowse.ShowDialog() == DialogResult.OK) {
                txtFileName.Text = ofdBrowse.FileName;
            }
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void start_Click(object sender, EventArgs e) {
            // If necessary, close the old file
            if (m_State == State.Stopped) {
                // Did the filename change?
                if (txtFileName.Text != m_play.FileName) {
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
                    m_play = new DxPlay(panel1, txtFileName.Text, cmbMethod.SelectedIndex);
                    //m_play.setDetectionMethod(cmbMethod.SelectedIndex);

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
                playToolStripMenuItem1.Text = "Stop";
                m_play.Start();
                btnPause.Enabled = true;
                txtFileName.Enabled = false;
                m_State = State.Playing;
            }
                // If we are playing or paused, stop
            else if (m_State == State.Playing || m_State == State.Paused) {
                m_play.Stop();
                btnPause.Enabled = false;
                txtFileName.Enabled = true;
                btnStart.Text = "Start";
                playToolStripMenuItem1.Text = "Start";
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

        // Called when the video is finished playing
        private void m_play_StopPlay(Object sender) {
            // This isn't the right way to do this, but heck, it's only a sample
            CheckForIllegalCrossThreadCalls = false;

            btnPause.Enabled = false;
            txtFileName.Enabled = true;
            btnStart.Text = "Start";
            playToolStripMenuItem1.Text = "Start";
            btnPause.Text = "Pause";
            pauseToolStripMenuItem.Text = "Pause";

            CheckForIllegalCrossThreadCalls = true;

            m_State = State.Stopped;

            // Rewind clip to beginning to allow DxPlay.Start to work again.
            m_play.Rewind();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
