namespace FingerprintNetSample
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoExtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoIdentifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrollToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.enrollToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.startEnrollToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblThreshold2 = new System.Windows.Forms.Label();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuality = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lvwFPReaders = new System.Windows.Forms.ListView();
            this.prgbMatching = new FingerprintNetSample.ColorProgressBar();
            this.prgbQuality = new FingerprintNetSample.ColorProgressBar();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(67, 22);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageAsToolStripMenuItem,
            this.openImageToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(68, 48);
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bmp";
            this.saveFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatusMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 530);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(600, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatusMessage
            // 
            this.tsslStatusMessage.Name = "tsslStatusMessage";
            this.tsslStatusMessage.Size = new System.Drawing.Size(118, 17);
            this.tsslStatusMessage.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.dBToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractToolStripMenuItem,
            this.identifyToolStripMenuItem,
            this.enrollToolStripMenuItem2,
            this.toolStripSeparator3,
            this.loadImageToolStripMenuItem,
            this.saveImageToolStripMenuItem1,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractToolStripMenuItem1,
            this.autoExtractToolStripMenuItem});
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.extractToolStripMenuItem.Text = "Extract";
            // 
            // extractToolStripMenuItem1
            // 
            this.extractToolStripMenuItem1.Name = "extractToolStripMenuItem1";
            this.extractToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.extractToolStripMenuItem1.Text = "Extract";
            this.extractToolStripMenuItem1.Click += new System.EventHandler(this.extractToolStripMenuItem1_Click);
            // 
            // autoExtractToolStripMenuItem
            // 
            this.autoExtractToolStripMenuItem.CheckOnClick = true;
            this.autoExtractToolStripMenuItem.Name = "autoExtractToolStripMenuItem";
            this.autoExtractToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.autoExtractToolStripMenuItem.Text = "Auto Extract";
            // 
            // identifyToolStripMenuItem
            // 
            this.identifyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.identifyToolStripMenuItem1,
            this.autoIdentifyToolStripMenuItem});
            this.identifyToolStripMenuItem.Name = "identifyToolStripMenuItem";
            this.identifyToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.identifyToolStripMenuItem.Text = "Identify";
            // 
            // identifyToolStripMenuItem1
            // 
            this.identifyToolStripMenuItem1.Name = "identifyToolStripMenuItem1";
            this.identifyToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.identifyToolStripMenuItem1.Text = "Identify";
            this.identifyToolStripMenuItem1.Click += new System.EventHandler(this.identifyToolStripMenuItem1_Click);
            // 
            // autoIdentifyToolStripMenuItem
            // 
            this.autoIdentifyToolStripMenuItem.CheckOnClick = true;
            this.autoIdentifyToolStripMenuItem.Name = "autoIdentifyToolStripMenuItem";
            this.autoIdentifyToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.autoIdentifyToolStripMenuItem.Text = "Auto Identify";
            // 
            // enrollToolStripMenuItem2
            // 
            this.enrollToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enrollToolStripMenuItem3,
            this.startEnrollToolStripMenuItem1});
            this.enrollToolStripMenuItem2.Name = "enrollToolStripMenuItem2";
            this.enrollToolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.enrollToolStripMenuItem2.Text = "Enroll";
            // 
            // enrollToolStripMenuItem3
            // 
            this.enrollToolStripMenuItem3.Name = "enrollToolStripMenuItem3";
            this.enrollToolStripMenuItem3.Size = new System.Drawing.Size(131, 22);
            this.enrollToolStripMenuItem3.Text = "Enroll";
            this.enrollToolStripMenuItem3.Click += new System.EventHandler(this.enrollToolStripMenuItem3_Click);
            // 
            // startEnrollToolStripMenuItem1
            // 
            this.startEnrollToolStripMenuItem1.Name = "startEnrollToolStripMenuItem1";
            this.startEnrollToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.startEnrollToolStripMenuItem1.Text = "Start Enroll";
            this.startEnrollToolStripMenuItem1.Click += new System.EventHandler(this.startEnrollToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem1
            // 
            this.saveImageToolStripMenuItem1.Name = "saveImageToolStripMenuItem1";
            this.saveImageToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.saveImageToolStripMenuItem1.Text = "Save Image";
            this.saveImageToolStripMenuItem1.Click += new System.EventHandler(this.saveImageToolStripMenuItem1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences...";
            // 
            // dBToolStripMenuItem
            // 
            this.dBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearDatabaseToolStripMenuItem});
            this.dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            this.dBToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.dBToolStripMenuItem.Text = "DB";
            // 
            // clearDatabaseToolStripMenuItem
            // 
            this.clearDatabaseToolStripMenuItem.Name = "clearDatabaseToolStripMenuItem";
            this.clearDatabaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearDatabaseToolStripMenuItem.Text = "Clear Database";
            this.clearDatabaseToolStripMenuItem.Click += new System.EventHandler(this.clearDatabaseToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "sensorFingerIn.bmp");
            this.imageList1.Images.SetKeyName(1, "sensorFingerout.bmp");
            this.imageList1.Images.SetKeyName(2, "sensorFingerImageCap.bmp");
            // 
            // lblThreshold2
            // 
            this.lblThreshold2.AutoSize = true;
            this.lblThreshold2.Location = new System.Drawing.Point(8, 513);
            this.lblThreshold2.Name = "lblThreshold2";
            this.lblThreshold2.Size = new System.Drawing.Size(54, 13);
            this.lblThreshold2.TabIndex = 9;
            this.lblThreshold2.Text = "Threshold";
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(8, 497);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(9, 13);
            this.lblThreshold.TabIndex = 8;
            this.lblThreshold.Text = "|";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Bad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Good";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Matching Score";
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(8, 406);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(86, 13);
            this.lblQuality.TabIndex = 10;
            this.lblQuality.Text = "Template Quality";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip2;
            this.pictureBox1.Location = new System.Drawing.Point(11, 27);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(390, 355);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 357);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lvwFPReaders
            // 
            this.lvwFPReaders.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lvwFPReaders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwFPReaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwFPReaders.GridLines = true;
            this.lvwFPReaders.LabelWrap = false;
            this.lvwFPReaders.LargeImageList = this.imageList1;
            this.lvwFPReaders.Location = new System.Drawing.Point(0, 0);
            this.lvwFPReaders.MultiSelect = false;
            this.lvwFPReaders.Name = "lvwFPReaders";
            this.lvwFPReaders.ShowGroups = false;
            this.lvwFPReaders.Size = new System.Drawing.Size(600, 552);
            this.lvwFPReaders.TabIndex = 15;
            this.lvwFPReaders.UseCompatibleStateImageBehavior = false;
            // 
            // prgbMatching
            // 
            this.prgbMatching.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prgbMatching.Location = new System.Drawing.Point(23, 488);
            this.prgbMatching.Maximum = 100;
            this.prgbMatching.Minimum = 0;
            this.prgbMatching.Name = "prgbMatching";
            this.prgbMatching.Padding = new System.Windows.Forms.Padding(5);
            this.prgbMatching.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.prgbMatching.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.prgbMatching.Size = new System.Drawing.Size(553, 23);
            this.prgbMatching.Step = 3;
            this.prgbMatching.TabIndex = 17;
            this.prgbMatching.Value = 0;
            // 
            // prgbQuality
            // 
            this.prgbQuality.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prgbQuality.Location = new System.Drawing.Point(12, 422);
            this.prgbQuality.Maximum = 100;
            this.prgbQuality.Minimum = 0;
            this.prgbQuality.Name = "prgbQuality";
            this.prgbQuality.Padding = new System.Windows.Forms.Padding(5);
            this.prgbQuality.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.prgbQuality.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.prgbQuality.Size = new System.Drawing.Size(553, 23);
            this.prgbQuality.Step = 3;
            this.prgbQuality.TabIndex = 18;
            this.prgbQuality.Value = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 552);
            this.Controls.Add(this.prgbQuality);
            this.Controls.Add(this.prgbMatching);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblQuality);
            this.Controls.Add(this.lblThreshold2);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lvwFPReaders);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem saveImageAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem autoExtractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem identifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem identifyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem autoIdentifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enrollToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem enrollToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem startEnrollToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDatabaseToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblThreshold2;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView lvwFPReaders;
        private ColorProgressBar prgbMatching;
        private ColorProgressBar prgbQuality;
    }
}