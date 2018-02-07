using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Aplicacion;
using FingerprintNetSample;
using System.Threading;
 

namespace Ventas_Trabajadores
{
    public partial class frmPedido : DevExpress.XtraEditors.XtraForm, Utilidades.IBarra
    {
        //Declaracion de variables 
        private bool blnExistenciaValida = true;
        private bool blnEditando, blnCancelar= false;
        private string strCodTrabajador;
        private string strCodZonaVenta = "";
        private string strCodZonaDespacho = "";
        private string strCodZonaVentaNuevo = "";
        private string strCodZonaDespachoNuevo = "";
        private string strCodCiudad = "";
        private string strCodCondPago = "";
        private string strCodPais = "";
        private string strCodDivisa = "01";
        private decimal decCambioDivisa = 1;
        private string mstrCodTipoPedido = "70";
        private string strNombCompletoImp, strNombImpresora = "";
        private string strRutaArchivoImp = "";
        private string strRutaArchivoTicket = @"//SERVIDOR16/Industria/Actual/PedidoTrabajador.txt";
        private decimal decCantRestante = 0;
        //private decimal decMontoAutPedido = 0;
        private decimal decCantLaminas = 0;

        //Entidades y Negocio
        private ENGeneral.Entorno genEntorno = new ENGeneral.Entorno();
        private ENGeneral.GNTiposDocumento enTipoDocumento = new ENGeneral.GNTiposDocumento();
        private NGGeneral.GNTiposDocumentos ngTipoDocumento = new NGGeneral.GNTiposDocumentos();
        private ENGeneral.GNEmpresa enEmpresa = new ENGeneral.GNEmpresa();
        private NGGeneral.GNEmpresa ngEmpresa = new NGGeneral.GNEmpresa();
        private ENventa.VEPedido enPedido = new ENventa.VEPedido();
        private ENventa.VEPedidoItems clItemsPedido = new ENventa.VEPedidoItems();
        private NGVenta.NGPedido ngPedido = new NGVenta.NGPedido();
        
       

        //Utilidades
        private Utilidades.XtraForm objForma;
        private Utilidades.Funciones objFunciones = new Utilidades.Funciones();
        private Utilidades.CargarEntidad objcargarEntidad = new Utilidades.CargarEntidad();
        private Utilidades.MostrarDatos objMostrarDatos = new Utilidades.MostrarDatos();

        //Barra
        private Utilidades.Ribbon objMenu = new Utilidades.Ribbon();
        private DevExpress.XtraBars.Ribbon.RibbonControl objBarra;

