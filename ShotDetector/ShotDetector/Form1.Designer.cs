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
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbSpeedup = new System.Windows.Forms.ComboBox();
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
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtTwinDelta = new System.Windows.Forms.MaskedTextBox();
            this.txtTwinGamma = new System.Windows.Forms.MaskedTextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtTwinBeta = new System.Windows.Forms.MaskedTextBox();
            this.txtTwinAlfa = new System.Windows.Forms.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbTwinNrOfBlocks = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
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
            this.mnMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mnMenu.Size = new System.Drawing.Size(865, 24);
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
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 321);
            this.panel1.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(3, 330);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.start_Click);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(84, 330);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
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
            this.splitContainer1.Location = new System.Drawing.Point(9, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
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
            this.splitContainer1.Size = new System.Drawing.Size(847, 541);
            this.splitContainer1.SplitterDistance = 358;
            this.splitContainer1.SplitterWidth = 3;
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
            this.tabControl1.Controls.Add(this.global);
            this.tabControl1.Controls.Add(this.local);
            this.tabControl1.Controls.Add(this.general);
            this.tabControl1.Location = new System.Drawing.Point(4, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 177);
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
            this.annotations.Location = new System.Drawing.Point(4, 22);
            this.annotations.Margin = new System.Windows.Forms.Padding(2);
            this.annotations.Name = "annotations";
            this.annotations.Padding = new System.Windows.Forms.Padding(2);
            this.annotations.Size = new System.Drawing.Size(831, 151);
            this.annotations.TabIndex = 1;
            this.annotations.Text = "Annotations";
            this.annotations.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 125);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "Click on picture to save it";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(341, 125);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Search";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 110);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(392, 122);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(148, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.searchTag);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTag);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(202, 125);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(140, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "Double click a shot to play it";
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Enabled = false;
            this.btnCalc.Location = new System.Drawing.Point(622, 121);
            this.btnCalc.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(126, 23);
            this.btnCalc.TabIndex = 11;
            this.btnCalc.Text = "Calc Pre + Rec";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.calcRecallandPrecision);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(543, 121);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.searchTag);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(752, 121);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
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
            this.dgvResults.Location = new System.Drawing.Point(198, 4);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(4);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(633, 108);
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
            this.pixel.Location = new System.Drawing.Point(4, 22);
            this.pixel.Margin = new System.Windows.Forms.Padding(2);
            this.pixel.Name = "pixel";
            this.pixel.Size = new System.Drawing.Size(831, 151);
            this.pixel.TabIndex = 2;
            this.pixel.Text = "Pixel";
            this.pixel.UseVisualStyleBackColor = true;
            // 
            // txtPixelFraction
            // 
            this.txtPixelFraction.Location = new System.Drawing.Point(70, 72);
            this.txtPixelFraction.Margin = new System.Windows.Forms.Padding(2);
            this.txtPixelFraction.Mask = "0.000";
            this.txtPixelFraction.Name = "txtPixelFraction";
            this.txtPixelFraction.PromptChar = ' ';
            this.txtPixelFraction.Size = new System.Drawing.Size(76, 20);
            this.txtPixelFraction.TabIndex = 8;
            this.txtPixelFraction.Text = "0250";
            // 
            // txtPixelDistance
            // 
            this.txtPixelDistance.Location = new System.Drawing.Point(70, 22);
            this.txtPixelDistance.Margin = new System.Windows.Forms.Padding(2);
            this.txtPixelDistance.Mask = "000";
            this.txtPixelDistance.Name = "txtPixelDistance";
            this.txtPixelDistance.PromptChar = ' ';
            this.txtPixelDistance.Size = new System.Drawing.Size(76, 20);
            this.txtPixelDistance.TabIndex = 7;
            this.txtPixelDistance.Text = "50";
            // 
            // btnStartPixel
            // 
            this.btnStartPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartPixel.Enabled = false;
            this.btnStartPixel.Location = new System.Drawing.Point(760, 115);
            this.btnStartPixel.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartPixel.Name = "btnStartPixel";
            this.btnStartPixel.Size = new System.Drawing.Size(56, 23);
            this.btnStartPixel.TabIndex = 6;
            this.btnStartPixel.Text = "Run";
            this.btnStartPixel.UseVisualStyleBackColor = true;
            this.btnStartPixel.Click += new System.EventHandler(this.startPixel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "% of pixels that had a big enough distance . \r\nMin 0 - Max: 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Difference in pixels needed to generate a \'hit\'. \r\nMin:0 - Max : 768";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fraction";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distance";
            // 
            // motion
            // 
            this.motion.Controls.Add(this.label30);
            this.motion.Controls.Add(this.label29);
            this.motion.Controls.Add(this.cmbSpeedup);
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
            this.motion.Location = new System.Drawing.Point(4, 22);
            this.motion.Margin = new System.Windows.Forms.Padding(2);
            this.motion.Name = "motion";
            this.motion.Size = new System.Drawing.Size(831, 151);
            this.motion.TabIndex = 3;
            this.motion.Text = "Motion";
            this.motion.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(164, 96);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(247, 52);
            this.label30.TabIndex = 26;
            this.label30.Text = "higher speedup will skip more blocks\r\nWARNING using high speedup with low resolut" +
    "ion \r\nresults in less accurate results. \r\nAuto mode prevent this (to some extent" +
    ").";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(10, 103);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 13);
            this.label29.TabIndex = 25;
            this.label29.Text = "Speedup";
            // 
            // cmbSpeedup
            // 
            this.cmbSpeedup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeedup.FormattingEnabled = true;
            this.cmbSpeedup.Location = new System.Drawing.Point(77, 101);
            this.cmbSpeedup.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSpeedup.Name = "cmbSpeedup";
            this.cmbSpeedup.Size = new System.Drawing.Size(76, 21);
            this.cmbSpeedup.TabIndex = 24;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(434, 98);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 13);
            this.label28.TabIndex = 23;
            this.label28.Text = "Auto";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(484, 96);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(234, 30);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Auto: use averages to determine the cuts\r\nThis ignore the threshold and fraction " +
    "above";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(566, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(233, 26);
            this.label27.TabIndex = 21;
            this.label27.Text = "distance between two blocks that results in a hit\r\nMin: 1 Max: 768";
            // 
            // txtMotionThres
            // 
            this.txtMotionThres.Location = new System.Drawing.Point(503, 11);
            this.txtMotionThres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMotionThres.Mask = "000";
            this.txtMotionThres.Name = "txtMotionThres";
            this.txtMotionThres.PromptChar = ' ';
            this.txtMotionThres.Size = new System.Drawing.Size(57, 20);
            this.txtMotionThres.TabIndex = 20;
            this.txtMotionThres.Text = "100";
            // 
            // txtMotionFraction
            // 
            this.txtMotionFraction.Location = new System.Drawing.Point(503, 55);
            this.txtMotionFraction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMotionFraction.Mask = "0.000";
            this.txtMotionFraction.Name = "txtMotionFraction";
            this.txtMotionFraction.PromptChar = ' ';
            this.txtMotionFraction.Size = new System.Drawing.Size(57, 20);
            this.txtMotionFraction.TabIndex = 19;
            this.txtMotionFraction.Text = "0500";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(566, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(161, 26);
            this.label26.TabIndex = 18;
            this.label26.Text = "% of pixels that differes too much\r\nMin 0 - Max: 1";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(434, 58);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 13);
            this.label25.TabIndex = 17;
            this.label25.Text = "fraction";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(434, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(50, 13);
            this.label24.TabIndex = 16;
            this.label24.Text = "threshold";
            // 
            // txtMotionWindowSize
            // 
            this.txtMotionWindowSize.Location = new System.Drawing.Point(77, 53);
            this.txtMotionWindowSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtMotionWindowSize.Mask = "000";
            this.txtMotionWindowSize.Name = "txtMotionWindowSize";
            this.txtMotionWindowSize.PromptChar = ' ';
            this.txtMotionWindowSize.Size = new System.Drawing.Size(76, 20);
            this.txtMotionWindowSize.TabIndex = 15;
            this.txtMotionWindowSize.Text = "11";
            // 
            // txtMotionSubSize
            // 
            this.txtMotionSubSize.Location = new System.Drawing.Point(77, 13);
            this.txtMotionSubSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtMotionSubSize.Mask = "00";
            this.txtMotionSubSize.Name = "txtMotionSubSize";
            this.txtMotionSubSize.PromptChar = ' ';
            this.txtMotionSubSize.Size = new System.Drawing.Size(76, 20);
            this.txtMotionSubSize.TabIndex = 14;
            this.txtMotionSubSize.Text = "8";
            // 
            // btnStartMotion
            // 
            this.btnStartMotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartMotion.Enabled = false;
            this.btnStartMotion.Location = new System.Drawing.Point(764, 119);
            this.btnStartMotion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartMotion.Name = "btnStartMotion";
            this.btnStartMotion.Size = new System.Drawing.Size(56, 23);
            this.btnStartMotion.TabIndex = 13;
            this.btnStartMotion.Text = "Run";
            this.btnStartMotion.UseVisualStyleBackColor = true;
            this.btnStartMotion.Click += new System.EventHandler(this.startMotion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "The size of the searchWindow, expressed in pixels, \r\nMin 1 Max: 32";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "the length of the edge of the subblock in pixels\r\nMin: 1 - Max: 256";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "windowSize";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
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
            this.global.Location = new System.Drawing.Point(4, 22);
            this.global.Margin = new System.Windows.Forms.Padding(2);
            this.global.Name = "global";
            this.global.Size = new System.Drawing.Size(831, 151);
            this.global.TabIndex = 4;
            this.global.Text = "Global Hist";
            this.global.UseVisualStyleBackColor = true;
            // 
            // txtGlobalFraction
            // 
            this.txtGlobalFraction.Location = new System.Drawing.Point(76, 81);
            this.txtGlobalFraction.Margin = new System.Windows.Forms.Padding(2);
            this.txtGlobalFraction.Mask = "0.000";
            this.txtGlobalFraction.Name = "txtGlobalFraction";
            this.txtGlobalFraction.PromptChar = ' ';
            this.txtGlobalFraction.Size = new System.Drawing.Size(76, 20);
            this.txtGlobalFraction.TabIndex = 22;
            this.txtGlobalFraction.Text = "025";
            // 
            // txtGlobalBinCount
            // 
            this.txtGlobalBinCount.Location = new System.Drawing.Point(76, 15);
            this.txtGlobalBinCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtGlobalBinCount.Mask = "000";
            this.txtGlobalBinCount.Name = "txtGlobalBinCount";
            this.txtGlobalBinCount.PromptChar = ' ';
            this.txtGlobalBinCount.Size = new System.Drawing.Size(76, 20);
            this.txtGlobalBinCount.TabIndex = 21;
            this.txtGlobalBinCount.Text = "51";
            // 
            // btnStartGlobalHist
            // 
            this.btnStartGlobalHist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartGlobalHist.Enabled = false;
            this.btnStartGlobalHist.Location = new System.Drawing.Point(758, 115);
            this.btnStartGlobalHist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartGlobalHist.Name = "btnStartGlobalHist";
            this.btnStartGlobalHist.Size = new System.Drawing.Size(56, 23);
            this.btnStartGlobalHist.TabIndex = 20;
            this.btnStartGlobalHist.Text = "Run";
            this.btnStartGlobalHist.UseVisualStyleBackColor = true;
            this.btnStartGlobalHist.Click += new System.EventHandler(this.startGlobalHist_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(164, 84);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(244, 26);
            this.label9.TabIndex = 19;
            this.label9.Text = "Fraction of pixels that ends up in a different basket\r\nMin 0 - Max 1\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(164, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 26);
            this.label10.TabIndex = 18;
            this.label10.Text = "Number of baskets/bins\r\nMin: 1 -  Max 256";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 84);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "fraction";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
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
            this.local.Location = new System.Drawing.Point(4, 22);
            this.local.Margin = new System.Windows.Forms.Padding(2);
            this.local.Name = "local";
            this.local.Size = new System.Drawing.Size(831, 151);
            this.local.TabIndex = 5;
            this.local.Text = "Local Hist";
            this.local.UseVisualStyleBackColor = true;
            // 
            // cmbLocalHistNrOfBlocks
            // 
            this.cmbLocalHistNrOfBlocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalHistNrOfBlocks.FormattingEnabled = true;
            this.cmbLocalHistNrOfBlocks.Location = new System.Drawing.Point(419, 29);
            this.cmbLocalHistNrOfBlocks.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLocalHistNrOfBlocks.Name = "cmbLocalHistNrOfBlocks";
            this.cmbLocalHistNrOfBlocks.Size = new System.Drawing.Size(92, 21);
            this.cmbLocalHistNrOfBlocks.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(514, 32);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(179, 39);
            this.label18.TabIndex = 32;
            this.label18.Text = "the number of different blocks used, \r\ne.g. 1,2,4,9,16,25,36...\r\nMin:1 - Max: 400" +
    "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(357, 32);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "nrOfBlocks";
            // 
            // txtLocalHistFraction
            // 
            this.txtLocalHistFraction.Location = new System.Drawing.Point(83, 95);
            this.txtLocalHistFraction.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocalHistFraction.Mask = "0.000";
            this.txtLocalHistFraction.Name = "txtLocalHistFraction";
            this.txtLocalHistFraction.PromptChar = ' ';
            this.txtLocalHistFraction.Size = new System.Drawing.Size(76, 20);
            this.txtLocalHistFraction.TabIndex = 29;
            this.txtLocalHistFraction.Text = "04";
            // 
            // txtLocalHistBinCount
            // 
            this.txtLocalHistBinCount.Location = new System.Drawing.Point(83, 29);
            this.txtLocalHistBinCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocalHistBinCount.Mask = "000";
            this.txtLocalHistBinCount.Name = "txtLocalHistBinCount";
            this.txtLocalHistBinCount.PromptChar = ' ';
            this.txtLocalHistBinCount.Size = new System.Drawing.Size(76, 20);
            this.txtLocalHistBinCount.TabIndex = 28;
            this.txtLocalHistBinCount.Text = "32";
            // 
            // btnStartLocalHistogram
            // 
            this.btnStartLocalHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartLocalHistogram.Enabled = false;
            this.btnStartLocalHistogram.Location = new System.Drawing.Point(758, 110);
            this.btnStartLocalHistogram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartLocalHistogram.Name = "btnStartLocalHistogram";
            this.btnStartLocalHistogram.Size = new System.Drawing.Size(56, 23);
            this.btnStartLocalHistogram.TabIndex = 27;
            this.btnStartLocalHistogram.Text = "Run";
            this.btnStartLocalHistogram.UseVisualStyleBackColor = true;
            this.btnStartLocalHistogram.Click += new System.EventHandler(this.StartLocalHistogram_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(170, 98);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(244, 26);
            this.label13.TabIndex = 26;
            this.label13.Text = "Fraction of pixels that ends up in a different basket\r\nMin 0 - Max 1\r\n";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(170, 32);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 26);
            this.label14.TabIndex = 25;
            this.label14.Text = "Number of baskets/bins\r\nMin: 1 -  Max 256";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 98);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "fraction";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 32);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "binCount";
            // 
            // general
            // 
            this.general.Controls.Add(this.label38);
            this.general.Controls.Add(this.label37);
            this.general.Controls.Add(this.txtTwinDelta);
            this.general.Controls.Add(this.txtTwinGamma);
            this.general.Controls.Add(this.label35);
            this.general.Controls.Add(this.label36);
            this.general.Controls.Add(this.txtTwinBeta);
            this.general.Controls.Add(this.txtTwinAlfa);
            this.general.Controls.Add(this.label34);
            this.general.Controls.Add(this.label33);
            this.general.Controls.Add(this.cmbTwinNrOfBlocks);
            this.general.Controls.Add(this.label31);
            this.general.Controls.Add(this.label32);
            this.general.Controls.Add(this.btnStartTwin);
            this.general.Controls.Add(this.txtTwinCompBins);
            this.general.Controls.Add(this.label22);
            this.general.Controls.Add(this.label23);
            this.general.Location = new System.Drawing.Point(4, 22);
            this.general.Margin = new System.Windows.Forms.Padding(2);
            this.general.Name = "general";
            this.general.Size = new System.Drawing.Size(831, 151);
            this.general.TabIndex = 6;
            this.general.Text = "Twin Comparison";
            this.general.UseVisualStyleBackColor = true;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(362, 93);
            this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(289, 13);
            this.label38.TabIndex = 46;
            this.label38.Text = "Upper Threshold = gamma * mean difference + delta * stdev";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(8, 93);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(270, 13);
            this.label37.TabIndex = 45;
            this.label37.Text = "Lower Threshold = alfa * mean difference + beta * stdev";
            // 
            // txtTwinDelta
            // 
            this.txtTwinDelta.Location = new System.Drawing.Point(586, 117);
            this.txtTwinDelta.Margin = new System.Windows.Forms.Padding(2);
            this.txtTwinDelta.Mask = "0.00";
            this.txtTwinDelta.Name = "txtTwinDelta";
            this.txtTwinDelta.PromptChar = ' ';
            this.txtTwinDelta.Size = new System.Drawing.Size(76, 20);
            this.txtTwinDelta.TabIndex = 44;
            this.txtTwinDelta.Text = "200";
            // 
            // txtTwinGamma
            // 
            this.txtTwinGamma.Location = new System.Drawing.Point(432, 117);
            this.txtTwinGamma.Margin = new System.Windows.Forms.Padding(2);
            this.txtTwinGamma.Mask = "0.00";
            this.txtTwinGamma.Name = "txtTwinGamma";
            this.txtTwinGamma.PromptChar = ' ';
            this.txtTwinGamma.Size = new System.Drawing.Size(76, 20);
            this.txtTwinGamma.TabIndex = 43;
            this.txtTwinGamma.Text = "100";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(525, 119);
            this.label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(30, 13);
            this.label35.TabIndex = 42;
            this.label35.Text = "delta";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(364, 119);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(41, 13);
            this.label36.TabIndex = 41;
            this.label36.Text = "gamma";
            // 
            // txtTwinBeta
            // 
            this.txtTwinBeta.Location = new System.Drawing.Point(221, 117);
            this.txtTwinBeta.Margin = new System.Windows.Forms.Padding(2);
            this.txtTwinBeta.Mask = "0.00";
            this.txtTwinBeta.Name = "txtTwinBeta";
            this.txtTwinBeta.PromptChar = ' ';
            this.txtTwinBeta.Size = new System.Drawing.Size(76, 20);
            this.txtTwinBeta.TabIndex = 40;
            this.txtTwinBeta.Text = "000";
            // 
            // txtTwinAlfa
            // 
            this.txtTwinAlfa.Location = new System.Drawing.Point(77, 117);
            this.txtTwinAlfa.Margin = new System.Windows.Forms.Padding(2);
            this.txtTwinAlfa.Mask = "0.00";
            this.txtTwinAlfa.Name = "txtTwinAlfa";
            this.txtTwinAlfa.PromptChar = ' ';
            this.txtTwinAlfa.Size = new System.Drawing.Size(76, 20);
            this.txtTwinAlfa.TabIndex = 39;
            this.txtTwinAlfa.Text = "150";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(163, 119);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(28, 13);
            this.label34.TabIndex = 38;
            this.label34.Text = "beta";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 119);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 13);
            this.label33.TabIndex = 37;
            this.label33.Text = "alfa";
            // 
            // cmbTwinNrOfBlocks
            // 
            this.cmbTwinNrOfBlocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTwinNrOfBlocks.FormattingEnabled = true;
            this.cmbTwinNrOfBlocks.Location = new System.Drawing.Point(430, 20);
            this.cmbTwinNrOfBlocks.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTwinNrOfBlocks.Name = "cmbTwinNrOfBlocks";
            this.cmbTwinNrOfBlocks.Size = new System.Drawing.Size(92, 21);
            this.cmbTwinNrOfBlocks.TabIndex = 36;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(525, 23);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(179, 39);
            this.label31.TabIndex = 35;
            this.label31.Text = "the number of different blocks used, \r\ne.g. 1,2,4,9,16,25,36...\r\nMin:1 - Max: 400" +
    "";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(368, 23);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 13);
            this.label32.TabIndex = 34;
            this.label32.Text = "nrOfBlocks";
            // 
            // btnStartTwin
            // 
            this.btnStartTwin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartTwin.Enabled = false;
            this.btnStartTwin.Location = new System.Drawing.Point(745, 115);
            this.btnStartTwin.Name = "btnStartTwin";
            this.btnStartTwin.Size = new System.Drawing.Size(75, 23);
            this.btnStartTwin.TabIndex = 32;
            this.btnStartTwin.Text = "run";
            this.btnStartTwin.UseVisualStyleBackColor = true;
            this.btnStartTwin.Click += new System.EventHandler(this.StartTwinComp_Click);
            // 
            // txtTwinCompBins
            // 
            this.txtTwinCompBins.Location = new System.Drawing.Point(76, 20);
            this.txtTwinCompBins.Margin = new System.Windows.Forms.Padding(2);
            this.txtTwinCompBins.Mask = "000";
            this.txtTwinCompBins.Name = "txtTwinCompBins";
            this.txtTwinCompBins.PromptChar = ' ';
            this.txtTwinCompBins.Size = new System.Drawing.Size(76, 20);
            this.txtTwinCompBins.TabIndex = 31;
            this.txtTwinCompBins.Text = "32";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(163, 23);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(120, 26);
            this.label22.TabIndex = 30;
            this.label22.Text = "Number of baskets/bins\r\nMin: 1 -  Max 256";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 23);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(49, 13);
            this.label23.TabIndex = 29;
            this.label23.Text = "binCount";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 574);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(865, 22);
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
            this.toolStripProgressBar1.Size = new System.Drawing.Size(75, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // ShotDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 596);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mnMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(801, 89);
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
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmbSpeedup;
        private System.Windows.Forms.ComboBox cmbTwinNrOfBlocks;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.MaskedTextBox txtTwinAlfa;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.MaskedTextBox txtTwinDelta;
        private System.Windows.Forms.MaskedTextBox txtTwinGamma;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.MaskedTextBox txtTwinBeta;
        private System.Windows.Forms.Label label38;
    }
}
