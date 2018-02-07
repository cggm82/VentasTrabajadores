namespace Ventas_Trabajadores
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtContraseña = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.img = new DevExpress.Utils.ImageCollection(this.components);
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContraseña.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Ventas_Trabajadores.Properties.Resources.LogoTD;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(283, 80);
            this.pictureEdit1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(104, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Código de Usuario";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(12, 120);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Contraseña";
            // 
            // txtCodUsuario
            // 
            this.txtCodUsuario.Location = new System.Drawing.Point(122, 89);
            this.txtCodUsuario.Name = "txtCodUsuario";
            this.txtCodUsuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodUsuario.Properties.Appearance.Options.UseFont = true;
            this.txtCodUsuario.Properties.MaxLength = 6;
            this.txtCodUsuario.Size = new System.Drawing.Size(150, 22);
            this.txtCodUsuario.TabIndex = 3;
            this.txtCodUsuario.Leave += new System.EventHandler(this.txtCodUsuario_Leave);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(122, 117);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Properties.Appearance.Options.UseFont = true;
            this.txtContraseña.Properties.MaxLength = 25;
            this.txtContraseña.Properties.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(150, 22);
            this.txtContraseña.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(12, 150);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 16);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Empresa";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(13, 178);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Sucursal";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.Location = new System.Drawing.Point(122, 147);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpresa.Properties.Appearance.Options.UseFont = true;
            this.cmbEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEmpresa.Properties.NullText = "";
            this.cmbEmpresa.Size = new System.Drawing.Size(150, 22);
            this.cmbEmpresa.TabIndex = 7;
            this.cmbEmpresa.EditValueChanged += new System.EventHandler(this.cmbEmpresa_EditValueChanged);
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.Location = new System.Drawing.Point(122, 175);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSucursal.Properties.Appearance.Options.UseFont = true;
            this.cmbSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSucursal.Properties.NullText = "";
            this.cmbSucursal.Size = new System.Drawing.Size(150, 22);
            this.cmbSucursal.TabIndex = 8;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.btnAceptar.ImageIndex = 0;
            this.btnAceptar.ImageList = this.img;
            this.btnAceptar.Location = new System.Drawing.Point(47, 222);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 33);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // img
            // 
            this.img.ImageSize = new System.Drawing.Size(24, 24);
            this.img.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("img.ImageStream")));
            this.img.Images.SetKeyName(0, "Add.png");
            this.img.Images.SetKeyName(1, "DeleteItem.png");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.ImageIndex = 1;
            this.btnCancelar.ImageList = this.img;
            this.btnCancelar.Location = new System.Drawing.Point(141, 222);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 33);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "VS2010";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 267);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbSucursal);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtCodUsuario);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inicio de sesión";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContraseña.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCodUsuario;
        private DevExpress.XtraEditors.TextEdit txtContraseña;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit cmbEmpresa;
        private DevExpress.XtraEditors.LookUpEdit cmbSucursal;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.Utils.ImageCollection img;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}