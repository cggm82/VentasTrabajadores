namespace Ventas_Trabajadores
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.rcBarra = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.mnuVETransacciones = new DevExpress.XtraBars.BarSubItem();
            this.mnuVETra_Pedido = new DevExpress.XtraBars.BarButtonItem();
            this.mnuVETra_BiometriaTrab = new DevExpress.XtraBars.BarButtonItem();
            this.mnuVESalir = new DevExpress.XtraBars.BarButtonItem();
            this.pccAppMenu = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.imgPequeñas = new DevExpress.Utils.ImageCollection(this.components);
            this.btnNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.btnBuscar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnGrabar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.btnAyuda = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarButtonItem();
            this.barItemFecha = new DevExpress.XtraBars.BarStaticItem();
            this.barItemVersion = new DevExpress.XtraBars.BarStaticItem();
            this.barItemUsuario = new DevExpress.XtraBars.BarStaticItem();
            this.barItemEquipo = new DevExpress.XtraBars.BarStaticItem();
            this.barItemServidor = new DevExpress.XtraBars.BarStaticItem();
            this.imgGrandes = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rcBarra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccAppMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPequeñas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGrandes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // rcBarra
            // 
            this.rcBarra.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.rcBarra.ApplicationCaption = "Modulo: Venta :: Techo Duro S.A.";
            this.rcBarra.ApplicationIcon = global::Ventas_Trabajadores.Properties.Resources.Ventas;
            this.rcBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(199)))), ((int)(((byte)(216)))));
            this.rcBarra.ExpandCollapseItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.rcBarra.ExpandCollapseItem.Id = 0;
            this.rcBarra.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rcBarra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            this.rcBarra.Images = this.imgPequeñas;
            this.rcBarra.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcBarra.ExpandCollapseItem,
            this.mnuVETransacciones,
            this.mnuVETra_Pedido,
            this.btnNuevo,
            this.btnBuscar,
            this.btnEditar,
            this.btnEliminar,
            this.btnGrabar,
            this.btnCancelar,
            this.btnImprimir,
            this.btnAyuda,
            this.btnSalir,
            this.barItemFecha,
            this.barItemVersion,
            this.barItemUsuario,
            this.barItemEquipo,
            this.barItemServidor,
            this.mnuVESalir,
            this.mnuVETra_BiometriaTrab});
            this.rcBarra.LargeImages = this.imgGrandes;
            this.rcBarra.Location = new System.Drawing.Point(0, 0);
            this.rcBarra.MaxItemId = 19;
            this.rcBarra.Name = "rcBarra";
            this.rcBarra.PageCategoryAlignment = DevExpress.XtraBars.Ribbon.RibbonPageCategoryAlignment.Right;
            this.rcBarra.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.rcBarra.Size = new System.Drawing.Size(1028, 144);
            this.rcBarra.StatusBar = this.ribbonStatusBar;
            this.rcBarra.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.mnuVETransacciones);
            this.applicationMenu1.ItemLinks.Add(this.mnuVESalir);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.rcBarra;
            this.applicationMenu1.RightPaneControlContainer = this.pccAppMenu;
            // 
            // mnuVETransacciones
            // 
            this.mnuVETransacciones.Caption = "Transacciones";
            this.mnuVETransacciones.Id = 1;
            this.mnuVETransacciones.LargeImageIndex = 72;
            this.mnuVETransacciones.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuVETra_Pedido),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuVETra_BiometriaTrab)});
            this.mnuVETransacciones.Name = "mnuVETransacciones";
            // 
            // mnuVETra_Pedido
            // 
            this.mnuVETra_Pedido.Caption = "Pedido";
            this.mnuVETra_Pedido.Id = 2;
            this.mnuVETra_Pedido.LargeImageIndex = 95;
            this.mnuVETra_Pedido.Name = "mnuVETra_Pedido";
            this.mnuVETra_Pedido.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuVETra_Pedido_ItemClick);
            // 
            // mnuVETra_BiometriaTrab
            // 
            this.mnuVETra_BiometriaTrab.Caption = "Registro Biometrico de Trabajador";
            this.mnuVETra_BiometriaTrab.Id = 18;
            this.mnuVETra_BiometriaTrab.Name = "mnuVETra_BiometriaTrab";
            this.mnuVETra_BiometriaTrab.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.mnuVETra_BiometriaTrab.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuVETra_BiometriaTrab_ItemClick);
            // 
            // mnuVESalir
            // 
            this.mnuVESalir.Caption = "Salir";
            this.mnuVESalir.Id = 17;
            this.mnuVESalir.LargeImageIndex = 82;
            this.mnuVESalir.Name = "mnuVESalir";
            this.mnuVESalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuVESalir_ItemClick);
            // 
            // pccAppMenu
            // 
            this.pccAppMenu.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pccAppMenu.Appearance.Options.UseBackColor = true;
            this.pccAppMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pccAppMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pccAppMenu.Location = new System.Drawing.Point(0, 144);
            this.pccAppMenu.Name = "pccAppMenu";
            this.pccAppMenu.Ribbon = this.rcBarra;
            this.pccAppMenu.Size = new System.Drawing.Size(1028, 614);
            this.pccAppMenu.TabIndex = 1;
            this.pccAppMenu.Visible = false;
            // 
            // imgPequeñas
            // 
            this.imgPequeñas.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgPequeñas.ImageStream")));
            this.imgPequeñas.Images.SetKeyName(29, "truck-plus-icon16.png");
            this.imgPequeñas.Images.SetKeyName(30, "CAI-4-icon16.png");
            this.imgPequeñas.Images.SetKeyName(31, "Panel-truck-icon16.png");
            this.imgPequeñas.Images.SetKeyName(32, "rss-icon16.png");
            this.imgPequeñas.Images.SetKeyName(33, "TractorUnit-icon16.png");
            this.imgPequeñas.Images.SetKeyName(34, "truck-arrow-icon16.png");
            this.imgPequeñas.Images.SetKeyName(35, "truck-empty-icon16.png");
            this.imgPequeñas.Images.SetKeyName(36, "truck-exclamation-icon16.png");
            this.imgPequeñas.Images.SetKeyName(37, "truck-icon16.png");
            this.imgPequeñas.Images.SetKeyName(38, "truck-minus-icon16.png");
            this.imgPequeñas.Images.SetKeyName(39, "truck-pencil-icon16.png");
            this.imgPequeñas.Images.SetKeyName(40, "truck-plus-icon16.png");
            this.imgPequeñas.Images.SetKeyName(41, "administrator-icon48.png");
            this.imgPequeñas.Images.SetKeyName(42, "administrator-icon.png");
            this.imgPequeñas.Images.SetKeyName(43, "Person-Male-Dark-icon.png");
            this.imgPequeñas.Images.SetKeyName(44, "Truck2-icon16.png");
            this.imgPequeñas.Images.SetKeyName(45, "Letter-C-blue-icon.png");
            this.imgPequeñas.Images.SetKeyName(46, "Letter-F-blue-icon.png");
            this.imgPequeñas.Images.SetKeyName(47, "Letter-T-blue-icon.png");
            // 
            // btnNuevo
            // 
            this.btnNuevo.Caption = "Nuevo";
            this.btnNuevo.Id = 3;
            this.btnNuevo.LargeImageIndex = 80;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNuevo_ItemClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Caption = "Buscar";
            this.btnBuscar.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnBuscar.Id = 4;
            this.btnBuscar.LargeImageIndex = 81;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBuscar_ItemClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Caption = "Editar";
            this.btnEditar.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnEditar.Id = 5;
            this.btnEditar.LargeImageIndex = 90;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnEliminar.Id = 6;
            this.btnEliminar.LargeImageIndex = 85;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Caption = "Grabar";
            this.btnGrabar.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnGrabar.Id = 7;
            this.btnGrabar.LargeImageIndex = 56;
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGrabar_ItemClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "Cancelar";
            this.btnCancelar.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnCancelar.Id = 8;
            this.btnCancelar.LargeImageIndex = 74;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancelar_ItemClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnImprimir.Id = 9;
            this.btnImprimir.LargeImageIndex = 79;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Caption = "Ayuda";
            this.btnAyuda.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAyuda.Id = 10;
            this.btnAyuda.LargeImageIndex = 86;
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAyuda_ItemClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSalir.Id = 11;
            this.btnSalir.LargeImageIndex = 82;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalir_ItemClick);
            // 
            // barItemFecha
            // 
            this.barItemFecha.Caption = "11/03/2015 02:38 p.m.    |";
            this.barItemFecha.Id = 12;
            this.barItemFecha.Name = "barItemFecha";
            this.barItemFecha.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barItemVersion
            // 
            this.barItemVersion.Caption = "Version 1.0 del 11/03/2015 02:38 p.m.  |";
            this.barItemVersion.Id = 13;
            this.barItemVersion.Name = "barItemVersion";
            this.barItemVersion.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barItemUsuario
            // 
            this.barItemUsuario.Caption = "Usuario: GUTIERREZ M., CAIRIMAR G.   |";
            this.barItemUsuario.Id = 14;
            this.barItemUsuario.Name = "barItemUsuario";
            this.barItemUsuario.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barItemEquipo
            // 
            this.barItemEquipo.Caption = "Equipo: TDUANSIS  |";
            this.barItemEquipo.Id = 15;
            this.barItemEquipo.Name = "barItemEquipo";
            this.barItemEquipo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barItemServidor
            // 
            this.barItemServidor.Caption = "Entorno de Dato: Prueba";
            this.barItemServidor.Id = 16;
            this.barItemServidor.Name = "barItemServidor";
            this.barItemServidor.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // imgGrandes
            // 
            this.imgGrandes.ImageSize = new System.Drawing.Size(52, 52);
            this.imgGrandes.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgGrandes.ImageStream")));
            this.imgGrandes.Images.SetKeyName(0, "Table Row Add.png");
            this.imgGrandes.Images.SetKeyName(1, "Table Row Delete.png");
            this.imgGrandes.Images.SetKeyName(2, "Mail 2.png");
            this.imgGrandes.Images.SetKeyName(3, "HR.png");
            this.imgGrandes.Images.SetKeyName(4, "Card Swiper 2 Edit 2.png");
            this.imgGrandes.Images.SetKeyName(5, "Decrease Decimal.png");
            this.imgGrandes.Images.SetKeyName(6, "User Wizard.png");
            this.imgGrandes.Images.SetKeyName(7, "Accounting.png");
            this.imgGrandes.Images.SetKeyName(8, "Copy.png");
            this.imgGrandes.Images.SetKeyName(9, "Document 2 Add.png");
            this.imgGrandes.Images.SetKeyName(10, "Document 2 Delete.png");
            this.imgGrandes.Images.SetKeyName(11, "Document 2 Edit 2.png");
            this.imgGrandes.Images.SetKeyName(12, "Floppy Drive.png");
            this.imgGrandes.Images.SetKeyName(13, "Perspective Save.png");
            this.imgGrandes.Images.SetKeyName(14, "Printer 2.png");
            this.imgGrandes.Images.SetKeyName(15, "Symbol Delete 2.png");
            this.imgGrandes.Images.SetKeyName(16, "Symbol Error.png");
            this.imgGrandes.Images.SetKeyName(17, "Symbol Check 2.png");
            this.imgGrandes.Images.SetKeyName(18, "Trash Empty.png");
            this.imgGrandes.Images.SetKeyName(19, "Tools 4.png");
            this.imgGrandes.Images.SetKeyName(20, "Report.png");
            this.imgGrandes.Images.SetKeyName(21, "Contact Information.png");
            this.imgGrandes.Images.SetKeyName(22, "Contact Search.png");
            this.imgGrandes.Images.SetKeyName(23, "Search.png");
            this.imgGrandes.Images.SetKeyName(24, "Document 2 Attach.png");
            this.imgGrandes.Images.SetKeyName(25, "Document 2 Help.png");
            this.imgGrandes.Images.SetKeyName(26, "LorryGreen.png");
            this.imgGrandes.Images.SetKeyName(27, "TractorUnitBlack.png");
            this.imgGrandes.Images.SetKeyName(28, "Truck-icon48.png");
            this.imgGrandes.Images.SetKeyName(29, "box-1-icon48.png");
            this.imgGrandes.Images.SetKeyName(30, "Box-icon48.png");
            this.imgGrandes.Images.SetKeyName(31, "CAI-2-icon48.png");
            this.imgGrandes.Images.SetKeyName(32, "CAI-3-icon48.png");
            this.imgGrandes.Images.SetKeyName(33, "CAI-4-icon48.png");
            this.imgGrandes.Images.SetKeyName(34, "cargo-1-icon48.png");
            this.imgGrandes.Images.SetKeyName(35, "data-transport-icon48.png");
            this.imgGrandes.Images.SetKeyName(36, "disk-9-icon48.png");
            this.imgGrandes.Images.SetKeyName(37, "dumper-icon48.png");
            this.imgGrandes.Images.SetKeyName(38, "Excavator-icon48.png");
            this.imgGrandes.Images.SetKeyName(39, "ForkliftTruck-Loaded-icon48.png");
            this.imgGrandes.Images.SetKeyName(40, "Maersk-4-icon48.png");
            this.imgGrandes.Images.SetKeyName(41, "Truck-icon48.png");
            this.imgGrandes.Images.SetKeyName(42, "Wheel-icon48.png");
            this.imgGrandes.Images.SetKeyName(43, "Person-Male-Dark-icon48.png");
            this.imgGrandes.Images.SetKeyName(44, "TractorUnit-icon48.png");
            this.imgGrandes.Images.SetKeyName(45, "box-1-icon48.png");
            this.imgGrandes.Images.SetKeyName(46, "tracking-route-icon.png");
            this.imgGrandes.Images.SetKeyName(47, "Mimetype-log-icon.png");
            this.imgGrandes.Images.SetKeyName(48, "Kdm-user-male-icon.png");
            this.imgGrandes.Images.SetKeyName(49, "Kdm-user-female-icon.png");
            this.imgGrandes.Images.SetKeyName(50, "Kdm-config-danger-icon.png");
            this.imgGrandes.Images.SetKeyName(51, "App-reminders-icon.png");
            this.imgGrandes.Images.SetKeyName(52, "App-printer-icon.png");
            this.imgGrandes.Images.SetKeyName(53, "App-package-settings-icon.png");
            this.imgGrandes.Images.SetKeyName(54, "App-network-connection-manager-icon.png");
            this.imgGrandes.Images.SetKeyName(55, "App-miscellaneous-icon.png");
            this.imgGrandes.Images.SetKeyName(56, "App-floppy-icon.png");
            this.imgGrandes.Images.SetKeyName(57, "App-ghostview-icon.png");
            this.imgGrandes.Images.SetKeyName(58, "Action-tab-remove-icon.png");
            this.imgGrandes.Images.SetKeyName(59, "Action-tab-new-icon.png");
            this.imgGrandes.Images.SetKeyName(60, "App-dict-icon.png");
            this.imgGrandes.Images.SetKeyName(61, "App-control-icon.png");
            this.imgGrandes.Images.SetKeyName(62, "App-Community-Help-icon.png");
            this.imgGrandes.Images.SetKeyName(63, "App-chart-icon.png");
            this.imgGrandes.Images.SetKeyName(64, "App-calendars-icon.png");
            this.imgGrandes.Images.SetKeyName(65, "App-ark-icon.png");
            this.imgGrandes.Images.SetKeyName(66, "App-addressbook-icon.png");
            this.imgGrandes.Images.SetKeyName(67, "App-3d-icon.png");
            this.imgGrandes.Images.SetKeyName(68, "Action-viewmag-icon.png");
            this.imgGrandes.Images.SetKeyName(69, "Action-view-choose-icon.png");
            this.imgGrandes.Images.SetKeyName(70, "Action-spellcheck-icon.png");
            this.imgGrandes.Images.SetKeyName(71, "Action-seyon-icon.png");
            this.imgGrandes.Images.SetKeyName(72, "Action-run-icon.png");
            this.imgGrandes.Images.SetKeyName(73, "Action-remove-icon48.png");
            this.imgGrandes.Images.SetKeyName(74, "Action-reload-icon48.png");
            this.imgGrandes.Images.SetKeyName(75, "Action-playlist-icon48.png");
            this.imgGrandes.Images.SetKeyName(76, "Action-button-home-icon48.png");
            this.imgGrandes.Images.SetKeyName(77, "Action-ok-icon48.png");
            this.imgGrandes.Images.SetKeyName(78, "Action-find-icon48.png");
            this.imgGrandes.Images.SetKeyName(79, "Action-file-print-icon48.png");
            this.imgGrandes.Images.SetKeyName(80, "Action-file-new-icon48.png");
            this.imgGrandes.Images.SetKeyName(81, "Action-file-find-icon48.png");
            this.imgGrandes.Images.SetKeyName(82, "Action-exit-icon48.png");
            this.imgGrandes.Images.SetKeyName(83, "Action-edit-add-icon48.png");
            this.imgGrandes.Images.SetKeyName(84, "Action-edit-icon48.png");
            this.imgGrandes.Images.SetKeyName(85, "Action-delete-icon48.png");
            this.imgGrandes.Images.SetKeyName(86, "Action-button-info-icon48.png");
            this.imgGrandes.Images.SetKeyName(87, "Action-configure-icon48.png");
            this.imgGrandes.Images.SetKeyName(88, "Action-button-stop-icon48.png");
            this.imgGrandes.Images.SetKeyName(89, "Action-cancel-icon48.png");
            this.imgGrandes.Images.SetKeyName(90, "App-edit-icon48.png");
            this.imgGrandes.Images.SetKeyName(91, "Venezuela-icon48.png");
            this.imgGrandes.Images.SetKeyName(92, "tracking-route-icon.png");
            this.imgGrandes.Images.SetKeyName(93, "Lorry-icon48.png");
            this.imgGrandes.Images.SetKeyName(94, "Apps-basket-icon.png");
            this.imgGrandes.Images.SetKeyName(95, "order-history-icon.png");
            this.imgGrandes.Images.SetKeyName(96, "trash-empty-icon.png");
            this.imgGrandes.Images.SetKeyName(97, "product-icon.png");
            this.imgGrandes.Images.SetKeyName(98, "industry-icon.png");
            this.imgGrandes.Images.SetKeyName(99, "product-sales-report-icon.png");
            this.imgGrandes.Images.SetKeyName(100, "Process-Accept128.png");
            this.imgGrandes.Images.SetKeyName(101, "bulldozer.png");
            this.imgGrandes.Images.SetKeyName(102, "Units-2-icon.png");
            this.imgGrandes.Images.SetKeyName(103, "windows-7-security-icon.png");
            this.imgGrandes.Images.SetKeyName(104, "Reminders-Mac-Book-icon.png");
            this.imgGrandes.Images.SetKeyName(105, "Inventory-icon.png");
            this.imgGrandes.Images.SetKeyName(106, "tool-kit-icon.png");
            this.imgGrandes.Images.SetKeyName(107, "Action-view-choose-icon.png");
            this.imgGrandes.Images.SetKeyName(108, "briefcase-icon.png");
            this.imgGrandes.Images.SetKeyName(109, "applications-icon.png");
            this.imgGrandes.Images.SetKeyName(110, "bar-code-icon.png");
            this.imgGrandes.Images.SetKeyName(111, "table-lines-icon.png");
            this.imgGrandes.Images.SetKeyName(112, "tool-box-icon.png");
            this.imgGrandes.Images.SetKeyName(113, "Drives-Time-Machine-HD-icon.png");
            this.imgGrandes.Images.SetKeyName(114, "Control-Panel-icon.png");
            this.imgGrandes.Images.SetKeyName(115, "Utilities-icon.png");
            this.imgGrandes.Images.SetKeyName(116, "Group-icon.png");
            this.imgGrandes.Images.SetKeyName(117, "desktop-user-password.ico");
            this.imgGrandes.Images.SetKeyName(118, "export-excel-icon.png");
            this.imgGrandes.Images.SetKeyName(119, "Button-Next-icon.png");
            this.imgGrandes.Images.SetKeyName(120, "Check-icon-Autorizar.png");
            this.imgGrandes.Images.SetKeyName(121, "document-yellow-icon.png");
            this.imgGrandes.Images.SetKeyName(122, "Insumos.png");
            this.imgGrandes.Images.SetKeyName(123, "AccesoInventario.png");
            this.imgGrandes.Images.SetKeyName(124, "Cliente.png");
            this.imgGrandes.Images.SetKeyName(125, "Descuento.png");
            this.imgGrandes.Images.SetKeyName(126, "DescuentoCliente.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage1.Appearance.Options.UseFont = true;
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup6});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opciones";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNuevo);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnBuscar);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnEditar);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnGrabar);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCancelar);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnImprimir);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnAyuda);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnSalir);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barItemFecha);
            this.ribbonStatusBar.ItemLinks.Add(this.barItemVersion);
            this.ribbonStatusBar.ItemLinks.Add(this.barItemUsuario);
            this.ribbonStatusBar.ItemLinks.Add(this.barItemEquipo);
            this.ribbonStatusBar.ItemLinks.Add(this.barItemServidor);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 725);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.rcBarra;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1028, 33);
            // 
            // popupMenu1
            // 
            this.popupMenu1.AllowRibbonQATMenu = false;
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.rcBarra;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "VS2010";
            // 
            // frmMenuPrincipal
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 758);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.pccAppMenu);
            this.Controls.Add(this.rcBarra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMenuPrincipal";
            this.Ribbon = this.rcBarra;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Modulo: Venta :: Techo Duro S.A.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rcBarra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccAppMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPequeñas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGrandes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rcBarra;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.PopupControlContainer pccAppMenu;
        internal DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.Utils.ImageCollection imgPequeñas;
        internal DevExpress.Utils.ImageCollection imgGrandes;
        private DevExpress.XtraBars.BarSubItem mnuVETransacciones;
        private DevExpress.XtraBars.BarButtonItem mnuVETra_Pedido;
        internal DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem btnNuevo;
        private DevExpress.XtraBars.BarButtonItem btnBuscar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnEditar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarButtonItem btnGrabar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.BarButtonItem btnAyuda;
        private DevExpress.XtraBars.BarButtonItem btnSalir;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarStaticItem barItemFecha;
        private DevExpress.XtraBars.BarStaticItem barItemVersion;
        private DevExpress.XtraBars.BarStaticItem barItemUsuario;
        private DevExpress.XtraBars.BarStaticItem barItemEquipo;
        private DevExpress.XtraBars.BarStaticItem barItemServidor;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem mnuVESalir;
        private DevExpress.XtraBars.BarButtonItem mnuVETra_BiometriaTrab;
    }
}

