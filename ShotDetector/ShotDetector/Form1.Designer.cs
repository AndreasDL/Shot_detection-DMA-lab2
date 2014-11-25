namespace ShotDetector
{
    partial class ShotDetector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.mnMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportResultToXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateRecallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.sfdBrowse = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.annotations = new System.Windows.Forms.TabPage();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.shotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartFrame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pixel = new System.Windows.Forms.TabPage();
            this.txtPixelFraction = new System.Windows.Forms.MaskedTextBox();
            this.txtPixelDistance = new System.Windows.Forms.MaskedTextBox();
            this.startPixel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.motion = new System.Windows.Forms.TabPage();
            this.txtMotionWindowSize = new System.Windows.Forms.MaskedTextBox();
            this.txtMotionSubSize = new System.Windows.Forms.MaskedTextBox();
            this.btnStartMotion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.global = new System.Windows.Forms.TabPage();
            this.txtGlobalFraction = new System.Windows.Forms.MaskedTextBox();
            this.txtGlobalBinCount = new System.Windows.Forms.MaskedTextBox();
            this.btnStartGlobalHist = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.local = new System.Windows.Forms.TabPage();
            this.cmbLocalHistNrOfBlocks = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtLocalHistFraction = new System.Windows.Forms.MaskedTextBox();
            this.txtLocalHistBinCount = new System.Windows.Forms.MaskedTextBox();
            this.btnStartLocalHistogram = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.general = new System.Windows.Forms.TabPage();
            this.Shots = new System.Windows.Forms.TabPage();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.mnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.annotations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.pixel.SuspendLayout();
            this.motion.SuspendLayout();
            this.global.SuspendLayout();
            this.local.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdBrowse
            // 
            this.ofdBrowse.FileName = "csi.avi";
            this.ofdBrowse.RestoreDirectory = true;
            this.ofdBrowse.Title = "Open a video file";
            // 
            // mnMenu
            // 
            this.mnMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.playToolStripMenuItem});
            this.mnMenu.Location = new System.Drawing.Point(0, 0);
            this.mnMenu.Name = "mnMenu";
            this.mnMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mnMenu.Size = new System.Drawing.Size(1045, 28);
            this.mnMenu.TabIndex = 3;
            this.mnMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportResultToXmlToolStripMenuItem,
            this.calculateRecallToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(275, 24);
            this.openToolStripMenuItem.Text = "Open Video File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.browseFile);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(272, 6);
            // 
            // exportResultToXmlToolStripMenuItem
            // 
            this.exportResultToXmlToolStripMenuItem.Name = "exportResultToXmlToolStripMenuItem";
            this.exportResultToXmlToolStripMenuItem.Size = new System.Drawing.Size(275, 24);
            this.exportResultToXmlToolStripMenuItem.Text = "Export Results to xml";
            this.exportResultToXmlToolStripMenuItem.Click += new System.EventHandler(this.exportXML);
            // 
            // calculateRecallToolStripMenuItem
            // 
            this.calculateRecallToolStripMenuItem.Name = "calculateRecallToolStripMenuItem";
            this.calculateRecallToolStripMenuItem.Size = new System.Drawing.Size(275, 24);
            this.calculateRecallToolStripMenuItem.Text = "Calculate Precision and Recall";
            this.calculateRecallToolStripMenuItem.Click += new System.EventHandler(this.calcRecallandPrecision);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(272, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(275, 24);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.Quit_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPlay,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.playToolStripMenuItem.Text = "Play";
            // 
            // tsmPlay
            // 
            this.tsmPlay.Name = "tsmPlay";
            this.tsmPlay.Size = new System.Drawing.Size(116, 24);
            this.tsmPlay.Text = "Play";
            this.tsmPlay.Click += new System.EventHandler(this.start_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pause_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 447);
            this.panel1.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(4, 459);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.start_Click);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(112, 459);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 28);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.pause_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 42);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnStart);
            this.splitContainer1.Panel1.Controls.Add(this.btnPause);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2MinSize = 70;
            this.splitContainer1.Size = new System.Drawing.Size(1021, 738);
            this.splitContainer1.SplitterDistance = 493;
            this.splitContainer1.TabIndex = 21;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.annotations);
            this.tabControl1.Controls.Add(this.pixel);
            this.tabControl1.Controls.Add(this.motion);
            this.tabControl1.Controls.Add(this.global);
            this.tabControl1.Controls.Add(this.local);
            this.tabControl1.Controls.Add(this.general);
            this.tabControl1.Controls.Add(this.Shots);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 224);
            this.tabControl1.TabIndex = 9;
            // 
            // annotations
            // 
            this.annotations.Controls.Add(this.dgvResults);
            this.annotations.Location = new System.Drawing.Point(4, 25);
            this.annotations.Name = "annotations";
            this.annotations.Padding = new System.Windows.Forms.Padding(3);
            this.annotations.Size = new System.Drawing.Size(1000, 195);
            this.annotations.TabIndex = 1;
            this.annotations.Text = "Annotations";
            this.annotations.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shotNumber,
            this.StartFrame,
            this.tags});
            this.dgvResults.Location = new System.Drawing.Point(7, 7);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(4);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(986, 195);
            this.dgvResults.TabIndex = 9;
            // 
            // shotNumber
            // 
            this.shotNumber.HeaderText = "ShotNumber";
            this.shotNumber.Name = "shotNumber";
            this.shotNumber.ReadOnly = true;
            // 
            // StartFrame
            // 
            this.StartFrame.HeaderText = "StartFrame";
            this.StartFrame.Name = "StartFrame";
            this.StartFrame.ReadOnly = true;
            this.StartFrame.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tags
            // 
            this.tags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tags.HeaderText = "Tags";
            this.tags.Name = "tags";
            // 
            // pixel
            // 
            this.pixel.Controls.Add(this.txtPixelFraction);
            this.pixel.Controls.Add(this.txtPixelDistance);
            this.pixel.Controls.Add(this.startPixel);
            this.pixel.Controls.Add(this.label5);
            this.pixel.Controls.Add(this.label4);
            this.pixel.Controls.Add(this.label3);
            this.pixel.Controls.Add(this.label1);
            this.pixel.Location = new System.Drawing.Point(4, 25);
            this.pixel.Name = "pixel";
            this.pixel.Size = new System.Drawing.Size(1000, 195);
            this.pixel.TabIndex = 2;
            this.pixel.Text = "Pixel";
            this.pixel.UseVisualStyleBackColor = true;
            // 
            // txtPixelFraction
            // 
            this.txtPixelFraction.Location = new System.Drawing.Point(93, 88);
            this.txtPixelFraction.Mask = "0.000";
            this.txtPixelFraction.Name = "txtPixelFraction";
            this.txtPixelFraction.PromptChar = ' ';
            this.txtPixelFraction.Size = new System.Drawing.Size(100, 22);
            this.txtPixelFraction.TabIndex = 8;
            this.txtPixelFraction.Text = "0125";
            // 
            // txtPixelDistance
            // 
            this.txtPixelDistance.Location = new System.Drawing.Point(93, 27);
            this.txtPixelDistance.Mask = "000";
            this.txtPixelDistance.Name = "txtPixelDistance";
            this.txtPixelDistance.PromptChar = ' ';
            this.txtPixelDistance.Size = new System.Drawing.Size(100, 22);
            this.txtPixelDistance.TabIndex = 7;
            this.txtPixelDistance.Text = "256";
            // 
            // startPixel
            // 
            this.startPixel.Location = new System.Drawing.Point(922, 169);
            this.startPixel.Name = "startPixel";
            this.startPixel.Size = new System.Drawing.Size(75, 23);
            this.startPixel.TabIndex = 6;
            this.startPixel.Text = "Run";
            this.startPixel.UseVisualStyleBackColor = true;
            this.startPixel.Click += new System.EventHandler(this.startPixel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 34);
            this.label5.TabIndex = 5;
            this.label5.Text = "% of pixels that had a big enough distance . \r\nMin 0 - Max: 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 34);
            this.label4.TabIndex = 4;
            this.label4.Text = "Difference in pixels needed to generate a \'hit\'. \r\nMin:0 - Max : 768";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fraction";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distance";
            // 
            // motion
            // 
            this.motion.Controls.Add(this.txtMotionWindowSize);
            this.motion.Controls.Add(this.txtMotionSubSize);
            this.motion.Controls.Add(this.btnStartMotion);
            this.motion.Controls.Add(this.label2);
            this.motion.Controls.Add(this.label6);
            this.motion.Controls.Add(this.label7);
            this.motion.Controls.Add(this.label8);
            this.motion.Location = new System.Drawing.Point(4, 25);
            this.motion.Name = "motion";
            this.motion.Size = new System.Drawing.Size(1000, 195);
            this.motion.TabIndex = 3;
            this.motion.Text = "Motion";
            this.motion.UseVisualStyleBackColor = true;
            // 
            // txtMotionWindowSize
            // 
            this.txtMotionWindowSize.Location = new System.Drawing.Point(111, 117);
            this.txtMotionWindowSize.Mask = "0";
            this.txtMotionWindowSize.Name = "txtMotionWindowSize";
            this.txtMotionWindowSize.PromptChar = ' ';
            this.txtMotionWindowSize.Size = new System.Drawing.Size(100, 22);
            this.txtMotionWindowSize.TabIndex = 15;
            this.txtMotionWindowSize.Text = "2";
            // 
            // txtMotionSubSize
            // 
            this.txtMotionSubSize.Location = new System.Drawing.Point(111, 36);
            this.txtMotionSubSize.Mask = "00";
            this.txtMotionSubSize.Name = "txtMotionSubSize";
            this.txtMotionSubSize.PromptChar = ' ';
            this.txtMotionSubSize.Size = new System.Drawing.Size(100, 22);
            this.txtMotionSubSize.TabIndex = 14;
            this.txtMotionSubSize.Text = "8";
            // 
            // btnStartMotion
            // 
            this.btnStartMotion.Location = new System.Drawing.Point(922, 169);
            this.btnStartMotion.Name = "btnStartMotion";
            this.btnStartMotion.Size = new System.Drawing.Size(75, 23);
            this.btnStartMotion.TabIndex = 13;
            this.btnStartMotion.Text = "Run";
            this.btnStartMotion.UseVisualStyleBackColor = true;
            this.btnStartMotion.Click += new System.EventHandler(this.startMotion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 51);
            this.label2.TabIndex = 12;
            this.label2.Text = "The size of the searchWindow, expressed in subblocks, \r\nhigher for longer searche" +
    "s\r\nMin 1 - Max: 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 51);
            this.label6.TabIndex = 11;
            this.label6.Text = "the size of the subblock in pixels\r\nhigher for less accurate motion searching\r\nMi" +
    "n: 1 - Max: 32";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "windowSize";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "subSize";
            // 
            // global
            // 
            this.global.Controls.Add(this.txtGlobalFraction);
            this.global.Controls.Add(this.txtGlobalBinCount);
            this.global.Controls.Add(this.btnStartGlobalHist);
            this.global.Controls.Add(this.label9);
            this.global.Controls.Add(this.label10);
            this.global.Controls.Add(this.label11);
            this.global.Controls.Add(this.label12);
            this.global.Location = new System.Drawing.Point(4, 25);
            this.global.Name = "global";
            this.global.Size = new System.Drawing.Size(1000, 195);
            this.global.TabIndex = 4;
            this.global.Text = "Global Hist";
            this.global.UseVisualStyleBackColor = true;
            // 
            // txtGlobalFraction
            // 
            this.txtGlobalFraction.Location = new System.Drawing.Point(102, 100);
            this.txtGlobalFraction.Mask = "0.000";
            this.txtGlobalFraction.Name = "txtGlobalFraction";
            this.txtGlobalFraction.PromptChar = ' ';
            this.txtGlobalFraction.Size = new System.Drawing.Size(100, 22);
            this.txtGlobalFraction.TabIndex = 22;
            this.txtGlobalFraction.Text = "025";
            // 
            // txtGlobalBinCount
            // 
            this.txtGlobalBinCount.Location = new System.Drawing.Point(102, 19);
            this.txtGlobalBinCount.Mask = "000";
            this.txtGlobalBinCount.Name = "txtGlobalBinCount";
            this.txtGlobalBinCount.PromptChar = ' ';
            this.txtGlobalBinCount.Size = new System.Drawing.Size(100, 22);
            this.txtGlobalBinCount.TabIndex = 21;
            this.txtGlobalBinCount.Text = "51";
            // 
            // btnStartGlobalHist
            // 
            this.btnStartGlobalHist.Location = new System.Drawing.Point(922, 169);
            this.btnStartGlobalHist.Name = "btnStartGlobalHist";
            this.btnStartGlobalHist.Size = new System.Drawing.Size(75, 23);
            this.btnStartGlobalHist.TabIndex = 20;
            this.btnStartGlobalHist.Text = "Run";
            this.btnStartGlobalHist.UseVisualStyleBackColor = true;
            this.btnStartGlobalHist.Click += new System.EventHandler(this.startGlobalHist_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(326, 34);
            this.label9.TabIndex = 19;
            this.label9.Text = "Fraction of pixels that ends up in a different basket\r\nMin 0 - Max 1\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 34);
            this.label10.TabIndex = 18;
            this.label10.Text = "Number of baskets/bins\r\nMin: 1 -  Max 256";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "fraction";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "binCount";
            // 
            // local
            // 
            this.local.Controls.Add(this.cmbLocalHistNrOfBlocks);
            this.local.Controls.Add(this.label18);
            this.local.Controls.Add(this.label17);
            this.local.Controls.Add(this.txtLocalHistFraction);
            this.local.Controls.Add(this.txtLocalHistBinCount);
            this.local.Controls.Add(this.btnStartLocalHistogram);
            this.local.Controls.Add(this.label13);
            this.local.Controls.Add(this.label14);
            this.local.Controls.Add(this.label15);
            this.local.Controls.Add(this.label16);
            this.local.Location = new System.Drawing.Point(4, 25);
            this.local.Name = "local";
            this.local.Size = new System.Drawing.Size(1000, 195);
            this.local.TabIndex = 5;
            this.local.Text = "Local Hist";
            this.local.UseVisualStyleBackColor = true;
            // 
            // cmbLocalHistNrOfBlocks
            // 
            this.cmbLocalHistNrOfBlocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalHistNrOfBlocks.FormattingEnabled = true;
            this.cmbLocalHistNrOfBlocks.Location = new System.Drawing.Point(559, 36);
            this.cmbLocalHistNrOfBlocks.Name = "cmbLocalHistNrOfBlocks";
            this.cmbLocalHistNrOfBlocks.Size = new System.Drawing.Size(121, 24);
            this.cmbLocalHistNrOfBlocks.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(696, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(239, 51);
            this.label18.TabIndex = 32;
            this.label18.Text = "the number of different blocks used, \r\ne.g. 1,2,4,9,16,25,36...\r\nMin:1 - Max: 400" +
    "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(476, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 17);
            this.label17.TabIndex = 30;
            this.label17.Text = "nrOfBlocks";
            // 
            // txtLocalHistFraction
            // 
            this.txtLocalHistFraction.Location = new System.Drawing.Point(111, 117);
            this.txtLocalHistFraction.Mask = "0.000";
            this.txtLocalHistFraction.Name = "txtLocalHistFraction";
            this.txtLocalHistFraction.PromptChar = ' ';
            this.txtLocalHistFraction.Size = new System.Drawing.Size(100, 22);
            this.txtLocalHistFraction.TabIndex = 29;
            this.txtLocalHistFraction.Text = "04";
            // 
            // txtLocalHistBinCount
            // 
            this.txtLocalHistBinCount.Location = new System.Drawing.Point(111, 36);
            this.txtLocalHistBinCount.Mask = "000";
            this.txtLocalHistBinCount.Name = "txtLocalHistBinCount";
            this.txtLocalHistBinCount.PromptChar = ' ';
            this.txtLocalHistBinCount.Size = new System.Drawing.Size(100, 22);
            this.txtLocalHistBinCount.TabIndex = 28;
            this.txtLocalHistBinCount.Text = "32";
            // 
            // btnStartLocalHistogram
            // 
            this.btnStartLocalHistogram.Location = new System.Drawing.Point(922, 169);
            this.btnStartLocalHistogram.Name = "btnStartLocalHistogram";
            this.btnStartLocalHistogram.Size = new System.Drawing.Size(75, 23);
            this.btnStartLocalHistogram.TabIndex = 27;
            this.btnStartLocalHistogram.Text = "Run";
            this.btnStartLocalHistogram.UseVisualStyleBackColor = true;
            this.btnStartLocalHistogram.Click += new System.EventHandler(this.StartLocalHistogram_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(227, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(326, 34);
            this.label13.TabIndex = 26;
            this.label13.Text = "Fraction of pixels that ends up in a different basket\r\nMin 0 - Max 1\r\n";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(227, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(157, 34);
            this.label14.TabIndex = 25;
            this.label14.Text = "Number of baskets/bins\r\nMin: 1 -  Max 256";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 17);
            this.label15.TabIndex = 24;
            this.label15.Text = "fraction";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 17);
            this.label16.TabIndex = 23;
            this.label16.Text = "binCount";
            // 
            // general
            // 
            this.general.Location = new System.Drawing.Point(4, 25);
            this.general.Name = "general";
            this.general.Size = new System.Drawing.Size(1000, 195);
            this.general.TabIndex = 6;
            this.general.Text = "General";
            this.general.UseVisualStyleBackColor = true;
            // 
            // Shots
            // 
            this.Shots.Location = new System.Drawing.Point(4, 25);
            this.Shots.Name = "Shots";
            this.Shots.Padding = new System.Windows.Forms.Padding(3);
            this.Shots.Size = new System.Drawing.Size(1000, 195);
            this.Shots.TabIndex = 0;
            this.Shots.Text = "Shots";
            this.Shots.UseVisualStyleBackColor = true;
            // 
            // ShotDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 805);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mnMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1063, 100);
            this.Name = "ShotDetector";
            this.Text = "ShotDetector";
            this.mnMenu.ResumeLayout(false);
            this.mnMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.annotations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.pixel.ResumeLayout(false);
            this.pixel.PerformLayout();
            this.motion.ResumeLayout(false);
            this.motion.PerformLayout();
            this.global.ResumeLayout(false);
            this.global.PerformLayout();
            this.local.ResumeLayout(false);
            this.local.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.MenuStrip mnMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmPlay;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.SaveFileDialog sfdBrowse;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem exportResultToXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateRecallToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Shots;
        private System.Windows.Forms.TabPage annotations;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn shotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartFrame;
        private System.Windows.Forms.DataGridViewTextBoxColumn tags;
        private System.Windows.Forms.TabPage pixel;
        private System.Windows.Forms.TabPage motion;
        private System.Windows.Forms.TabPage global;
        private System.Windows.Forms.TabPage local;
        private System.Windows.Forms.TabPage general;
        private System.Windows.Forms.Button startPixel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtPixelDistance;
        private System.Windows.Forms.MaskedTextBox txtPixelFraction;
        private System.Windows.Forms.MaskedTextBox txtMotionWindowSize;
        private System.Windows.Forms.MaskedTextBox txtMotionSubSize;
        private System.Windows.Forms.Button btnStartMotion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtGlobalFraction;
        private System.Windows.Forms.MaskedTextBox txtGlobalBinCount;
        private System.Windows.Forms.Button btnStartGlobalHist;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtLocalHistFraction;
        private System.Windows.Forms.MaskedTextBox txtLocalHistBinCount;
        private System.Windows.Forms.Button btnStartLocalHistogram;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbLocalHistNrOfBlocks;
    }
}

