namespace PRUtilidades.Formas
{
    partial class frmAyuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAyuda));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grcDatosOpcion = new DevExpress.XtraEditors.GroupControl();
            this.xtpDocumentacion = new DevExpress.XtraTab.XtraTabControl();
            this.imgPequeñas = new DevExpress.Utils.ImageCollection(this.components);
            this.xtpVideo = new DevExpress.XtraTab.XtraTabPage();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.xtpManualSistema = new DevExpress.XtraTab.XtraTabPage();
            this.wbManualSistema = new System.Windows.Forms.WebBrowser();
            this.xtpManualProcedimiento = new DevExpress.XtraTab.XtraTabPage();
            this.wbManualProcedimiento = new System.Windows.Forms.WebBrowser();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombOpcion = new DevExpress.XtraEditors.TextEdit();
            this.txtCodOpcion = new DevExpress.XtraEditors.TextEdit();
            this.lblOpcion = new DevExpress.XtraEditors.LabelControl();
            this.dateEdFecMovimiento = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDatosOpcion)).BeginInit();
            this.grcDatosOpcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtpDocumentacion)).BeginInit();
            this.xtpDocumentacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPequeñas)).BeginInit();
            this.xtpVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.xtpManualSistema.SuspendLayout();
            this.xtpManualProcedimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombOpcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodOpcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdFecMovimiento.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdFecMovimiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcDatosOpcion);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(522, 178, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(887, 662);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grcDatosOpcion
            // 
            this.grcDatosOpcion.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcDatosOpcion.AppearanceCaption.Options.UseFont = true;
            this.grcDatosOpcion.Controls.Add(this.xtpDocumentacion);
            this.grcDatosOpcion.Controls.Add(this.labelControl1);
            this.grcDatosOpcion.Controls.Add(this.txtNombOpcion);
            this.grcDatosOpcion.Controls.Add(this.txtCodOpcion);
            this.grcDatosOpcion.Controls.Add(this.lblOpcion);
            this.grcDatosOpcion.Controls.Add(this.dateEdFecMovimiento);
            this.grcDatosOpcion.Location = new System.Drawing.Point(2, 2);
            this.grcDatosOpcion.Name = "grcDatosOpcion";
            this.grcDatosOpcion.Size = new System.Drawing.Size(883, 658);
            this.grcDatosOpcion.TabIndex = 4;
            this.grcDatosOpcion.Visible = false;
            // 
            // xtpDocumentacion
            // 
            this.xtpDocumentacion.Images = this.imgPequeñas;
            this.xtpDocumentacion.Location = new System.Drawing.Point(0, 0);
            this.xtpDocumentacion.Name = "xtpDocumentacion";
            this.xtpDocumentacion.SelectedTabPage = this.xtpVideo;
            this.xtpDocumentacion.Size = new System.Drawing.Size(883, 658);
            this.xtpDocumentacion.TabIndex = 5;
            this.xtpDocumentacion.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpVideo,
            this.xtpManualSistema,
            this.xtpManualProcedimiento});
            // 
            // imgPequeñas
            // 
            this.imgPequeñas.ImageSize = new System.Drawing.Size(26, 26);
            this.imgPequeñas.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgPequeñas.ImageStream")));
            this.imgPequeñas.Images.SetKeyName(0, "VideoTutorial.png");
            this.imgPequeñas.Images.SetKeyName(1, "ManualSistema.png");
            this.imgPequeñas.Images.SetKeyName(2, "ManualProcedimiento.png");
            // 
            // xtpVideo
            // 
            this.xtpVideo.Controls.Add(this.axWindowsMediaPlayer1);
            this.xtpVideo.ImageIndex = 0;
            this.xtpVideo.Name = "xtpVideo";
            this.xtpVideo.Size = new System.Drawing.Size(877, 617);
            this.xtpVideo.Text = "Video Tutorial";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(877, 617);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // xtpManualSistema
            // 
            this.xtpManualSistema.Controls.Add(this.wbManualSistema);
            this.xtpManualSistema.ImageIndex = 1;
            this.xtpManualSistema.Name = "xtpManualSistema";
            this.xtpManualSistema.PageVisible = false;
            this.xtpManualSistema.Size = new System.Drawing.Size(877, 617);
            this.xtpManualSistema.Text = "Manual de Sistema";
            // 
            // wbManualSistema
            // 
            this.wbManualSistema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbManualSistema.Location = new System.Drawing.Point(0, 0);
            this.wbManualSistema.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbManualSistema.Name = "wbManualSistema";
            this.wbManualSistema.Size = new System.Drawing.Size(881, 612);
            this.wbManualSistema.TabIndex = 0;
            this.wbManualSistema.Visible = false;
            // 
            // xtpManualProcedimiento
            // 
            this.xtpManualProcedimiento.Controls.Add(this.wbManualProcedimiento);
            this.xtpManualProcedimiento.ImageIndex = 2;
            this.xtpManualProcedimiento.Name = "xtpManualProcedimiento";
            this.xtpManualProcedimiento.PageVisible = false;
            this.xtpManualProcedimiento.Size = new System.Drawing.Size(877, 617);
            this.xtpManualProcedimiento.Text = "Manual de Procedimiento";
            // 
            // wbManualProcedimiento
            // 
            this.wbManualProcedimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbManualProcedimiento.Location = new System.Drawing.Point(0, 0);
            this.wbManualProcedimiento.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbManualProcedimiento.Name = "wbManualProcedimiento";
            this.wbManualProcedimiento.Size = new System.Drawing.Size(881, 612);
            this.wbManualProcedimiento.TabIndex = 0;
            this.wbManualProcedimiento.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(601, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Fec. Actualización";
            // 
            // txtNombOpcion
            // 
            this.txtNombOpcion.Enabled = false;
            this.txtNombOpcion.Location = new System.Drawing.Point(104, 28);
            this.txtNombOpcion.Name = "txtNombOpcion";
            this.txtNombOpcion.Size = new System.Drawing.Size(491, 20);
            this.txtNombOpcion.TabIndex = 2;
            // 
            // txtCodOpcion
            // 
            this.txtCodOpcion.Enabled = false;
            this.txtCodOpcion.Location = new System.Drawing.Point(44, 28);
            this.txtCodOpcion.Name = "txtCodOpcion";
            this.txtCodOpcion.Size = new System.Drawing.Size(54, 20);
            this.txtCodOpcion.TabIndex = 1;
            // 
            // lblOpcion
            // 
            this.lblOpcion.Location = new System.Drawing.Point(5, 31);
            this.lblOpcion.Name = "lblOpcion";
            this.lblOpcion.Size = new System.Drawing.Size(33, 13);
            this.lblOpcion.TabIndex = 0;
            this.lblOpcion.Text = "Opción";
            // 
            // dateEdFecMovimiento
            // 
            this.dateEdFecMovimiento.EditValue = null;
            this.dateEdFecMovimiento.Enabled = false;
            this.dateEdFecMovimiento.Location = new System.Drawing.Point(693, 27);
            this.dateEdFecMovimiento.Name = "dateEdFecMovimiento";
            this.dateEdFecMovimiento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdFecMovimiento.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdFecMovimiento.Properties.Mask.EditMask = "";
            this.dateEdFecMovimiento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateEdFecMovimiento.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateEdFecMovimiento.Size = new System.Drawing.Size(147, 20);
            this.dateEdFecMovimiento.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(887, 662);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcDatosOpcion;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(887, 662);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 662);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAyuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayuda del Sistema";
            this.Load += new System.EventHandler(this.frmAyuda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDatosOpcion)).EndInit();
            this.grcDatosOpcion.ResumeLayout(false);
            this.grcDatosOpcion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtpDocumentacion)).EndInit();
            this.xtpDocumentacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPequeñas)).EndInit();
            this.xtpVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.xtpManualSistema.ResumeLayout(false);
            this.xtpManualProcedimiento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNombOpcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodOpcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdFecMovimiento.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdFecMovimiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl grcDatosOpcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraTab.XtraTabControl xtpDocumentacion;
        private DevExpress.XtraTab.XtraTabPage xtpVideo;
        private AxWMPLib.AxWindowsMediaPlayer wmpVideoTutorial;
        private DevExpress.XtraTab.XtraTabPage xtpManualSistema;
        private DevExpress.XtraEditors.TextEdit txtNombOpcion;
        private DevExpress.XtraEditors.TextEdit txtCodOpcion;
        private DevExpress.XtraEditors.LabelControl lblOpcion;
        private System.Windows.Forms.WebBrowser wbManualSistema;
        private DevExpress.XtraTab.XtraTabPage xtpManualProcedimiento;
        private System.Windows.Forms.WebBrowser wbManualProcedimiento;
        private DevExpress.Utils.ImageCollection imgPequeñas;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateEdFecMovimiento;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}