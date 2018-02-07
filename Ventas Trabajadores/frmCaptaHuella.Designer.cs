namespace Ventas_Trabajadores
{
    partial class frmCaptaHuella
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaptaHuella));
            this.lblNombTrabajador = new DevExpress.XtraEditors.LabelControl();
            this.axGrFingerXCtrl1 = new AxGrFingerXLib.AxGrFingerXCtrl();
            this.btnExtraer = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lvwFPReaders = new System.Windows.Forms.ListView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblThreshold2 = new System.Windows.Forms.Label();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.prgbConsolidation = new FingerprintNetSample.ColorProgressBar();
            this.prgbMatching = new FingerprintNetSample.ColorProgressBar();
            this.prgbQuality = new FingerprintNetSample.ColorProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.axGrFingerXCtrl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombTrabajador
            // 
            this.lblNombTrabajador.Appearance.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombTrabajador.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblNombTrabajador.Location = new System.Drawing.Point(23, -1);
            this.lblNombTrabajador.Name = "lblNombTrabajador";
            this.lblNombTrabajador.Size = new System.Drawing.Size(197, 45);
            this.lblNombTrabajador.TabIndex = 0;
            this.lblNombTrabajador.Text = "Nombre del Trabajador";
            // 
            // axGrFingerXCtrl1
            // 
            this.axGrFingerXCtrl1.Enabled = true;
            this.axGrFingerXCtrl1.Location = new System.Drawing.Point(253, 12);
            this.axGrFingerXCtrl1.Name = "axGrFingerXCtrl1";
            this.axGrFingerXCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGrFingerXCtrl1.OcxState")));
            this.axGrFingerXCtrl1.Size = new System.Drawing.Size(32, 32);
            this.axGrFingerXCtrl1.TabIndex = 2;
            // 
            // btnExtraer
            // 
            this.btnExtraer.Location = new System.Drawing.Point(8, 315);
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(75, 23);
            this.btnExtraer.TabIndex = 3;
            this.btnExtraer.Text = "EXTRAER";
            this.btnExtraer.UseVisualStyleBackColor = true;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(145, 315);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lvwFPReaders
            // 
            this.lvwFPReaders.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lvwFPReaders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwFPReaders.GridLines = true;
            this.lvwFPReaders.LabelWrap = false;
            this.lvwFPReaders.Location = new System.Drawing.Point(2, 344);
            this.lvwFPReaders.MultiSelect = false;
            this.lvwFPReaders.Name = "lvwFPReaders";
            this.lvwFPReaders.ShowGroups = false;
            this.lvwFPReaders.Size = new System.Drawing.Size(269, 43);
            this.lvwFPReaders.TabIndex = 11;
            this.lvwFPReaders.UseCompatibleStateImageBehavior = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bmp";
            this.saveFileDialog1.Filter = "Bitmap File (*.bmp)|*.bmp";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "sensorFingerIn.bmp");
            this.imageList1.Images.SetKeyName(1, "sensorFingerout.bmp");
            this.imageList1.Images.SetKeyName(2, "sensorFingerImageCap.bmp");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatusMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(297, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatusMessage
            // 
            this.tsslStatusMessage.Name = "tsslStatusMessage";
            this.tsslStatusMessage.Size = new System.Drawing.Size(118, 17);
            this.tsslStatusMessage.Text = "toolStripStatusLabel1";
            // 
            // lblThreshold2
            // 
            this.lblThreshold2.AutoSize = true;
            this.lblThreshold2.Location = new System.Drawing.Point(29, 356);
            this.lblThreshold2.Name = "lblThreshold2";
            this.lblThreshold2.Size = new System.Drawing.Size(54, 13);
            this.lblThreshold2.TabIndex = 13;
            this.lblThreshold2.Text = "Threshold";
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(89, 356);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(9, 13);
            this.lblThreshold.TabIndex = 14;
            this.lblThreshold.Text = "|";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(8, 37);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(263, 243);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 243);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // prgbConsolidation
            // 
            this.prgbConsolidation.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prgbConsolidation.Location = new System.Drawing.Point(32, 225);
            this.prgbConsolidation.Maximum = 100;
            this.prgbConsolidation.Minimum = 0;
            this.prgbConsolidation.Name = "prgbConsolidation";
            this.prgbConsolidation.Padding = new System.Windows.Forms.Padding(5);
            this.prgbConsolidation.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.prgbConsolidation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.prgbConsolidation.Size = new System.Drawing.Size(263, 23);
            this.prgbConsolidation.Step = 3;
            this.prgbConsolidation.TabIndex = 16;
            this.prgbConsolidation.Value = 0;
            // 
            // prgbMatching
            // 
            this.prgbMatching.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prgbMatching.Location = new System.Drawing.Point(32, 196);
            this.prgbMatching.Maximum = 100;
            this.prgbMatching.Minimum = 0;
            this.prgbMatching.Name = "prgbMatching";
            this.prgbMatching.Padding = new System.Windows.Forms.Padding(5);
            this.prgbMatching.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.prgbMatching.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.prgbMatching.Size = new System.Drawing.Size(263, 23);
            this.prgbMatching.Step = 3;
            this.prgbMatching.TabIndex = 17;
            this.prgbMatching.Value = 0;
            // 
            // prgbQuality
            // 
            this.prgbQuality.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prgbQuality.Location = new System.Drawing.Point(8, 286);
            this.prgbQuality.Maximum = 100;
            this.prgbQuality.Minimum = 0;
            this.prgbQuality.Name = "prgbQuality";
            this.prgbQuality.Padding = new System.Windows.Forms.Padding(5);
            this.prgbQuality.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.prgbQuality.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.prgbQuality.Size = new System.Drawing.Size(263, 23);
            this.prgbQuality.Step = 3;
            this.prgbQuality.TabIndex = 18;
            this.prgbQuality.Value = 0;
            // 
            // frmCaptaHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 410);
            this.Controls.Add(this.prgbQuality);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.lblThreshold2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvwFPReaders);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnExtraer);
            this.Controls.Add(this.axGrFingerXCtrl1);
            this.Controls.Add(this.lblNombTrabajador);
            this.Controls.Add(this.prgbMatching);
            this.Controls.Add(this.prgbConsolidation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCaptaHuella";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capta Huella";
            this.Activated += new System.EventHandler(this.frmCaptaHuella_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCaptaHuella_FormClosing);
            this.Load += new System.EventHandler(this.frmCaptaHuella_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axGrFingerXCtrl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblNombTrabajador;
        private AxGrFingerXLib.AxGrFingerXCtrl axGrFingerXCtrl1;
        private System.Windows.Forms.Button btnExtraer;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListView lvwFPReaders;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusMessage;
        private System.Windows.Forms.Label lblThreshold2;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FingerprintNetSample.ColorProgressBar prgbConsolidation;
        private FingerprintNetSample.ColorProgressBar prgbMatching;
        private FingerprintNetSample.ColorProgressBar prgbQuality;
    }
}