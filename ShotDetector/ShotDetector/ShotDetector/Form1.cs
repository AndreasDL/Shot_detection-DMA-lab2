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

namespace ShotDetector
{
    public partial class ShotDetector : Form{

        private DxPlay m_play;

        public ShotDetector(){
            InitializeComponent();
        }

        private void browseFile(object sender, EventArgs e){
            ofdBrowse.InitialDirectory = "C:\\";
            ofdBrowse.Filter = "video files (*.avi)|*.avi|All files (*.*)|*.*";
            ofdBrowse.FilterIndex = 2;
            ofdBrowse.RestoreDirectory = true;

            if (ofdBrowse.ShowDialog() == DialogResult.OK) {
                MessageBox.Show("hi");
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e){
            Application.Exit();
        }
    }
}
