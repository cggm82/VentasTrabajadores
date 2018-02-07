using System;
using System.Windows.Forms;
using Aplicacion;
using System.Globalization;



namespace Ventas_Trabajadores
{
    public partial class frmMenuPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //Declaracion de variables 
        public static string mstrNomModulo = "Ventas";
        public static string strNombOpcion = "";
        private static int intBtnActivo;
        private static int intFrmActivo;

        //Utilidades
        public Utilidades.Ribbon objMenu = new Utilidades.Ribbon();
        public Utilidades.Funciones objFunciones = new Utilidades.Funciones();

        //Entidades y Negocio
        public static ENGeneral.Entorno genEntorno = new ENGeneral.Entorno();
        public static ENGeneral.GNAccesosGrupo enAccesoGrupo = new ENGeneral.GNAccesosGrupo();
        private static NGGeneral.GNAccesoGrupo ngAccesoGrupo = new NGGeneral.GNAccesoGrupo();
        private Aplicacion.OpcionesActivas clOpcionActiva = new Aplicacion.OpcionesActivas();

        public frmMenuPrincipal()
        {
            try
            {
                InitializeComponent();
                objMenu.ApagarBotones(rcBarra);

            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            NGGeneral.Entorno ngEntorno = new NGGeneral.Entorno();
            string mstrUbicacion = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            //NGGeneral.ModuloSistema ngModuloSistema = new NGGeneral.ModuloSistema();

            try
            {
                //1.Asignar las variables de entorno
                genEntorno = ngEntorno.AsignarVariablesEntorno(genEntorno.IndAlmacenarErrorBD);

                //2.Asignar Informacion General
                genEntorno = ngEntorno.AsignarVariablesEntorno(genEntorno.IndAlmacenarErrorBD);
                barItemFecha.Caption = DateTime.UtcNow + "   |";
                barItemVersion.Caption = "Versión: " + System.Diagnostics.FileVersionInfo.GetVersionInfo(mstrUbicacion).FileVersion + "   |";
                barItemUsuario.Caption = "Usuario: " + genEntorno.NombUsuario + "   |";
                barItemEquipo.Caption = "Equipo: " + Environment.MachineName + "   |";
                barItemServidor.Caption = "Entorno de Dato: " + genEntorno.Servidor;

                //3.Cambiar el LookAndFell
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle("VS2010");
                pccAppMenu.LookAndFeel.SetSkinStyle("VS2010");

                //4.Seguridad de Accesos a las Opciones del menú
                objMenu.ApagarBotones(rcBarra);
                objMenu.ActivarBotonAyuda(rcBarra,enAccesoGrupo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.IBarra Interfaz = this.ActiveMdiChild as Utilidades.IBarra;
            try
            {
                if (Interfaz != null)
                {
                    objMenu.ApagarBotones(rcBarra);
                    Interfaz.Salir();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuVETra_Pedido_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPedido objfrmPedido = new frmPedido();
            string strMensaje = "";
            try
            {
                //Validar Fecha de Pedido
                strMensaje = Validaciones();
                if (strMensaje.Length > 0)
                {
                    MessageBox.Show(strMensaje, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
              
                    
                if (objFunciones.ValidarVentanasAbiertas(System.Windows.Forms.Application.OpenForms, "VE"))
                {
                    objfrmPedido.MdiParent = this;
                    enAccesoGrupo = ngAccesoGrupo.OpcionesPorPantalla(genEntorno.CodEmpresa, genEntorno.CodGrupoUsuario,
                                                                    "VETran_PedidoTrabajador", genEntorno.IndAlmacenarErrorBD);
                    if (enAccesoGrupo != null)
                    {
                        objMenu.ActivarBotonesCargar(rcBarra, enAccesoGrupo);
                        CargarOpcionActiva(0, Convert.ToInt16(objfrmPedido.Tag));

                        objMenu.HabilitarOpcionMenu(rcBarra, "VETran_PedidoTrabajador", false);
                        objfrmPedido.Show();
                    }
                    else
                        MessageBox.Show(Constantes.MsgSinPermisoOpcion, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuVETra_BiometriaTrab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmRegistroBiometrico objfrmRegBiometrico = new frmRegistroBiometrico();
            //try
            //{
            //    if (objFunciones.ValidarVentanasAbiertas(System.Windows.Forms.Application.OpenForms, "VE"))
            //    {
            //        objfrmRegBiometrico.MdiParent = this;
            //        enAccesoGrupo = ngAccesoGrupo.OpcionesPorPantalla(genEntorno.CodEmpresa, genEntorno.CodGrupoUsuario,
            //                                                        "VETran_Pedidos", genEntorno.IndAlmacenarErrorBD);
            //        if (enAccesoGrupo != null)
            //        {
            //            objMenu.ActivarBotonesCargar(rcBarra, enAccesoGrupo);
            //            CargarOpcionActiva(0, Convert.ToInt16(objfrmRegBiometrico.Tag));

            //            objMenu.HabilitarOpcionMenu(rcBarra, "VETran_Pedidos", false);
            //            objfrmRegBiometrico.Show();
            //        }
            //        else
            //            MessageBox.Show(Constantes.MsgSinPermisoOpcion, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #region //********************************Otros Procedimientos y Funciones******************************//

        private string Validaciones() 
        {
            ENGeneral.GNEmpresa enEmpresa = new ENGeneral.GNEmpresa();
            NGGeneral.GNEmpresa ngEmpresa = new NGGeneral.GNEmpresa();
            bool blnValDiasPedido = true, blnValPedidoCierre = true;
            string strFechaTopeMov = "", strMesCierre = "", strAño = "";


            enEmpresa = ngEmpresa.Consultar(genEntorno.IndAlmacenarErrorBD);
            strFechaTopeMov = objFunciones.FechaTopeMovimiento(genEntorno.IndAlmacenarErrorBD);
            strAño = (Convert.ToDateTime(strFechaTopeMov).Month == 12 ? (Convert.ToDateTime(strFechaTopeMov).Year + 1).ToString() : Convert.ToDateTime(strFechaTopeMov).Year.ToString());
            strMesCierre = (Convert.ToDateTime(strFechaTopeMov).Month + 1).ToString();
            strMesCierre = (strMesCierre.Length < 2 ? "0" + strMesCierre : strMesCierre); 

            if (enEmpresa != null)
            {
                blnValDiasPedido = (enEmpresa.IndValDiasPedido == 'S' ? true : false);
                blnValPedidoCierre = (enEmpresa.IndValPedidoCierre == 'S' ? true : false);
            }

            if (blnValDiasPedido == true)
            {
                //Solo se hace pedidos de Lunes a Miercoles
                if ((int)DateTime.Today.DayOfWeek != 1 && (int)DateTime.Today.DayOfWeek != 2 && (int)DateTime.Today.DayOfWeek != 3)
                    return "Los días validos para realizar pedidos son de <<Lunes a Miercoles>>";

                //Si el dia es miercoles solo hacer pedido hasta las 4pm
                if ((int)DateTime.Today.DayOfWeek == 3)
                {
                    if (objFunciones.HoraPedido(genEntorno.IndAlmacenarErrorBD) == false)
                        return "El horario para realizar un pedido es hasta las 4 p.m.";
                }

                if (objFunciones.DiaAntesCierreMes(strAño, strMesCierre, genEntorno.IndAlmacenarErrorBD) == true)
                    if (objFunciones.HoraPedido(genEntorno.IndAlmacenarErrorBD) == false)
                        return "El horario para realizar un pedido es hasta las 4 p.m.";
            }
            else
            {
                if (objFunciones.HoraPedido(genEntorno.IndAlmacenarErrorBD) == false)
                return "El horario para realizar un pedido es hasta las 4 p.m.";
            }


            if (blnValPedidoCierre == true)
                if (objFunciones.FechaCierreMes(DateTime.Now.Date, genEntorno.IndAlmacenarErrorBD) == true)
                    return "Los días de cierre de mes, estan inhabilitados para realizar pedidos y/o facturación!!!";
                else
                    return "";
            else
                if (objFunciones.HoraPedido(genEntorno.IndAlmacenarErrorBD) == false)
                    return "El horario para realizar un pedido es hasta las 4 p.m.";
                else
                    return "";
        }

        void CargarOpcionActiva(int intBtnActivo, int intFrmActivo)
        {
            bool blnEncontro = false;
            Aplicacion.OpcionActiva enOpcionActiva = new Aplicacion.OpcionActiva();

            if (clOpcionActiva.Count != 0)
            {
                foreach (var enOpcAct in clOpcionActiva)
                {
                    if (enOpcAct.frmActivo == intFrmActivo)
                    {
                        enOpcAct.btnActivo = intBtnActivo;
                        blnEncontro = true;
                        break;
                    }
                }
                if (blnEncontro != true)
                {
                    enOpcionActiva.btnActivo = intBtnActivo;
                    enOpcionActiva.frmActivo = intFrmActivo;
                    clOpcionActiva.Add(enOpcionActiva);
                }
            }
            else
            {
                enOpcionActiva.btnActivo = intBtnActivo;
                enOpcionActiva.frmActivo = intFrmActivo;
                clOpcionActiva.Add(enOpcionActiva);
            }
        }
        #endregion


      

        #region //********************************Opciones de la Barra******************************//
        private void btnNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.IBarra Interfaz = this.ActiveMdiChild as Utilidades.IBarra;
            try
            {
                if (Interfaz != null)
                {
                    Interfaz.Nuevo();
                    intBtnActivo = Convert.ToInt16(btnNuevo.Tag);
                    intFrmActivo = Convert.ToInt16(ActiveMdiChild.Tag);
                    CargarOpcionActiva(intBtnActivo, intFrmActivo);

                    if (enAccesoGrupo != null)
                        objMenu.ActivarBotonesNuevo(rcBarra, enAccesoGrupo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.IBarra Interfaz = this.ActiveMdiChild as Utilidades.IBarra;
            try
            {
                if (Interfaz != null)
                {
                    intBtnActivo = Convert.ToInt16(btnBuscar.Tag);
                    intFrmActivo = Convert.ToInt16(ActiveMdiChild.Tag);
                    CargarOpcionActiva(intBtnActivo, intFrmActivo);

                    if (enAccesoGrupo != null)
                        objMenu.ActivarBotonesBuscar(rcBarra, enAccesoGrupo);

                    Interfaz.Buscar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.IBarra Interfaz = this.ActiveMdiChild as Utilidades.IBarra;
            try
            {
                if (Interfaz != null)
                {
                    Interfaz.Editar();
                    intBtnActivo = Convert.ToInt16(btnEditar.Tag);
                    intFrmActivo = Convert.ToInt16(ActiveMdiChild.Tag);
                    CargarOpcionActiva(intBtnActivo, intFrmActivo);
                    if (enAccesoGrupo != null)
                        objMenu.ActivarBotonesNuevo(rcBarra, enAccesoGrupo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.IBarra Interfaz = this.ActiveMdiChild as Utilidades.IBarra;
            try
            {
                if (Interfaz != null)
                {
                    Interfaz.Eliminar();
                    intBtnActivo = Convert.ToInt16(btnEliminar.Tag);
                    intFrmActivo = Convert.ToInt16(ActiveMdiChild.Tag);
                    CargarOpcionActiva(intBtnActivo, intFrmActivo);
                    if (enAccesoGrupo != null)
                        objMenu.ActivarBotonesCargar(rcBarra, enAccesoGrupo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.IBarra Interfaz = this.ActiveMdiChild as Utilidades.IBarra;
            try
            {
                if (Interfaz != null)
                {
                    if (Interfaz.Grabar() == true)
                    {
                        intBtnActivo = Convert.ToInt16(btnGrabar.Tag);
                        intFrmActivo = Convert.ToInt16(ActiveMdiChild.Tag);
                        CargarOpcionActiva(intBtnActivo, intFrmActivo);

                        if (enAccesoGrupo != null)
                            objMenu.ActivarBotonesCargar(rcBarra, enAccesoGrupo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.IBarra Interfaz = this.ActiveMdiChild as Utilidades.IBarra;
            try
            {
                if (Interfaz != null)
                {
                    Interfaz.Cancelar();
                    intBtnActivo = Convert.ToInt16(btnCancelar.Tag);
                    intFrmActivo = Convert.ToInt16(ActiveMdiChild.Tag);
                    CargarOpcionActiva(intBtnActivo, intFrmActivo);
                    if (enAccesoGrupo != null)
                        objMenu.ActivarBotonesCargar(rcBarra, enAccesoGrupo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.IBarra Interfaz = this.ActiveMdiChild as Utilidades.IBarra;
            try
            {
                if (Interfaz != null)
                {
                    Interfaz.Imprimir();
                    intBtnActivo = Convert.ToInt16(btnImprimir.Tag);
                    intFrmActivo = Convert.ToInt16(ActiveMdiChild.Tag);
                    CargarOpcionActiva(intBtnActivo, intFrmActivo);
                    if (enAccesoGrupo != null)
                        objMenu.ActivarBotonesCargar(rcBarra, enAccesoGrupo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAyuda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.IBarra Interfaz = this.ActiveMdiChild as Utilidades.IBarra;
            try
            {
                if (Interfaz != null)
                {
                    Interfaz.Ayuda();
                    intBtnActivo = Convert.ToInt16(btnCancelar.Tag);
                    intFrmActivo = Convert.ToInt16(ActiveMdiChild.Tag);
                    CargarOpcionActiva(intBtnActivo, intFrmActivo);
                    if (enAccesoGrupo != null)
                        objMenu.ActivarBotonesCargar(rcBarra, enAccesoGrupo);
                }
                else
                { 
                    //Activado desde el Menu principa y no de la forma hija
                    PRUtilidades.Formas.frmAyuda objfrmAyuda = new PRUtilidades.Formas.frmAyuda();
                    objfrmAyuda.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuVESalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Program.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

       

        

       

        

     

        

        
        
    }
}
