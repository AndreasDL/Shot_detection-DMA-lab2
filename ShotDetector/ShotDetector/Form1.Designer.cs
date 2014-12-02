namespace ShotDetector {
    partial class ShotDetector {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.mnMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportResultToXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateRecallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.sfdBrowse = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.annotations = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.shotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartFrame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pixel = new System.Windows.Forms.TabPage();
            this.txtPixelFraction = new System.Windows.Forms.MaskedTextBox();
            this.txtPixelDistance = new System.Windows.Forms.MaskedTextBox();
            this.btnStartPixel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.motion = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtMotionThres = new System.Windows.Forms.MaskedTextBox();
            this.txtMotionFraction = new System.Windows.Forms.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtMotionWindowSize = new System.Windows.Forms.MaskedTextBox();
            this.txtMotionSubSize = new System.Windows.Forms.MaskedTextBox();
            this.btnStartMotion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.FastMotion = new System.Windows.Forms.TabPage();
            this.btnStartFastMotion = new System.Windows.Forms.Button();
            this.txtFastMotionWindowSize = new System.Windows.Forms.MaskedTextBox();
            this.txtFastMotionSubSize = new System.Windows.Forms.MaskedTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
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
            this.btnStartTwin = new System.Windows.Forms.Button();
            this.txtTwinCompBins = new System.Windows.Forms.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.mnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.annotations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.pixel.SuspendLayout();
            this.motion.SuspendLayout();
            this.FastMotion.SuspendLayout();
            this.global.SuspendLayout();
            this.local.SuspendLayout();
            this.general.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.fileToolStripMenuItem});
            this.mnMenu.Location = new System.Drawing.Point(0, 0);
            this.mnMenu.Name = "mnMenu";
            this.mnMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mnMenu.Size = new System.Drawing.Size(1153, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.openToolStripMenuItem.Text = "Open Video File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.browseFile);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(228, 6);
            // 
            // exportResultToXmlToolStripMenuItem
            // 
            this.exportResultToXmlToolStripMenuItem.Enabled = false;
            this.exportResultToXmlToolStripMenuItem.Name = "exportResultToXmlToolStripMenuItem";
            this.exportResultToXmlToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.exportResultToXmlToolStripMenuItem.Text = "Export Results to xml";
            this.exportResultToXmlToolStripMenuItem.Click += new System.EventHandler(this.exportXML);
            // 
            // calculateRecallToolStripMenuItem
            // 
            this.calculateRecallToolStripMenuItem.Enabled = false;
            this.calculateRecallToolStripMenuItem.Name = "calculateRecallToolStripMenuItem";
            this.calculateRecallToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.calculateRecallToolStripMenuItem.Text = "Calculate Precision and Recall";
            this.calculateRecallToolStripMenuItem.Click += new System.EventHandler(this.calcRecallandPrecision);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(228, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.Quit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 396);
            this.panel1.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(4, 407);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnPause.Location = new System.Drawing.Point(112, 407);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.splitContainer1.Location = new System.Drawing.Point(12, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.splitContainer1.Size = new System.Drawing.Size(1129, 666);
            this.splitContainer1.SplitterDistance = 441;
            this.splitContainer1.TabIndex = 21;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.annotations);
            this.tabControl1.Controls.Add(this.pixel);
            this.tabControl1.Controls.Add(this.motion);
            this.tabControl1.Controls.Add(this.FastMotion);
            this.tabControl1.Controls.Add(this.global);
            this.tabControl1.Controls.Add(this.local);
            this.tabControl1.Controls.Add(this.general);
            this.tabControl1.Location = new System.Drawing.Point(5, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1119, 216);
            this.tabControl1.TabIndex = 9;
            // 
            // annotations
            // 
            this.annotations.Controls.Add(this.label19);
            this.annotations.Controls.Add(this.label21);
            this.annotations.Controls.Add(this.pictureBox1);
            this.annotations.Controls.Add(this.txtSearch);
            this.annotations.Controls.Add(this.label20);
            this.annotations.Controls.Add(this.btnCalc);
            this.annotations.Controls.Add(this.btnSearch);
            this.annotations.Controls.Add(this.btnExport);
            this.annotations.Controls.Add(this.dgvResults);
            this.annotations.Location = new System.Drawing.Point(4, 25);
            this.annotations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.annotations.Name = "annotations";
            this.annotations.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.annotations.Size = new System.Drawing.Size(1111, 187);
            this.annotations.TabIndex = 1;
            this.annotations.Text = "Annotations";
            this.annotations.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 154);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(154, 16);
            this.label19.TabIndex = 13;
            this.label19.Text = "Click on picture to save it";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(455, 154);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 16);
            this.label21.TabIndex = 2;
            this.label21.Text = "Search";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(5, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 135);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(523, 150);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(196, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.searchTag);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTag);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(269, 154);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(173, 16);
            this.label20.TabIndex = 1;
            this.label20.Text = "Double click a shot to play it";
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Enabled = false;
            this.btnCalc.Location = new System.Drawing.Point(829, 147);
            this.btnCalc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(168, 28);
            this.btnCalc.TabIndex = 11;
            this.btnCalc.Text = "Calc Pre + Rec";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.calcRecallandPrecision);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(724, 149);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.searchTag);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(1003, 149);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 28);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.exportXML);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResults.Location = new System.Drawing.Point(352, 9);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(844, 133);
            this.dgvResults.TabIndex = 9;
            this.dgvResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellDoubleClick);
            this.dgvResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridChanged);
            this.dgvResults.SelectionChanged += new System.EventHandler(this.resultSelectedIndexChanged);
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
            this.pixel.Controls.Add(this.btnStartPixel);
            this.pixel.Controls.Add(this.label5);
            this.pixel.Controls.Add(this.label4);
            this.pixel.Controls.Add(this.label3);
            this.pixel.Controls.Add(this.label1);
            this.pixel.Location = new System.Drawing.Point(4, 25);
            this.pixel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pixel.Name = "pixel";
            this.pixel.Size = new System.Drawing.Size(1111, 186);
            this.pixel.TabIndex = 2;
            this.pixel.Text = "Pixel";
            this.pixel.UseVisualStyleBackColor = true;
            // 
            // txtPixelFraction
            // 
            this.txtPixelFraction.Location = new System.Drawing.Point(93, 89);
            this.txtPixelFraction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPixelFraction.Mask = "0.000";
            this.txtPixelFraction.Name = "txtPixelFraction";
            this.txtPixelFraction.PromptChar = ' ';
            this.txtPixelFraction.Size = new System.Drawing.Size(100, 22);
            this.txtPixelFraction.TabIndex = 8;
            this.txtPixelFraction.Text = "0250";
            // 
            // txtPixelDistance
            // 
            this.txtPixelDistance.Location = new System.Drawing.Point(93, 27);
            this.txtPixelDistance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPixelDistance.Mask = "000";
            this.txtPixelDistance.Name = "txtPixelDistance";
            this.txtPixelDistance.PromptChar = ' ';
            this.txtPixelDistance.Size = new System.Drawing.Size(100, 22);
            this.txtPixelDistance.TabIndex = 7;
            this.txtPixelDistance.Text = "50";
            // 
            // btnStartPixel
            // 
            this.btnStartPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartPixel.Enabled = false;
            this.btnStartPixel.Location = new System.Drawing.Point(1013, 142);
            this.btnStartPixel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartPixel.Name = "btnStartPixel";
            this.btnStartPixel.Size = new System.Drawing.Size(75, 28);
            this.btnStartPixel.TabIndex = 6;
            this.btnStartPixel.Text = "Run";
            this.btnStartPixel.UseVisualStyleBackColor = true;
            this.btnStartPixel.Click += new System.EventHandler(this.startPixel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "% of pixels that had a big enough distance . \r\nMin 0 - Max: 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Difference in pixels needed to generate a \'hit\'. \r\nMin:0 - Max : 768";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fraction";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distance";
            // 
            // motion
            // 
            this.motion.Controls.Add(this.label28);
            this.motion.Controls.Add(this.checkBox1);
            this.motion.Controls.Add(this.label27);
            this.motion.Controls.Add(this.txtMotionThres);
            this.motion.Controls.Add(this.txtMotionFraction);
            this.motion.Controls.Add(this.label26);
            this.motion.Controls.Add(this.label25);
            this.motion.Controls.Add(this.label24);
            this.motion.Controls.Add(this.txtMotionWindowSize);
            this.motion.Controls.Add(this.txtMotionSubSize);
            this.motion.Controls.Add(this.btnStartMotion);
            this.motion.Controls.Add(this.label2);
            this.motion.Controls.Add(this.label6);
            this.motion.Controls.Add(this.label7);
            this.motion.Controls.Add(this.label8);
            this.motion.Location = new System.Drawing.Point(4, 25);
            this.motion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.motion.Name = "motion";
            this.motion.Size = new System.Drawing.Size(1111, 186);
            this.motion.TabIndex = 3;
            this.motion.Text = "Motion";
            this.motion.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(769, 149);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 16);
            this.label28.TabIndex = 23;
            this.label28.Text = "Auto";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(836, 146);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(287, 36);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Auto: use averages to determine the cuts\r\nThis ignore the threshold and fraction " +
    "above";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(945, 44);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(285, 32);
            this.label27.TabIndex = 21;
            this.label27.Text = "distance between two blocks that results in a hit\r\nMin: 1 Max: 3*256 * subSize*su" +
    "bSize";
            // 
            // txtMotionThres
            // 
            this.txtMotionThres.Enabled = false;
            this.txtMotionThres.Location = new System.Drawing.Point(861, 41);
            this.txtMotionThres.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtMotionThres.Mask = "000000";
            this.txtMotionThres.Name = "txtMotionThres";
            this.txtMotionThres.PromptChar = ' ';
            this.txtMotionThres.Size = new System.Drawing.Size(75, 22);
            this.txtMotionThres.TabIndex = 20;
            this.txtMotionThres.Text = "4000";
            // 
            // txtMotionFraction
            // 
            this.txtMotionFraction.Enabled = false;
            this.txtMotionFraction.Location = new System.Drawing.Point(861, 96);
            this.txtMotionFraction.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtMotionFraction.Mask = "0.000";
            this.txtMotionFraction.Name = "txtMotionFraction";
            this.txtMotionFraction.PromptChar = ' ';
            this.txtMotionFraction.Size = new System.Drawing.Size(75, 22);
            this.txtMotionFraction.TabIndex = 19;
            this.txtMotionFraction.Text = "0500";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(945, 100);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(200, 32);
            this.label26.TabIndex = 18;
            this.label26.Text = "% of pixels that differes too much\r\nMin 0 - Max: 1";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(769, 100);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(51, 16);
            this.label25.TabIndex = 17;
            this.label25.Text = "fraction";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(769, 44);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 16);
            this.label24.TabIndex = 16;
            this.label24.Text = "threshold";
            // 
            // txtMotionWindowSize
            // 
            this.txtMotionWindowSize.Location = new System.Drawing.Point(111, 117);
            this.txtMotionWindowSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.txtMotionSubSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMotionSubSize.Mask = "00";
            this.txtMotionSubSize.Name = "txtMotionSubSize";
            this.txtMotionSubSize.PromptChar = ' ';
            this.txtMotionSubSize.Size = new System.Drawing.Size(100, 22);
            this.txtMotionSubSize.TabIndex = 14;
            this.txtMotionSubSize.Text = "8";
            // 
            // btnStartMotion
            // 
            this.btnStartMotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartMotion.Enabled = false;
            this.btnStartMotion.Location = new System.Drawing.Point(1363, 174);
            this.btnStartMotion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnStartMotion.Name = "btnStartMotion";
            this.btnStartMotion.Size = new System.Drawing.Size(75, 28);
            this.btnStartMotion.TabIndex = 13;
            this.btnStartMotion.Text = "Run";
            this.btnStartMotion.UseVisualStyleBackColor = true;
            this.btnStartMotion.Click += new System.EventHandler(this.startMotion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 48);
            this.label2.TabIndex = 12;
            this.label2.Text = "The size of the searchWindow, expressed in subblocks, \r\nhigher for longer searche" +
    "s\r\nMin 1 - Max: 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 48);
            this.label6.TabIndex = 11;
            this.label6.Text = "the length of the edge of the subblock in pixels\r\nhigher for less accurate motion" +
    " searching\r\nMin: 1 - Max: 32";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "windowSize";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "subSize";
            // 
            // FastMotion
            // 
            this.FastMotion.Controls.Add(this.btnStartFastMotion);
            this.FastMotion.Controls.Add(this.txtFastMotionWindowSize);
            this.FastMotion.Controls.Add(this.txtFastMotionSubSize);
            this.FastMotion.Controls.Add(this.label29);
            this.FastMotion.Controls.Add(this.label30);
            this.FastMotion.Controls.Add(this.label31);
            this.FastMotion.Controls.Add(this.label32);
            this.FastMotion.Location = new System.Drawing.Point(4, 25);
            this.FastMotion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FastMotion.Name = "FastMotion";
            this.FastMotion.Size = new System.Drawing.Size(1111, 186);
            this.FastMotion.TabIndex = 7;
            this.FastMotion.Text = "Simple Motion";
            this.FastMotion.UseVisualStyleBackColor = true;
            // 
            // btnStartFastMotion
            // 
            this.btnStartFastMotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartFastMotion.Enabled = false;
            this.btnStartFastMotion.Location = new System.Drawing.Point(1351, 176);
            this.btnStartFastMotion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnStartFastMotion.Name = "btnStartFastMotion";
            this.btnStartFastMotion.Size = new System.Drawing.Size(100, 34);
            this.btnStartFastMotion.TabIndex = 22;
            this.btnStartFastMotion.Text = "Run";
            this.btnStartFastMotion.UseVisualStyleBackColor = true;
            this.btnStartFastMotion.Click += new System.EventHandler(this.StartFastMotion_Click);
            // 
            // txtFastMotionWindowSize
            // 
            this.txtFastMotionWindowSize.Location = new System.Drawing.Point(140, 129);
            this.txtFastMotionWindowSize.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtFastMotionWindowSize.Mask = "0";
            this.txtFastMotionWindowSize.Name = "txtFastMotionWindowSize";
            this.txtFastMotionWindowSize.PromptChar = ' ';
            this.txtFastMotionWindowSize.Size = new System.Drawing.Size(132, 22);
            this.txtFastMotionWindowSize.TabIndex = 21;
            this.txtFastMotionWindowSize.Text = "2";
            // 
            // txtFastMotionSubSize
            // 
            this.txtFastMotionSubSize.Location = new System.Drawing.Point(140, 30);
            this.txtFastMotionSubSize.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtFastMotionSubSize.Mask = "00";
            this.txtFastMotionSubSize.Name = "txtFastMotionSubSize";
            this.txtFastMotionSubSize.PromptChar = ' ';
            this.txtFastMotionSubSize.Size = new System.Drawing.Size(132, 22);
            this.txtFastMotionSubSize.TabIndex = 20;
            this.txtFastMotionSubSize.Text = "8";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(295, 134);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(340, 48);
            this.label29.TabIndex = 19;
            this.label29.Text = "The size of the searchWindow, expressed in subblocks, \r\nhigher for longer searche" +
    "s\r\nMin 1 - Max: 4";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(295, 33);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(279, 48);
            this.label30.TabIndex = 18;
            this.label30.Text = "the length of the edge of the subblock in pixels\r\nhigher for less accurate motion" +
    " searching\r\nMin: 1 - Max: 32";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(20, 134);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(78, 16);
            this.label31.TabIndex = 17;
            this.label31.Text = "windowSize";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(20, 33);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 16);
            this.label32.TabIndex = 16;
            this.label32.Text = "subSize";
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
            this.global.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.global.Name = "global";
            this.global.Size = new System.Drawing.Size(1111, 186);
            this.global.TabIndex = 4;
            this.global.Text = "Global Hist";
            this.global.UseVisualStyleBackColor = true;
            // 
            // txtGlobalFraction
            // 
            this.txtGlobalFraction.Location = new System.Drawing.Point(101, 100);
            this.txtGlobalFraction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGlobalFraction.Mask = "0.000";
            this.txtGlobalFraction.Name = "txtGlobalFraction";
            this.txtGlobalFraction.PromptChar = ' ';
            this.txtGlobalFraction.Size = new System.Drawing.Size(100, 22);
            this.txtGlobalFraction.TabIndex = 22;
            this.txtGlobalFraction.Text = "025";
            // 
            // txtGlobalBinCount
            // 
            this.txtGlobalBinCount.Location = new System.Drawing.Point(101, 18);
            this.txtGlobalBinCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGlobalBinCount.Mask = "000";
            this.txtGlobalBinCount.Name = "txtGlobalBinCount";
            this.txtGlobalBinCount.PromptChar = ' ';
            this.txtGlobalBinCount.Size = new System.Drawing.Size(100, 22);
            this.txtGlobalBinCount.TabIndex = 21;
            this.txtGlobalBinCount.Text = "51";
            // 
            // btnStartGlobalHist
            // 
            this.btnStartGlobalHist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartGlobalHist.Enabled = false;
            this.btnStartGlobalHist.Location = new System.Drawing.Point(1361, 175);
            this.btnStartGlobalHist.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnStartGlobalHist.Name = "btnStartGlobalHist";
            this.btnStartGlobalHist.Size = new System.Drawing.Size(75, 28);
            this.btnStartGlobalHist.TabIndex = 20;
            this.btnStartGlobalHist.Text = "Run";
            this.btnStartGlobalHist.UseVisualStyleBackColor = true;
            this.btnStartGlobalHist.Click += new System.EventHandler(this.startGlobalHist_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(301, 32);
            this.label9.TabIndex = 19;
            this.label9.Text = "Fraction of pixels that ends up in a different basket\r\nMin 0 - Max 1\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(219, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 32);
            this.label10.TabIndex = 18;
            this.label10.Text = "Number of baskets/bins\r\nMin: 1 -  Max 256";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "fraction";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 16);
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
            this.local.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.local.Name = "local";
            this.local.Size = new System.Drawing.Size(1111, 186);
            this.local.TabIndex = 5;
            this.local.Text = "Local Hist";
            this.local.UseVisualStyleBackColor = true;
            // 
            // cmbLocalHistNrOfBlocks
            // 
            this.cmbLocalHistNrOfBlocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalHistNrOfBlocks.FormattingEnabled = true;
            this.cmbLocalHistNrOfBlocks.Location = new System.Drawing.Point(559, 36);
            this.cmbLocalHistNrOfBlocks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbLocalHistNrOfBlocks.Name = "cmbLocalHistNrOfBlocks";
            this.cmbLocalHistNrOfBlocks.Size = new System.Drawing.Size(121, 24);
            this.cmbLocalHistNrOfBlocks.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(696, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(220, 48);
            this.label18.TabIndex = 32;
            this.label18.Text = "the number of different blocks used, \r\ne.g. 1,2,4,9,16,25,36...\r\nMin:1 - Max: 400" +
    "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(476, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 16);
            this.label17.TabIndex = 30;
            this.label17.Text = "nrOfBlocks";
            // 
            // txtLocalHistFraction
            // 
            this.txtLocalHistFraction.Location = new System.Drawing.Point(111, 117);
            this.txtLocalHistFraction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.txtLocalHistBinCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLocalHistBinCount.Mask = "000";
            this.txtLocalHistBinCount.Name = "txtLocalHistBinCount";
            this.txtLocalHistBinCount.PromptChar = ' ';
            this.txtLocalHistBinCount.Size = new System.Drawing.Size(100, 22);
            this.txtLocalHistBinCount.TabIndex = 28;
            this.txtLocalHistBinCount.Text = "32";
            // 
            // btnStartLocalHistogram
            // 
            this.btnStartLocalHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartLocalHistogram.Enabled = false;
            this.btnStartLocalHistogram.Location = new System.Drawing.Point(1363, 176);
            this.btnStartLocalHistogram.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnStartLocalHistogram.Name = "btnStartLocalHistogram";
            this.btnStartLocalHistogram.Size = new System.Drawing.Size(75, 28);
            this.btnStartLocalHistogram.TabIndex = 27;
            this.btnStartLocalHistogram.Text = "Run";
            this.btnStartLocalHistogram.UseVisualStyleBackColor = true;
            this.btnStartLocalHistogram.Click += new System.EventHandler(this.StartLocalHistogram_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(227, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(301, 32);
            this.label13.TabIndex = 26;
            this.label13.Text = "Fraction of pixels that ends up in a different basket\r\nMin 0 - Max 1\r\n";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(227, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 32);
            this.label14.TabIndex = 25;
            this.label14.Text = "Number of baskets/bins\r\nMin: 1 -  Max 256";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 16);
            this.label15.TabIndex = 24;
            this.label15.Text = "fraction";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 16);
            this.label16.TabIndex = 23;
            this.label16.Text = "binCount";
            // 
            // general
            // 
            this.general.Controls.Add(this.btnStartTwin);
            this.general.Controls.Add(this.txtTwinCompBins);
            this.general.Controls.Add(this.label22);
            this.general.Controls.Add(this.label23);
            this.general.Location = new System.Drawing.Point(4, 25);
            this.general.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.general.Name = "general";
            this.general.Size = new System.Drawing.Size(1111, 187);
            this.general.TabIndex = 6;
            this.general.Text = "General";
            this.general.UseVisualStyleBackColor = true;
            // 
            // btnStartTwin
            // 
            this.btnStartTwin.Enabled = false;
            this.btnStartTwin.Location = new System.Drawing.Point(993, 141);
            this.btnStartTwin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartTwin.Name = "btnStartTwin";
            this.btnStartTwin.Size = new System.Drawing.Size(100, 28);
            this.btnStartTwin.TabIndex = 32;
            this.btnStartTwin.Text = "run";
            this.btnStartTwin.UseVisualStyleBackColor = true;
            this.btnStartTwin.Click += new System.EventHandler(this.StartTwinComp_Click);
            // 
            // txtTwinCompBins
            // 
            this.txtTwinCompBins.Location = new System.Drawing.Point(101, 25);
            this.txtTwinCompBins.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTwinCompBins.Mask = "000";
            this.txtTwinCompBins.Name = "txtTwinCompBins";
            this.txtTwinCompBins.PromptChar = ' ';
            this.txtTwinCompBins.Size = new System.Drawing.Size(100, 22);
            this.txtTwinCompBins.TabIndex = 31;
            this.txtTwinCompBins.Text = "32";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(217, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(150, 32);
            this.label22.TabIndex = 30;
            this.label22.Text = "Number of baskets/bins\r\nMin: 1 -  Max 256";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 28);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 16);
            this.label23.TabIndex = 29;
            this.label23.Text = "binCount";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 712);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1153, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 20);
            this.toolStripProgressBar1.Visible = false;
            // 
            // ShotDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 734);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mnMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1063, 101);
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
            this.annotations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.pixel.ResumeLayout(false);
            this.pixel.PerformLayout();
            this.motion.ResumeLayout(false);
            this.motion.PerformLayout();
            this.FastMotion.ResumeLayout(false);
            this.FastMotion.PerformLayout();
            this.global.ResumeLayout(false);
            this.global.PerformLayout();
            this.local.ResumeLayout(false);
            this.local.PerformLayout();
            this.general.ResumeLayout(false);
            this.general.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.MenuStrip mnMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
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
        private System.Windows.Forms.Button btnStartPixel;
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnStartTwin;
        private System.Windows.Forms.MaskedTextBox txtTwinCompBins;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.MaskedTextBox txtMotionThres;
        private System.Windows.Forms.MaskedTextBox txtMotionFraction;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TabPage FastMotion;
        private System.Windows.Forms.Button btnStartFastMotion;
        private System.Windows.Forms.MaskedTextBox txtFastMotionWindowSize;
        private System.Windows.Forms.MaskedTextBox txtFastMotionSubSize;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
    }
}
