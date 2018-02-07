namespace Ventas_Trabajadores
{
    partial class frmRegistroBiometrico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroBiometrico));
            this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
            this.txtNombTrabajador = new System.Windows.Forms.TextBox();
            this.txtCodTrabajador = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvwFPReaders = new System.Windows.Forms.ListView();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblThreshold2 = new System.Windows.Forms.Label();
            this.prgbMatching = new FingerprintNetSample.ColorProgressBar();
            this.axGrFingerXCtrl1 = new AxGrFingerXLib.AxGrFingerXCtrl();
            this.gbDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGrFingerXCtrl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosGenerales
            // 
            this.gbDatosGenerales.Controls.Add(this.txtNombTrabajador);
            this.gbDatosGenerales.Controls.Add(this.txtCodTrabajador);
            this.gbDatosGenerales.Location = new System.Drawing.Point(13, 13);
            this.gbDatosGenerales.Name = "gbDatosGenerales";
            this.gbDatosGenerales.Size = new System.Drawing.Size(441, 52);
            this.gbDatosGenerales.TabIndex = 0;
            this.gbDatosGenerales.TabStop = false;
            this.gbDatosGenerales.Text = "Datos Generales";
            // 
            // txtNombTrabajador
            // 
            this.txtNombTrabajador.Location = new System.Drawing.Point(72, 19);
            this.txtNombTrabajador.Name = "txtNombTrabajador";
            this.txtNombTrabajador.Size = new System.Drawing.Size(358, 21);
            this.txtNombTrabajador.TabIndex = 1;
            // 
            // txtCodTrabajador
            // 
            this.txtCodTrabajador.Location = new System.Drawing.Point(16, 20);
            this.txtCodTrabajador.Name = "txtCodTrabajador";
            this.txtCodTrabajador.Size = new System.Drawing.Size(50, 21);
            this.txtCodTrabajador.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(85, 71);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(263, 243);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 243);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatusMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(463, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatusMessage
            // 
            this.tsslStatusMessage.Name = "tsslStatusMessage";
            this.tsslStatusMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // lvwFPReaders
            // 
            this.lvwFPReaders.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lvwFPReaders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwFPReaders.GridLines = true;
            this.lvwFPReaders.LabelWrap = false;
            this.lvwFPReaders.Location = new System.Drawing.Point(12, 349);
            this.lvwFPReaders.MultiSelect = false;
            this.lvwFPReaders.Name = "lvwFPReaders";
            this.lvwFPReaders.ShowGroups = false;
            this.lvwFPReaders.Size = new System.Drawing.Size(264, 42);
            this.lvwFPReaders.TabIndex = 12;
            this.lvwFPReaders.UseCompatibleStateImageBehavior = false;
            this.lvwFPReaders.SelectedIndexChanged += new System.EventHandler(this.lvwFPReaders_SelectedIndexChanged);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(93, 361);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(11, 13);
            this.lblThreshold.TabIndex = 16;
            this.lblThreshold.Text = "|";
            // 
            // lblThreshold2
            // 
            this.lblThreshold2.AutoSize = true;
            this.lblThreshold2.Location = new System.Drawing.Point(22, 361);
            this.lblThreshold2.Name = "lblThreshold2";
            this.lblThreshold2.Size = new System.Drawing.Size(54, 13);
            this.lblThreshold2.TabIndex = 15;
            this.lblThreshold2.Text = "Threshold";
            // 
            // prgbMatching
            // 
            this.prgbMatching.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prgbMatching.Location = new System.Drawing.Point(84, 320);
            this.prgbMatching.Maximum = 100;
            this.prgbMatching.Minimum = 0;
            this.prgbMatching.Name = "prgbMatching";
            this.prgbMatching.Padding = new System.Windows.Forms.Padding(5);
            this.prgbMatching.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.prgbMatching.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.prgbMatching.Size = new System.Drawing.Size(264, 23);
            this.prgbMatching.Step = 3;
            this.prgbMatching.TabIndex = 18;
            this.prgbMatching.Value = 0;
            // 
            // axGrFingerXCtrl1
            // 
            this.axGrFingerXCtrl1.Enabled = true;
            this.axGrFingerXCtrl1.Location = new System.Drawing.Point(372, 100);
            this.axGrFingerXCtrl1.Name = "axGrFingerXCtrl1";
            this.axGrFingerXCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGrFingerXCtrl1.OcxState")));
            this.axGrFingerXCtrl1.Size = new System.Drawing.Size(32, 32);
            this.axGrFingerXCtrl1.TabIndex = 19;
            // 
            // frmRegistroBiometrico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 412);
            this.Controls.Add(this.axGrFingerXCtrl1);
            this.Controls.Add(this.prgbMatching);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.lblThreshold2);
            this.Controls.Add(this.lvwFPReaders);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbDatosGenerales);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistroBiometrico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro Biometrico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmRegistroBiometrico_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistroBiometrico_FormClosing);
            this.Load += new System.EventHandler(this.frmRegistroBiometrico_Load);
            this.gbDatosGenerales.ResumeLayout(false);
            this.gbDatosGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGrFingerXCtrl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosGenerales;
        private System.Windows.Forms.TextBox txtNombTrabajador;
        private System.Windows.Forms.TextBox txtCodTrabajador;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusMessage;
        private System.Windows.Forms.ListView lvwFPReaders;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Label lblThreshold2;
        private FingerprintNetSample.ColorProgressBar prgbMatching;
        private AxGrFingerXLib.AxGrFingerXCtrl axGrFingerXCtrl1;
    }
}