        public frmPedido()
        {
            InitializeComponent();
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {
            ENGeneral.GNAccesosGrupo enOpcionSistema = new ENGeneral.GNAccesosGrupo();
            NGGeneral.GNAccesoGrupo ngAccesoGrupo = new NGGeneral.GNAccesoGrupo();
            objBarra = (DevExpress.XtraBars.Ribbon.RibbonControl)this.Parent.Parent.Controls["rcBarra"];
            try
            {
                genEntorno = frmMenuPrincipal.genEntorno;
                //Asignar valor para validar si se graban estadisticas de uso por la opcion/pantalla de sistema
                enOpcionSistema = ngAccesoGrupo.OpcionesPorPantalla(frmMenuPrincipal.genEntorno.CodEmpresa, frmMenuPrincipal.genEntorno.CodGrupoUsuario,
                                                                    "VETran_PedidoTrabajador", frmMenuPrincipal.genEntorno.IndAlmacenarErrorBD);
                
                //Inicializar y limpiar botones
                objForma = new Utilidades.XtraForm();
                objForma.BloquearControles(this, false);
                objForma.LimpiarControles(this);

                ImpresoraTicket();

                //Inicializar Valores
                InicializarValores();

                enEmpresa = ngEmpresa.Consultar(genEntorno.IndAlmacenarErrorBD);
                if (enEmpresa == null)
                {
                    MessageBox.Show("No se encuentra la información de la empresa. Comuniquese con el administrador del sistema!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), frmMenuPrincipal.mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region //*********************************Opciones de la Barra de Menu************************//
        public void Nuevo()
        {
            string strFechaTopeMov = "", strMesCierre = "", strAño = "";
            try
            {
                //Validar la hora para el pedido
                
                strFechaTopeMov = objFunciones.FechaTopeMovimiento(genEntorno.IndAlmacenarErrorBD);
                strAño = (Convert.ToDateTime(strFechaTopeMov).Month == 12 ? (Convert.ToDateTime(strFechaTopeMov).Year + 1).ToString() : Convert.ToDateTime(strFechaTopeMov).Year.ToString());
                strMesCierre = (Convert.ToDateTime(strFechaTopeMov).Month + 1).ToString();
                strMesCierre = (strMesCierre.Length < 2 ? "0" + strMesCierre : strMesCierre);

                ////Si el dia es miercoles solo hacer pedido hasta las 4pm
                if ((int)DateTime.Today.DayOfWeek == 3)
                {
                    if (objFunciones.HoraPedido(genEntorno.IndAlmacenarErrorBD) == false)
                    {
                        MessageBox.Show("El horario para realizar un pedido es hasta las 4 p.m.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (objFunciones.DiaAntesCierreMes(strAño, strMesCierre, genEntorno.IndAlmacenarErrorBD) == true)
                    if (objFunciones.HoraPedido(genEntorno.IndAlmacenarErrorBD) == false)
                    {
                        MessageBox.Show("El horario para realizar un pedido es hasta las 4 p.m.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                if (txtCodCliente.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Tipee el número de cédula del trabajador!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

               
                txtNumPedido.Text = ngTipoDocumento.Correlativo(genEntorno.CodEmpresa, mstrCodTipoPedido, genEntorno.IndAlmacenarErrorBD);
                if (txtNumPedido.Text.Trim().Length>0)
                {
                    grdItemPedido.DataSource = null;
                    grdItemPedido.DataSource = ngPedido.PedidoItemsVacio();
                    grdvItemPedido.DeleteRow(0); 
                }               
                
                DateEdFecReg.Text = DateTime.Today.Date.ToShortDateString();
                DateEdFecMov.Text = objFunciones.FechaMovimiento(genEntorno.IndAlmacenarErrorBD).ToShortDateString(); 
                blnEditando = false;
                txtTotalMBruto.Text = "0";
                txtImpuesto.Text = "0";
                txtTotalMNeto.Text = "0";
                objForma.BloquearControles(this, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Buscar()
        {
            Utilidades.Ventas.BuscarDatos objBuscarDatos = new Utilidades.Ventas.BuscarDatos();
            string strFechaDesde, strFechaHasta;
            bool blnExistenDatos = false;
            try
            {
                if (txtCodCliente.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Tipee el número de cédula del trabajador!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                strFechaHasta = objFunciones.FechaTopeMovimiento(genEntorno.IndAlmacenarErrorBD);
                strFechaHasta = strFechaHasta.Substring(6, 4) + strFechaHasta.Substring(3, 2) + strFechaHasta.Substring(0, 2);
                strFechaDesde = strFechaHasta.Substring(0, 6) + "01"; 

                //Falta Pulie else catalogo para que no muestre los que se han facturado
                enPedido=objBuscarDatos.PedidosTrabajador(genEntorno.CodEmpresa, txtCodCliente.Text,strFechaDesde,strFechaHasta, genEntorno.IndAlmacenarErrorBD, ref blnExistenDatos);
                if (enPedido != null)
                {
                    if (blnExistenDatos == false)
                    {
                        MessageBox.Show("No existen datos para mostrar!!!");
                        objMenu.ActivarBotonesCargar(objBarra, frmMenuPrincipal.enAccesoGrupo);
                    }
                    else
                    {
                        objMostrarDatos.CargarDatos(this, enPedido);

                        clItemsPedido = ngPedido.ItemsPedidoTrabajador(genEntorno.CodEmpresa, enPedido.CodTipoDocumento, txtNumPedido.Text, genEntorno.IndAlmacenarErrorBD);
                        grdItemPedido.DataSource = clItemsPedido; 
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Grabar()
        {
            string strMensajeValidacion = "";
            Enumerado.AccionSQL Accion;
            ENventa.VEPedido enPedido = new ENventa.VEPedido();
            ENventa.VEPedidoItems clPedidoItems = new ENventa.VEPedidoItems();
            bool blnProcesar = false; 
            try
            {
                //0.Validar que los campos necesarios tengan valor
                strMensajeValidacion = Validaciones();
                if (strMensajeValidacion == null || strMensajeValidacion == "" || strMensajeValidacion.Length <= 0)
                {
                    objcargarEntidad.LlenarEntidad(this, enPedido);
                    enPedido.CodEmpresa = genEntorno.CodEmpresa;
                    enPedido.CodTipoDocumento = mstrCodTipoPedido;
                    enPedido.TipoDivisa = strCodDivisa;
                    enPedido.CodZonaVenta = strCodZonaVenta;
                    enPedido.CodZonaDespacho = strCodZonaDespacho;
                    enPedido.CodPais = strCodPais;
                    enPedido.CodCiudad = strCodCiudad;
                    enPedido.CondPago = strCodCondPago;
                    enPedido.Usuario = genEntorno.CodUsuario;
                    //enPedido.TasaImpuesto = enEmpresa.TasaImpuesto;
                    enPedido.TasaImpuesto = Convert.ToDecimal(lblTasaImp.Text);
                    enPedido.TasaCambio = decCambioDivisa;
                    enPedido.MontoBruto = Convert.ToDecimal(txtTotalMBruto.Text);//Convert.ToDecimal(gcMontoBruto.SummaryItem.SummaryValue);    
                    enPedido.MontoImpuesto = Convert.ToDecimal(txtImpuesto.Text);//Convert.ToDecimal(gcImpuesto.SummaryItem.SummaryValue);
                    enPedido.MontoNeto = Convert.ToDecimal(txtTotalMNeto.Text);//Convert.ToDecimal(gcMontoNeto.SummaryItem.SummaryValue);
                    enPedido.PesoNeto = Convert.ToDecimal(gcPesoToneladas.SummaryItem.SummaryValue);
                    enPedido.CodZonaVentaNuevo = strCodZonaVentaNuevo;
                    enPedido.CodZonaDespachoNuevo = strCodZonaDespachoNuevo;
                    enPedido.FecMovimiento = DateEdFecMov.DateTime;
                    enPedido.IndPagoTransferencia = chkTransfBancarias.Checked == true ? "S" : "N";
                    objcargarEntidad.AsignarValoresaCamposNull(enPedido);
                    clPedidoItems = (ENventa.VEPedidoItems)grdItemPedido.DataSource; 


                    Accion = (blnEditando == true ? Enumerado.AccionSQL.Update : Enumerado.AccionSQL.Insert);

                    blnProcesar = ngPedido.Procesar(enPedido, clPedidoItems, strRutaArchivoImp, strNombImpresora, Accion, genEntorno.IndAlmacenarErrorBD);
                    if (blnProcesar == false)
                    {
                        MessageBox.Show(Constantes.MensajeErrorUF, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        blnProcesar= false;
                    }
                    else
                    {
                        Cancelar();
                        MessageBox.Show(Constantes.MensajeRegProcesado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        blnProcesar= true;
                    }

                    return blnProcesar;
                }
                else
                {
                    MessageBox.Show(strMensajeValidacion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (blnCancelar)
                        Cancelar();
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Constantes.MensajeError + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool Editar()
        {
            return true;
        }

        public void Eliminar()
        {
            MessageBox.Show("Opción inhabilitada por la gerencia de Recursos Humanos",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
            //bool blnProcesar = false;
            //Enumerado.AccionSQL Accion;
            //try
            //{
            //    if (MessageBox.Show("Esta Seguro de eliminar el Pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        Accion = Enumerado.AccionSQL.Delete;
            //        blnProcesar = ngPedido.Procesar(enPedido, null, strRutaArchivoImp, strNombImpresora, Accion, genEntorno.IndAlmacenarErrorBD);
            //        if (blnProcesar == false)
            //        {
            //            MessageBox.Show(Constantes.MensajeErrorUF, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            blnProcesar = false;
            //        }
            //        else
            //        {
            //            Cancelar();
            //            MessageBox.Show(Constantes.MensajeRegProcesado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            blnProcesar = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public void Cancelar()
        {
            try
            {
                blnEditando = false;
                blnExistenciaValida = true;
                objForma.LimpiarControles(this);
                objForma.BloquearControles(this, false);
                chkTransfBancarias.Checked = false;

                //Inicializar Valores
                InicializarValores();
                grdvItemPedido.Columns["CodProductoTrab"].ColumnEdit = btnrProducto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), frmMenuPrincipal.mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Salir()
        {
            Close();
        }


        public void Ayuda()
        {
            try
            {
                PRUtilidades.Formas.frmAyuda frmAyuda;
                frmAyuda = new PRUtilidades.Formas.frmAyuda();
                frmAyuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), frmMenuPrincipal.mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Imprimir()
        {
            Utilidades.Procedimientos objProcedimiento = new Utilidades.Procedimientos();
            ENventa.VEPedidoItems clPedidoItems = new ENventa.VEPedidoItems();
            bool blnTerminado = false;
            try
            {
                clPedidoItems = (ENventa.VEPedidoItems)grdItemPedido.DataSource; 
                objProcedimiento.ImprimirTicketPedido(strNombImpresora, strRutaArchivoImp, txtNumPedido.Text, txtCodCliente.Text, 
                                                      txtNombCliente.Text, clPedidoItems, ref blnTerminado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region //**************************************Otros Procedimientos y Funciones **************************************//
        private string Validaciones()
        {
            string strTexto = "";
            blnCancelar = false;
            if (blnEditando == false)
            {
                //if (objFunciones.ImpresoraInstaladaEquipo(strNombImpresora) == false)
                //{
                //    blnCancelar = true;
                //    return @"No se detecto la impresora para la impresión del pedido. " +
                //            "Por Favor verifique o Comuniquese con el administrador del sistema";
                //}

                //if (File.Exists(strRutaArchivoImp) == false)
                //{
                //    blnCancelar = true;
                //    return @"No se encuentra el archivo para imprimir el Pedido. " +
                //            "Comuniquese con el Administrador del Sistema.";
                //}

                if (blnExistenciaValida == false)
                {
                    blnCancelar = true;
                    return @"No hay Existencia suficiente para la cantidad solicitada";
                }
    
                
                //if(objFunciones.ConsultarHuellaTrabajador(strCodTrabajador,genEntorno.IndAlmacenarErrorBD) == false) 
                //    return @"Su información de Huella dactilar no esta actualizada." +
                //            "Cominiquese con su supervisor para actualizar esta información";

                //if (ValidarHuella() == false)
                //    return @"La huella dactilar no coincide. Transacción cancelada!!!";
            }

            if (txtCodCliente.Text.Trim().Length <= 0)
            {
                blnCancelar = true;
                return "Falta el código del cliente. Comuniquese con el administrador del Sistema!!!";
            }


            if (txtDirDespacho1.Text.Trim().Length <= 0 && txtDirDespacho1.Text.Trim().Length <= 0 && txtDirDespacho1.Text.Trim().Length <= 0)
                return "Tipee la Direccion de Envio";

            if (grdvItemPedido.RowCount <= 0)
                return "Debe incluir al menos un Item en el pedido!!!";

            if (Convert.ToDecimal(gcCantPedida.SummaryText) > enEmpresa.CantLaminas)
            {
                blnCancelar = true;
                return "La Cantidad de unidades a solicitar excede el límite permitido por trabajador!!!";
            }
            

            strTexto = ValidarPedidoMes();
            if (strTexto.Length > 0)
            {
                blnCancelar = true;
                return strTexto;
            }
            else
                return "";
        }

        private string ValidarPedidoMes()
        {
            ENventa.VEPedido enPedido = new ENventa.VEPedido();
            NGVenta.NGPedido ngPedido = new NGVenta.NGPedido();
            string strFechaHasta = "", strFechaDesde = "";
            try
            {
                strFechaHasta = objFunciones.FechaTopeMovimiento(genEntorno.IndAlmacenarErrorBD);
                strFechaHasta = strFechaHasta.Substring(6, 4) + strFechaHasta.Substring(3, 2) + strFechaHasta.Substring(0, 2);
                strFechaDesde = strFechaHasta.Substring(0, 6) + "01";

                enPedido = ngPedido.FacturaTrabajadorMes(genEntorno.CodEmpresa, txtCodCliente.Text, strFechaDesde, strFechaHasta, genEntorno.IndAlmacenarErrorBD);
                if (enPedido != null)
                {
                    decCantRestante = enEmpresa.CantLaminas - enPedido.CantPedio; 
                    if (enPedido.NumDocumento.Trim().Length > 0)
                    {
                        if (enPedido.NumFactura.Trim().Length > 0 && enPedido.CantPedio==enEmpresa.CantLaminas)
                            return "No puede realizar otro pedido, ya tiene un pedido facturado en el mes!!!";
                        else
                        {
                            //if (enPedido.NumCarga.Trim().Length > 0)
                            //{
                                if (enPedido.CantPedio == enEmpresa.CantLaminas)
                                    return "No puede realizar otro pedido, ya tiene un pedido en proceso de facturación!!!";
                                else
                                    if (enPedido.CantPedio == enEmpresa.CantLaminas)
                                        return "No puede realizar otro pedido, ya tiene pedidos pendientes por facturar!!!";
                                    else
                                        if (Convert.ToDecimal(gcCantPedida.SummaryText) > decCantRestante)
                                            return "Solo le quedan " + Convert.ToInt32(decCantRestante).ToString() + " unidades para solicitar!!!";
                                        else
                                            return "";
                            //}
                        }
                    }
                    else
                        return "";
                }
                else
                    return "";
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }
        private bool ValidarHuella()
        {
            bool blnValor = false;
            //try
            //{
            //    frmCaptaHuella objCaptaHuella = new frmCaptaHuella();
            //    objCaptaHuella.strNombTrabajador = txtNomTrabajador.Text;
            //    objCaptaHuella.strCodTrabajador = strCodTrabajador;
            //    objCaptaHuella.ShowDialog();
            //    using (objCaptaHuella)
            //    {
            //        blnValor = objCaptaHuella.blnHuellaVal;
            //    }
            return blnValor;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void InicializarValores()
        {
            blnEditando = false;
            gcDatosTrabajador.Enabled = true;
            txtCedula.Enabled = true;
            txtNomTrabajador.Enabled = false;
            txtCedula.Text = "";
            txtNomTrabajador.Text = "";
            DateEdFecReg.Text = ""; 
            txtCedula.Focus();
            strCodTrabajador = "";
            grdItemPedido.DataSource=null;
            decCantRestante = 0;
            //decMontoAutPedido = 0;
            decCantLaminas = 0;
            timer1.Enabled = false;
            lblTasaImp.Text = "";
        }

        private void CargarInfCliente(string strRif)
        {
            ENGeneral.GNDeudoresAcreedor enCliente = new ENGeneral.GNDeudoresAcreedor();
            NGGeneral.GNDeudoresAcreedores ngCliente = new NGGeneral.GNDeudoresAcreedores();

            enCliente = ngCliente.Consultar(strRif, genEntorno.IndAlmacenarErrorBD);

            if (enCliente != null)
            {
                txtRif.Text = enCliente.Rif;
                txtCodCliente.Text = enCliente.CliProveedor; 
                txtNombCliente.Text = enCliente.NomCliProveedor.Trim();
                txtDir1.Text = enCliente.Dir1.Trim();
                txtDir2.Text = enCliente.Dir2.Trim();
                txtDir3.Text = enCliente.Dir3.Trim();
                txtDirDespacho1.Text = enCliente.Dir1.Trim();
                txtDirDespacho2.Text = enCliente.Dir2.Trim();
                txtDirDespacho3.Text = enCliente.Dir3.Trim();
                strCodZonaVenta = enCliente.CodZonaVenta;
                strCodZonaDespacho = enCliente.CodZonaDespacho;
                strCodZonaVentaNuevo = enCliente.CodZonaVentaNuevo;
                strCodZonaDespachoNuevo = enCliente.CodZonaDespachoNuevo;
                strCodCiudad = enCliente.CodCiudad;
                strCodCondPago = enCliente.CondPagoDeudor;
                strCodPais = enCliente.CodPais;
            }
            else
            {
                MessageBox.Show("El trabajador no tiene asociado una ficha de cliente, Comuniquese con el Departamento de ventas!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cancelar();
            }
        }

        private void ImpresoraTicket()
        {
            ENGeneral.GNImpresorasxAlmacen enImpresora = new ENGeneral.GNImpresorasxAlmacen();
            NGGeneral.GNImpresorasxAlmacen ngImpresora = new NGGeneral.GNImpresorasxAlmacen();

            enImpresora = ngImpresora.Consultar(genEntorno.CodEmpresa, genEntorno.CodPlanta,"","09",genEntorno.IndAlmacenarErrorBD);
            if (enImpresora != null)
            {
                strNombImpresora = enImpresora.NomImpresora;
                strRutaArchivoImp = strRutaArchivoTicket;
                strNombCompletoImp = @"\\" + enImpresora.NomEquipo + @"\" + enImpresora.NomImpresora;
            }
        }

        /*
        private bool TotalFacturarValido(decimal decMontoFact, decimal decCant)
        {
            if (decMontoFact > 0)
            {
                if (decMontoFact < Convert.ToDecimal(txtMontoMaxPedido.Text) && decCant <= enEmpresa.CantLaminas)
                    return true;
                else
                    return false;
            }
            else
            {
                if (Convert.ToDecimal(gcMontoNeto.SummaryText) < Convert.ToDecimal(txtMontoMaxPedido.Text) && Convert.ToDecimal(gcCantPedida.SummaryText) <= enEmpresa.CantLaminas)
                    return true;
                else
                    return false;
            }
            
        }
        */
        #endregion

        #region //**************************************Programación de Objetos**************************************//
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            ENPersonal.PEInformacionLaboral enTrabajador = new ENPersonal.PEInformacionLaboral();
            NGPersonal.PEInformacionLaboral ngTrabajador = new NGPersonal.PEInformacionLaboral();
            string strCedula ="";
            decimal decSueldoDiario = 0;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (txtCedula.Text.Trim().Length > 5)
                    {
                        if (txtCedula.Text.Trim().Length < 10)
                            strCedula = objFunciones.AddCerosIzq(txtCedula.Text.Trim(), 10 - txtCedula.Text.Trim().Length);
                        else
                            strCedula = txtCedula.Text.Trim();
                        enTrabajador = ngTrabajador.Consultar(strCedula, genEntorno.CodEmpresa, genEntorno.IndAlmacenarErrorBD);

                        if (enTrabajador != null)
                        {
                            //Cargar la Información del Trabajador
                            strCodTrabajador = enTrabajador.CodTrabajador.Trim();
                            //decSueldoDiario = (enTrabajador.SueldoA * Convert.ToDecimal(1.20));
                            decSueldoDiario = enTrabajador.SueldoA;
                            //decMontoAutPedido = ((decSueldoDiario * 30) * 30) / 100;
                            //txtMontoMaxPedido.Text = decMontoAutPedido.ToString();
                            txtNomTrabajador.Text = enTrabajador.Nombre.Trim();
                            txtCedula.Enabled = false;

                            //Validar que el Trabajador solo haga un pedido al mes

                            //Cargar la Informacion del Trabajador como cliente
                            CargarInfCliente(enTrabajador.Rif);

                            objMenu.ActivarBotonesCargar(objBarra, frmMenuPrincipal.enAccesoGrupo);
                            timer1.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Número de cédula no se encuentra asociada a un trabajador, por favor verifique!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Cancelar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de caracteres de la cédula no es correcta, por favor verifique!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCedula.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrProducto_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ENInventario.INProducto enProducto = new ENInventario.INProducto();
            Utilidades.Inventario.BuscarDatos objBuscarDatos = new Utilidades.Inventario.BuscarDatos();
            bool blnExistenDatos = false;
            
            decimal decMontoNeto = 0, decMontoBruto = 0;
            decimal decImpuesto = 0;
            decimal decPesoTon = 0;
            string strNumItem = "";
            int intNroItem = 0;
            int intCantMaxPedir = 0;
            try
            {
                enProducto = objBuscarDatos.ProductoParaTrabajadores(genEntorno.CodEmpresa, genEntorno.IndAlmacenarErrorBD, ref blnExistenDatos);
                if (enProducto != null)
                {
                    if (enProducto.PrecioUnitarioTrab <= 0)
                    {
                        MessageBox.Show("El precio del producto para el trabajador no ha sido definido. Consulte con el Departemento de Ventas!!!", 
                                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Validar que este código no este previamente en la Grid
                    if (e.Button.Index <= 0)
                    {
                        if (objFunciones.ExisteRegistroEnGrid(grdvItemPedido, "CodProductoTrab", enProducto.CodProductoTrab) == true)
                        {
                            MessageBox.Show("El producto ya se encuentra agregado en el pedido, " +
                                            "si lo desea puede editar la cantidad a solicitar!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }


                    decCantLaminas = 1;
                    intNroItem = Convert.ToInt16(gcCodProductoTrab.SummaryItem.SummaryValue) + 1;
                    strNumItem = objFunciones.AddCerosIzq(intNroItem.ToString(), 3 - intNroItem.ToString().Length);

                    decPesoTon = (enProducto.PesoUnidad * decCantLaminas)/1000;
                    decMontoBruto = enProducto.PrecioUnitarioTrab * decCantLaminas;
                    decImpuesto = (decMontoBruto * enEmpresa.TasaImpuesto)/100;
                    decMontoNeto = decMontoBruto + decImpuesto;

                    //Calcular la cantidad de laminas máximas a pedir
                    //intCantMaxPedir = Convert.ToInt16(Math.Truncate( decMontoAutPedido / decMontoNeto));
                    intCantMaxPedir = enEmpresa.CantLaminas;

                    
                    //if (intCantMaxPedir < 1)
                    //{
                    //    MessageBox.Show("El % autorizado no permite la realización del pedido de este producto, La Transacción será cancelada!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return;
                    //}
                    //else
                    //{
                        if (intCantMaxPedir > enEmpresa.CantLaminas)
                            intCantMaxPedir = enEmpresa.CantLaminas;

                        decCantLaminas = enEmpresa.CantLaminas - (decimal)gcCantPedida.SummaryItem.SummaryValue;
                        if ((decimal)gcCantPedida.SummaryItem.SummaryValue >= enEmpresa.CantLaminas)
                        {
                            MessageBox.Show("La cantidad del producto a ser agregado excede el límite de unidades permitidas por trabajador. La Transacción será cancelada!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }


                        
                        //Asignar los nuevos valores con la cantidad máxima que puede solicitar
                        //decCantLaminas = decCantLaminas;
                        //decCantLaminas = intCantMaxPedir;
                        if (enProducto.ExistenciaDisponible < decCantLaminas)
                        {
                            decCantLaminas = enProducto.ExistenciaDisponible;
                        }
                        decPesoTon = (enProducto.PesoUnidad * decCantLaminas) / 1000;
                        decMontoBruto = enProducto.PrecioUnitarioTrab * decCantLaminas;
                        decImpuesto = (decMontoBruto * enEmpresa.TasaImpuesto) / 100;
                        decMontoNeto = decMontoBruto + decImpuesto;
                //    }


                    //if (decMontoNeto > decMontoAutPedido)
                    //{
                    //    MessageBox.Show("Las unidades a solicitar excede la cantidad autizada. Solo puede solicitar un monto en pedido correspondiente al 30% del valor de su sueldo." +
                    //                    "La Transacción será cancelada!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return;
                    //}


                    grdvItemPedido.AddNewRow();
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "CodProductoTrab", enProducto.CodProductoTrab);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "DescProducto", enProducto.DescProducto.Trim());
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "NumItem", strNumItem);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "CantidadPedida", (enProducto.ExistenciaDisponible < decCantLaminas? enProducto.ExistenciaDisponible : decCantLaminas));
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "PrecioUnitarioTrab", enProducto.PrecioUnitarioTrab);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "Descuento", 0);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "DesctoEspecial", 0);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "PesoUnidad", enProducto.PesoUnidad);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "TasaImpuesto", enEmpresa.TasaImpuesto);
                    //grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "Impuesto", decImpuesto);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "Impuesto", 0);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "MontoBruto", decMontoBruto);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "MontoNeto", decMontoNeto);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "CodLinea", enProducto.CodLinea);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "CodProducto", enProducto.CodProducto);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "CodAlmacen", enProducto.CodAlmacen);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "CodPlanta", enProducto.CodPlanta);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "CodEmpresa", enProducto.CodEmpresa);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "CodTipoDocumento", mstrCodTipoPedido);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "PesoToneladas", decPesoTon);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "TasaCambio", decCambioDivisa);
                    grdvItemPedido.SetRowCellValue(grdvItemPedido.FocusedRowHandle, "ExistenciaDisponible", enProducto.ExistenciaDisponible);
                }
                else
                {
                    if (blnExistenDatos == false)
                        MessageBox.Show(Aplicacion.Constantes.MsgNoHayRegistros, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdvItemPedido_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = grdvItemPedido.GetDataRow(e.RowHandle);
        }

        private void grdvItemPedido_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (grdvItemPedido.FocusedRowHandle < 0)
            {
                grdvItemPedido.Columns["CodProductoTrab"].ColumnEdit = btnrProducto;
                e.Column.OptionsColumn.AllowEdit = true;
            }
            else
            {
                grdvItemPedido.Columns["CodProductoTrab"].ColumnEdit = null;
                e.Column.OptionsColumn.AllowEdit = false;
            }
        }

              

        private void grdvItemPedido_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grdvItemPedido_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {

            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Error de Entrada de Datos";
            e.ErrorText = "La Cantidad debe ser un valor numerico positivo";
            grdvItemPedido.HideEditor(); 
        }

        private void grdvItemPedido_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (grdvItemPedido.FocusedColumn.Name == "gcCantPedida")
            {
                if (Convert.ToInt32(e.Value) < 0)
                    e.Value = false;
            }
        }

       


        private void grdvItemPedido_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if (grdvItemPedido.GetRowCellValue(e.RowHandle, "CodProducto").ToString() == "0" || grdvItemPedido.GetRowCellValue(e.RowHandle, "CodProducto") == null)
                {
                    e.Valid = false;
                    grdvItemPedido.SetColumnError(grdvItemPedido.Columns["CodProducto"], "Seleccione el Producto para el detalle de la Lista de Precio!!!");
                    return;
                }
                else
                {
                    e.Valid = true;
                    grdvItemPedido.SetColumnError(grdvItemPedido.Columns["CodProducto"], "");
                }

                if ((decimal)grdvItemPedido.GetRowCellValue(e.RowHandle, "CantidadPedida") <= 0 || grdvItemPedido.GetRowCellValue(e.RowHandle, "CantidadPedida") == null ||
                    (decimal)grdvItemPedido.GetRowCellValue(e.RowHandle, "CantidadPedida") > enEmpresa.CantLaminas)
                {
                    e.Valid = false;
                    if ((decimal)grdvItemPedido.GetRowCellValue(e.RowHandle, "CantidadPedida") > enEmpresa.CantLaminas)
                        grdvItemPedido.SetColumnError(grdvItemPedido.Columns["CantidadPedida"], "La cantidad máxima a pedir por trabajado es: " + enEmpresa.CantLaminas.ToString());
                    else
                        grdvItemPedido.SetColumnError(grdvItemPedido.Columns["CantidadPedida"], "Indique la cantidad a Pedir del producto!!!");
                    return;
                }
                else
                {
                    e.Valid = true;
                    grdvItemPedido.SetColumnError(grdvItemPedido.Columns["CantidadPedida"], "");
                }

                if (Convert.ToDecimal(grdvItemPedido.GetRowCellValue(e.RowHandle, "CantidadPedida")) >
                    Convert.ToDecimal(grdvItemPedido.GetRowCellValue(e.RowHandle, "ExistenciaDisponible")))
                {
                    e.Valid = false;
                    blnExistenciaValida = false;
                    grdvItemPedido.SetColumnError(grdvItemPedido.Columns["CantidadPedida"], "No hay Existencia suficiente para la cantidad solicitada");
                }
                else
                {
                    e.Valid = true;
                    blnExistenciaValida = true;
                    grdvItemPedido.SetColumnError(grdvItemPedido.Columns["CantidadPedida"], "");
                }

                //****** Calcular Totales

                txtTotalMBruto.Text = Convert.ToString(Convert.ToDouble(txtTotalMBruto.Text) + Convert.ToDouble(grdvItemPedido.GetRowCellValue(e.RowHandle, "MontoBruto")));

                if (chkTransfBancarias.Checked == false)
                {
                    DialogResult result = MessageBox.Show("El Pago se realizará con Transferencia Bancaria o Punto de Venta?", "Forma de Pago", MessageBoxButtons.YesNo);

                    switch (result)
                    {
                    case DialogResult.Yes:
                        chkTransfBancarias.Checked=true;
                        break;
                    case DialogResult.No:
                        chkTransfBancarias.Checked=false;
                        break;
                    }
                }

                //**** Validar Tasa de Impuesto a Aplicar si es Transferencia
                if (chkTransfBancarias.Checked == true)
                {
                    double dblImpuestoAplica = 0;
                    chkTransfBancarias.Enabled = false;
                    if (DateEdFecMov.DateTime.Date <= enEmpresa.FechaFinDescTopeTransf.Date)
                    {
                        if (Convert.ToDouble(txtTotalMBruto.Text) <= Convert.ToDouble(enEmpresa.IndTopeDescImpuestoTransf))
                        {
                            dblImpuestoAplica = Convert.ToDouble(enEmpresa.TasaImpuesto) - Convert.ToDouble(enEmpresa.DescTasaImpTransfA);
                        }
                        else
                        {
                            dblImpuestoAplica = Convert.ToDouble(enEmpresa.TasaImpuesto) - Convert.ToDouble(enEmpresa.DescTasaImpTransfB);
                        }
                         
                        lblTasaImp.Text = Convert.ToString(dblImpuestoAplica);
                        txtImpuesto.Text = Convert.ToString(Convert.ToDouble(txtTotalMBruto.Text) * Convert.ToDouble(dblImpuestoAplica / 100));
                    }
                    else
                    {
                        lblTasaImp.Text = Convert.ToString(enEmpresa.TasaImpuesto);
                        txtImpuesto.Text = Convert.ToString(Convert.ToDouble(txtTotalMBruto.Text) * Convert.ToDouble((enEmpresa.TasaImpuesto) / 100));
                    }
                }
                else
                {
                    lblTasaImp.Text = Convert.ToString(enEmpresa.TasaImpuesto);
                    txtImpuesto.Text = Convert.ToString(Convert.ToDouble(txtTotalMBruto.Text) * Convert.ToDouble((enEmpresa.TasaImpuesto) / 100));
                }

                txtTotalMNeto.Text = Convert.ToString(Convert.ToDouble(txtTotalMBruto.Text) + Convert.ToDouble(txtImpuesto.Text));

                double dblTotalMontoBruto = Convert.ToDouble(txtTotalMBruto.Text);
                double dblTotalImpuesto = Convert.ToDouble(txtImpuesto.Text);
                double dblTotalMontoNeto = Convert.ToDouble(txtTotalMNeto.Text);

                txtTotalMBruto.Text = dblTotalMontoBruto.ToString("N2");
                txtImpuesto.Text = dblTotalImpuesto.ToString("N2");
                txtTotalMNeto.Text = dblTotalMontoNeto.ToString("N2");

            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdvItemPedido_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal decImpuesto = 0;
            decimal decMontoNeto = 0, decMontoBruto=0;
            decimal decPesoTon = 0;
            try
            {
                if(objFunciones.SoloNumero(e.Value.ToString())==false)
                {
                    MessageBox.Show("La Cantidad debe ser un valor numerico positivo!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   
                    return;
                }

                if (e.Value.ToString().Trim().Length > 0)
                {
                    if (Convert.ToDecimal(e.Value) > 0 && Convert.ToDecimal(e.Value) <= decCantLaminas)
                    {
                        decPesoTon = (Convert.ToDecimal(e.Value) * (decimal)grdvItemPedido.GetFocusedRowCellValue("PesoUnidad")) / 1000;
                        decMontoBruto = (decimal)grdvItemPedido.GetFocusedRowCellValue("PrecioUnitarioTrab") * Convert.ToDecimal(e.Value);
                        decImpuesto = (decMontoBruto * enEmpresa.TasaImpuesto) / 100;
                        decMontoNeto = decMontoBruto + decImpuesto;

                        grdvItemPedido.SetFocusedRowCellValue("MontoBruto", decMontoBruto);
                        grdvItemPedido.SetFocusedRowCellValue("Impuesto", decImpuesto);
                        grdvItemPedido.SetFocusedRowCellValue("MontoNeto", decMontoNeto);
                        grdvItemPedido.SetFocusedRowCellValue("PesoToneladas", decPesoTon);


                        //if (TotalFacturarValido(decMontoNeto, Convert.ToDecimal(e.Value)))
                        //{
                        //    grdvItemPedido.SetFocusedRowCellValue("MontoBruto", decMontoBruto);
                        //    grdvItemPedido.SetFocusedRowCellValue("Impuesto", decImpuesto);
                        //    grdvItemPedido.SetFocusedRowCellValue("MontoNeto", decMontoNeto);
                        //    grdvItemPedido.SetFocusedRowCellValue("PesoToneladas", decPesoTon);
                        //}
                    }
                    else
                    {
                        if (Convert.ToDecimal(e.Value) <= decCantLaminas)
                        {
                            decPesoTon = ((decimal)Convert.ToDecimal(e.Value) * (decimal)grdvItemPedido.GetFocusedRowCellValue("PesoUnidad")) / 1000;
                            grdvItemPedido.SetFocusedRowCellValue("CantidadPedida", Convert.ToDecimal(e.Value));
                            decMontoBruto = (decimal)grdvItemPedido.GetFocusedRowCellValue("PrecioUnitarioTrab") * Convert.ToDecimal(e.Value);
                            decImpuesto = (decMontoBruto * enEmpresa.TasaImpuesto) / 100;
                            decMontoNeto = decMontoBruto + decImpuesto;
                            grdvItemPedido.SetFocusedRowCellValue("MontoBruto", decMontoBruto);
                            grdvItemPedido.SetFocusedRowCellValue("Impuesto", decImpuesto);
                            grdvItemPedido.SetFocusedRowCellValue("MontoNeto", decMontoNeto);
                            grdvItemPedido.SetFocusedRowCellValue("PesoToneladas", decPesoTon);
                        }
                        else
                        {
                            decPesoTon = ((decimal)grdvItemPedido.GetFocusedRowCellValue("CantidadPedida") * (decimal)grdvItemPedido.GetFocusedRowCellValue("PesoUnidad")) / 1000;
                            grdvItemPedido.SetFocusedRowCellValue("CantidadPedida", decCantLaminas);
                            decMontoBruto = (decimal)grdvItemPedido.GetFocusedRowCellValue("PrecioUnitarioTrab") * (decimal)grdvItemPedido.GetFocusedRowCellValue("CantidadPedida");
                            decImpuesto = (decMontoBruto * enEmpresa.TasaImpuesto) / 100;
                            decMontoNeto = decMontoBruto + decImpuesto;
                            grdvItemPedido.SetFocusedRowCellValue("MontoBruto", decMontoBruto);
                            grdvItemPedido.SetFocusedRowCellValue("Impuesto", decImpuesto);
                            grdvItemPedido.SetFocusedRowCellValue("MontoNeto", decMontoNeto);
                            grdvItemPedido.SetFocusedRowCellValue("PesoToneladas", decPesoTon);
                            MessageBox.Show("La cantidad tipeada excede el límite permitido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int intResiduo = 0;
            intResiduo = DateTime.Now.Second / 5;
            lblAviso.Text = "";
            lblAviso.Visible = true;

            if (intResiduo == 0 || intResiduo == 11 || intResiduo == 26 | intResiduo == 50)
            {
                //lblAviso.Text = "La venta de productos es de máximo de 7 unidades por mes no acumulables";
                lblAviso.Text = "El monto de la venta de productos corresponde al 30% del valor del sueldo del trabajador " + Environment.NewLine +
                                "y a un máximo de 7 unidades por mes no acumulables";
                lblAviso.ForeColor = Color.DarkRed;
                return;
            }

            if (intResiduo == 1 || intResiduo == 12 || intResiduo == 27 | intResiduo == 51)
            {
                lblAviso.Text = "Días para realizar el pedido y pago del producto: lunes, martes y miércoles";
                lblAviso.ForeColor = Color.SteelBlue; 
                return;
            }

            if (intResiduo == 2 || intResiduo == 13 || intResiduo == 28 | intResiduo == 52)
            {
                lblAviso.Text = "Días para retirar el producto: de lunes a viernes hasta medio día";
                lblAviso.ForeColor = Color.Indigo; 
                return;
            }

            if (intResiduo == 3 || intResiduo == 14 || intResiduo == 29 | intResiduo == 53)
            {
                lblAviso.Text = "La vigencia del pedido es de una semana";
                lblAviso.ForeColor = Color.Purple; 
                return;
            }

            if (intResiduo == 4 || intResiduo == 15 || intResiduo == 30 | intResiduo == 54)
            {
                lblAviso.Text = "No se tramitaran solicitudes o entregas el día de cierre de mes";
                lblAviso.ForeColor = Color.Crimson;
                return;
            }
            else
            {
                lblAviso.Text = "";
                return;
            }

        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Validar la Huella Daptilar 
            frmMain objMain = new frmMain();           
            objMain.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////Validar la Huella Daptilar 
            //frmCaptaHuella objCaptaHuella = new frmCaptaHuella();
            //objCaptaHuella.strNombTrabajador = txtNomTrabajador.Text;
            //objCaptaHuella.Show();
        }

        private void DateEdFecMov_EditValueChanged(object sender, EventArgs e)
        {

            //Utilidades.Funciones objFunciones = new Utilidades.Funciones();
            //DateTime dtFecTopeMovimiento = Convert.ToDateTime(objFunciones.FechaTopeMovimiento(false));
            //DateTime dtFecInicioMovimiento = Convert.ToDateTime("01" + "/" + dtFecTopeMovimiento.Month.ToString() + "/" + dtFecTopeMovimiento.Year.ToString());

            //if ((DateEdFecMov.DateTime <= dtFecInicioMovimiento.Date) | (DateEdFecMov.DateTime >= dtFecTopeMovimiento.Date))
            //{ 
            //    DateEdFecMov.DateTime = dtFecTopeMovimiento.Date; 
            //}
        }

        private void grdItemPedido_Click(object sender, EventArgs e)
        {

        }




   
     
    }
}