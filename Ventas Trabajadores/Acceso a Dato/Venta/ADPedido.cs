using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;
using System.Linq;
using Utilidades;

namespace ADVenta
{
    
    public class ADPedido
    {
        //Variables
        private static decimal decNumDocumentoIncluido = 0;
        private static string strNumDocumento = "";

        //Utilidades
        private static Utilidades.Funciones objFunciones = new Utilidades.Funciones();
        private static Utilidades.CargarEntidad objCargarEntidad = new CargarEntidad();
        private static Utilidades.Procedimientos objProcedimiento = new Utilidades.Procedimientos();

        #region//********************************PEDIDO**********************************//
        public static bool RegistrarPedido(ENventa.VEPedido enPedido, ENventa.VEPedidoItems clPedidoItems,
                                           string strRutaArchivo, string strNombImpresora, bool blnAlmacenarError, 
                                           ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            SqlTransaction ObjTran = null;
            bool blnValor = false, blnTerminado = false; ;
            decimal dcTasaImpuesto;
            string strCodCli ="", strNombCliente="";
            try
            {
                cnnConexion = objAD.AbrirConexion();
                ObjTran = cnnConexion.BeginTransaction();
                decNumDocumentoIncluido = 0;
                strCodCli = enPedido.CodCliente;
                strNombCliente = enPedido.NomCliente;
                dcTasaImpuesto = enPedido.TasaImpuesto;

                if (IncluirPedido(enPedido, cnnConexion, ObjTran, blnAlmacenarError, ref enError))
                {
                    if (ADGeneral.ADTipoDocumento.ActualizarCorrelativo(enPedido.CodEmpresa, enPedido.CodTipoDocumento, "VE", decNumDocumentoIncluido,
                                                                      cnnConexion, ObjTran, blnAlmacenarError, ref enError))
                    {
                        if (IncluirPedidoItem(decNumDocumentoIncluido,enPedido.CodCliente,enPedido.CodZonaVentaNuevo, clPedidoItems, enPedido.CondPago, 
                                               cnnConexion, ObjTran, blnAlmacenarError, ref enError,Convert.ToDouble(dcTasaImpuesto)))
                        {
                            ObjTran.Commit();
                            blnValor = true;
                            //objProcedimiento.ImprimirTicketPedido(strNombImpresora, strRutaArchivo, strNumDocumento, strCodCli, strNombCliente,
                            //                                      clPedidoItems, ref blnTerminado);
                        }
                        else
                            blnValor = false;
                    }

                }
                else
                    blnValor = false;
                return blnValor;
            }
            catch (Exception ex)
            {
                if (cnnConexion.State == ConnectionState.Open)
                    ObjTran.Rollback();
                throw ex;
            }
            finally
            {
                if (cnnConexion.State == ConnectionState.Open)
                    cnnConexion.Close();
            }
        }

        private static bool IncluirPedido(ENventa.VEPedido enPedido, SqlConnection cnnConexion, SqlTransaction ObjTran,
                                          bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            Hashtable htParametros = new Hashtable();
            short intCuantos;
            bool blnValor = false;
            ENGeneral.GNTiposDocumento enTipoDocumento = new GNTiposDocumento();
            try
            {
                enTipoDocumento = ADGeneral.ADTipoDocumento.Consultar(enPedido.CodTipoDocumento, enPedido.CodEmpresa, blnAlmacenarError, ref enError);
                if (enTipoDocumento != null)
                {
                    decNumDocumentoIncluido =enTipoDocumento.Correlativo +1;
                }
                
                if ((enError.MensajeError.Trim().Length > 0 ? false : true) == false)
                    return false;

                intCuantos = Convert.ToInt16(8 - decNumDocumentoIncluido.ToString().Length);
                strNumDocumento = objFunciones.AddCerosIzq(decNumDocumentoIncluido.ToString(), intCuantos);

                htParametros.Add("@Cod_Empresa", enPedido.CodEmpresa);
                htParametros.Add("@Cod_Tipo_Documento", enPedido.CodTipoDocumento);
                htParametros.Add("@Num_Documento", strNumDocumento);
                htParametros.Add("@Fec_Registro", enPedido.FecRegistro);
                htParametros.Add("@Cod_Cliente", enPedido.CodCliente);
                htParametros.Add("@Nom_Cliente", enPedido.NomCliente);
                htParametros.Add("@Rif", enPedido.Rif);
                htParametros.Add("@Nit", enPedido.Nit);
                htParametros.Add("@Tipo_Pedido", enPedido.TipoPedido);
                htParametros.Add("@Tipo_Divisa", enPedido.TipoDivisa);
                htParametros.Add("@Cod_Zona_Venta", enPedido.CodZonaVenta);
                htParametros.Add("@Cod_Zona_Despacho", enPedido.CodZonaDespacho);
                htParametros.Add("@Fec_Entregar", enPedido.FecEntregar);
                htParametros.Add("@Tipo_Transporte", enPedido.TipoTransporte);
                htParametros.Add("@Direccion1", enPedido.Direccion1);
                htParametros.Add("@Direccion2", enPedido.Direccion2);
                htParametros.Add("@Direccion3", enPedido.Direccion3);
                htParametros.Add("@Cliente_Destino", enPedido.ClienteDestino);
                htParametros.Add("@Dir1", enPedido.Dir1);
                htParametros.Add("@Dir2", enPedido.Dir2);
                htParametros.Add("@Dir3", enPedido.Dir3);
                htParametros.Add("@Cod_Ciudad", enPedido.CodCiudad);
                htParametros.Add("@Cod_Pais", enPedido.CodPais);
                htParametros.Add("@Orden_Compra", enPedido.OrdenCompra);
                htParametros.Add("@Cond_Pago", enPedido.CondPago);
                htParametros.Add("@Observaciones", enPedido.Observaciones);
                htParametros.Add("@Obser_Factura", enPedido.ObserFactura);
                htParametros.Add("@Estado_Documento", enPedido.EstadoDocumento);
                htParametros.Add("@Usuario", enPedido.Usuario);
                htParametros.Add("@Usuario_Modifica", enPedido.UsuarioModifica);
                htParametros.Add("@Fec_Modificacion", enPedido.FecModificacion);
                htParametros.Add("@Tasa_Impuesto", enPedido.TasaImpuesto);
                htParametros.Add("@Monto_Impuesto", enPedido.MontoImpuesto);
                htParametros.Add("@Monto_Bruto", enPedido.MontoBruto);
                htParametros.Add("@Monto_Neto", enPedido.MontoNeto);
                htParametros.Add("@Monto_Flete", enPedido.MontoFlete);
                htParametros.Add("@Peso_Neto", enPedido.PesoNeto);
                htParametros.Add("@Tasa_Cambio", enPedido.TasaCambio);
                htParametros.Add("@Ind_Consignacion", enPedido.IndConsignacion);
                htParametros.Add("@Cod_Sucursal", enPedido.CodSucursal);
                htParametros.Add("@Cod_Vendedor", enPedido.CodVendedor);
                htParametros.Add("@Ind_Pedido_Trabajador", enPedido.IndPedidoTrabajador);
                htParametros.Add("@CodZonaVentaNuevo", enPedido.CodZonaDespachoNuevo);
                htParametros.Add("@CodZonaDespachoNuevo", enPedido.CodZonaDespachoNuevo);
                htParametros.Add("@Fec_Movimiento", enPedido.FecMovimiento);
                htParametros.Add("@Ind_Pago_Transferencia", enPedido.IndPagoTransferencia);

                if (objAD.EjecutarProcedimiento("[dbo].VEaddPedidos", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                htParametros, blnAlmacenarError, ref enError) > 0)
                    blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                else
                    blnValor = false;
                return blnValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EliminarPedido(ENventa.VEPedido enPedido, ENventa.VEPedidoItems clItems, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            SqlTransaction ObjTran = null;
            Hashtable htParametros = new Hashtable();
            bool blnValor = false;
            try
            {
                cnnConexion = objAD.AbrirConexion();
                ObjTran = cnnConexion.BeginTransaction();
                htParametros.Add("@Cod_Empresa", enPedido.CodEmpresa);
                htParametros.Add("@Cod_Tipo_Documento", enPedido.CodTipoDocumento);
                htParametros.Add("@Num_Documento", enPedido.NumDocumento);
                htParametros.Add("@Usuario_Modifica", enPedido.UsuarioModifica);

                blnValor = AnularItemPedido(clItems, cnnConexion, ObjTran, blnAlmacenarError, ref enError);
                if (blnValor == true)
                {
                    //Falta llamar al procd. que actualiza las estadisticas
                    blnValor = true;

                    if (blnValor == true)
                    {
                        if (objAD.EjecutarProcedimiento("[dbo].VECerrarPedidos", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                         htParametros, blnAlmacenarError, ref enError) > 0)
                            blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                        else
                            blnValor = false;
                    }
                }
                return blnValor;
                
            }
            catch (Exception ex)
            {
                if (cnnConexion.State == ConnectionState.Open)
                    ObjTran.Rollback();
                throw ex;
            }
            finally
            {
                if (cnnConexion.State == ConnectionState.Open)
                    cnnConexion.Close();
            }
        }


        private static bool AnularItemPedido(ENventa.VEPedidoItems clItems, SqlConnection cnnConexion, SqlTransaction ObjTran,
                                          bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            Hashtable htParametros = new Hashtable();
            bool blnValor = false;
            try
            {
                foreach (ENventa.VEPedidoItem enItem in clItems)
                {
                    htParametros.Clear();
                    htParametros.Add("@Cod_Empresa", enItem.CodEmpresa);
                    htParametros.Add("@Cod_Tipo_Documento", enItem.CodTipoDocumento);
                    htParametros.Add("@Num_Documento", enItem.NumDocumento);
                    htParametros.Add("@Cod_Producto", enItem.CodProducto);
                    htParametros.Add("@Serial_Producto", enItem.SerialProducto);

                    if (objAD.EjecutarProcedimiento("[dbo].VECerrarItemsPedidos", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                     htParametros, blnAlmacenarError, ref enError) > 0)
                        blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                    else
                        blnValor = false;

                    if (blnValor==true)
                    {
                          blnValor = ADInventario.ADExistenciaProducto.ReservarExistencia(enItem.CodEmpresa, enItem.CodPlanta, enItem.CodAlmacen,
                                                                                        enItem.CodProducto, enItem.CantidadPedida, "D",
                                                                                        cnnConexion, ObjTran, blnAlmacenarError, ref enError);
                    }

                    if (blnValor == false)
                        break;
                }
                return blnValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ENventa.VEPedido PepidoEnProceso(string strCodEmpresa, string strCodCliente, string strFechaDesde,
                                                        string strFechaHasta, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConex = new SqlConnection();
            SqlTransaction ObjTran = null;
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENventa.VEPedido enPedido = new ENventa.VEPedido();
            try
            {
                cnnConex = objAD.AbrirConexion();
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodCliente", strCodCliente);
                htParametros.Add("@FecDesde", strFechaDesde);
                htParametros.Add("@FecHasta", strFechaHasta);

                dt = objAD.EjecutarConsulta("[dbo].SqlPedidoEnProceso", cnnConex, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enPedido.CodTipoDocumento = dt.Rows[0]["Cod Tipo Documento"].ToString();
                    enPedido.NumDocumento = dt.Rows[0]["Num Documento"].ToString();
                    enPedido.CodCliente = dt.Rows[0]["Cod Cliente"].ToString();
                    enPedido.NomCliente = dt.Rows[0]["Nom Cliente"].ToString();
                    enPedido.NumCarga = dt.Rows[0]["Num Carga"].ToString();
                    enPedido.NumFactura = dt.Rows[0]["Num Factura"].ToString();
                    enPedido.CantPedio = (decimal)dt.Rows[0]["Cantidad Pedida"];
                    return (enPedido);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnnConex.State == ConnectionState.Open)
                    cnnConex.Close();
            }
        }


        public static ENventa.VEPedidos PedidosPendienteTrabajador(string strCodEmpresa, string strCodCliente,
                                                                   string strFechaDesde, string strFechaHasta,
                                                                   bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConex = new SqlConnection();
            SqlTransaction ObjTran = null;
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENventa.VEPedidos clPedidos = new ENventa.VEPedidos();
            try
            {
                cnnConex = objAD.AbrirConexion();
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodCliente", strCodCliente);
                htParametros.Add("@FecDesde", strFechaDesde);
                htParametros.Add("@FecHasta", strFechaHasta);

                dt = objAD.EjecutarConsulta("[dbo].SqlPedidosPendienteTrab", cnnConex, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ENventa.VEPedido enPedido;
                    foreach (DataRow dr in dt.Rows)
	                {
                        enPedido = new ENventa.VEPedido();
                        enPedido.CodEmpresa = dr["Cod Empresa"].ToString();
                        enPedido.CodTipoDocumento = dr["Cod Tipo Documento"].ToString();
                        enPedido.NumDocumento = dr["Num Documento"].ToString();
                        enPedido.CodCliente = dr["Cod Cliente"].ToString();
                        enPedido.NomCliente = dr["Nom Cliente"].ToString();
                        enPedido.Rif = dr["Rif"].ToString();
                        enPedido.FecRegistro = (DateTime)dr["Fec Registro"];
                        enPedido.MontoBruto = (decimal)dr["Monto Bruto"];
                        enPedido.MontoImpuesto = (decimal)dr["Monto Impuesto"];
                        enPedido.MontoNeto = (decimal)dr["Monto Neto"];
                        enPedido.Direccion1 = dr["Direccion1"].ToString();
                        enPedido.Direccion2 = dr["Direccion2"].ToString();
                        enPedido.Direccion3 = dr["Direccion3"].ToString();
                        enPedido.Dir1 = dr["Dir1"].ToString();
                        enPedido.Dir2 = dr["Dir2"].ToString();
                        enPedido.Dir3 = dr["Dir3"].ToString();
                        clPedidos.Add(enPedido);
	                }
                    return (clPedidos);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnnConex.State == ConnectionState.Open)
                    cnnConex.Close();
            }
        }

        
        #endregion

        #region//********************************ITEM PEDIDO**********************************//
        private static bool IncluirPedidoItem(decimal intIdSolicitud, string strCodCliente, string strCodZonaVenta, ENventa.VEPedidoItems clPedidoItems, 
                                              string strCondPago, SqlConnection cnnConexion, SqlTransaction ObjTran, bool blnAlmacenarError, ref Aplicacion.Error enError,double dblTasaImpuesto)
        {
            AccesoDato objAD = new AccesoDato();
            Hashtable htParametros = new Hashtable();
            ENventa.VEPedidoItem enPedidoItem;
            double dblMontoBruto = 0;
            double dblImpuesto = 0;
            bool blnValor = false;
            try
            {
                if (clPedidoItems.Count > 0)
                {
                    for (int i = 0; i < clPedidoItems.Count; i++)
                    {
                        enPedidoItem = clPedidoItems.ElementAt(i);
                        objCargarEntidad.AsignarValoresaCamposNull(enPedidoItem); 
                        
                        htParametros.Clear();
                        
                        htParametros.Add("@Cod_Empresa", enPedidoItem.CodEmpresa);
                        htParametros.Add("@Cod_Tipo_Documento", enPedidoItem.CodTipoDocumento);
                        htParametros.Add("@Num_Documento", strNumDocumento);
                        htParametros.Add("@Cod_Producto", enPedidoItem.CodProducto);
                        htParametros.Add("@Nom_Producto", enPedidoItem.DescProducto);
                        htParametros.Add("@Serial_Producto", enPedidoItem.SerialProducto);
                        htParametros.Add("@Num_Item", enPedidoItem.NumItem);
                        htParametros.Add("@Cantidad_Pedida", enPedidoItem.CantidadPedida);
                        htParametros.Add("@Cantidad_Despachada", enPedidoItem.CantidadDespachada);
                        htParametros.Add("@Precio_Ventas", enPedidoItem.PrecioUnitarioTrab);
                        htParametros.Add("@Descuento", enPedidoItem.Descuento);
                        htParametros.Add("@Fec_Despacho", enPedidoItem.FecDespacho);
                        htParametros.Add("@Fec_Ultimo_Despacho", enPedidoItem.FecUltimoDespacho);
                        htParametros.Add("@Fec_Registro", enPedidoItem.FecRegistro);
                        htParametros.Add("@Ind_Reserva", "N");
                        htParametros.Add("@Descto_Especial", enPedidoItem.DesctoEspecial);
                        htParametros.Add("@Peso_Unidad", enPedidoItem.PesoUnidad);

                        dblMontoBruto= Convert.ToDouble(enPedidoItem.PrecioUnitarioTrab) * Convert.ToDouble(enPedidoItem.CantidadPedida);
                        dblImpuesto = Convert.ToDouble((dblMontoBruto * dblTasaImpuesto)/100);

                        htParametros.Add("@Impuesto", Convert.ToDecimal(dblImpuesto));
                        htParametros.Add("@Tasa_Impuesto", Convert.ToDecimal(dblTasaImpuesto));
                        //htParametros.Add("@Impuesto", enPedidoItem.Impuesto);
                        //htParametros.Add("@Tasa_Impuesto", enPedidoItem.TasaImpuesto);
                        htParametros.Add("@Cond_Pago", strCondPago);
                        htParametros.Add("@Tasa_Cambio", 1);
                        htParametros.Add("@Cant_Reservada", enPedidoItem.CantidadReservada);
                        htParametros.Add("@Cod_Linea", enPedidoItem.CodLinea);
                            
                        if (objAD.EjecutarProcedimiento("[dbo].VEaddItemsPedidos", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                    htParametros, blnAlmacenarError, ref enError) > 0)
                        {
                            blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                            if (blnValor == false)
                                break;
                            else
                                blnValor = ADInventario.ADExistenciaProducto.ReservarExistencia(enPedidoItem.CodEmpresa, enPedidoItem.CodPlanta, enPedidoItem.CodAlmacen,
                                                                                                enPedidoItem.CodProducto, enPedidoItem.CantidadPedida, "A",
                                                                                                cnnConexion, ObjTran, blnAlmacenarError, ref enError);   
                                if (blnValor== false)
                                    break;

                                blnValor = ActualizarEstadisticasVentas(enPedidoItem.CodEmpresa, enPedidoItem.CodPlanta, strCodZonaVenta, strCodCliente, enPedidoItem.CodProducto,
                                                                        enPedidoItem.CodLinea, enPedidoItem.CantidadPedida, enPedidoItem.PesoToneladas, (enPedidoItem.PrecioUnitarioTrab * enPedidoItem.CantidadPedida * enPedidoItem.TasaCambio),
                                                                        "S", enPedidoItem.CantidadPedida, (enPedidoItem.PesoUnidad * enPedidoItem.CantidadPedida) / 1000,
                                                                        cnnConexion, ObjTran, blnAlmacenarError, ref enError);
                                if (blnValor == false)
                                    break;
                        }
                        else
                        {
                            blnValor = false;
                            break;
                        }
                    }
                }
                else
                    blnValor = false;
                return blnValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ENventa.VEPedidoItems ItemsPedidoTrabajador(string strCodEmpresa, string strCodTipoDocumento, string strNumDocumento,
                                                                  bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConex = new SqlConnection();
            SqlTransaction ObjTran = null;
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENventa.VEPedidoItems clItems = new ENventa.VEPedidoItems();
            try
            {
                cnnConex = objAD.AbrirConexion();
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodTipoDoc", strCodTipoDocumento);
                htParametros.Add("@NumDocumento", strNumDocumento);

                dt = objAD.EjecutarConsulta("[dbo].SqlItemsPedidoTrabajador", cnnConex, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ENventa.VEPedidoItem enItem;
                    foreach (DataRow dr in dt.Rows)
                    {
                        enItem = new ENventa.VEPedidoItem();
                        enItem.CodEmpresa=dr["Cod Empresa"].ToString();
                        enItem.CodTipoDocumento = dr["Cod Tipo Documento"].ToString();
                        enItem.NumDocumento = dr["Num Documento"].ToString();
                        enItem.CodProducto = dr["Cod Producto"].ToString();
                        enItem.CodProductoTrab = dr["Cod Producto Trab"].ToString();
                        enItem.DescProducto = dr["Desc Producto"].ToString();
                        enItem.SerialProducto = dr["Serial Producto"].ToString();
                        enItem.NumItem = dr["Num Item"].ToString();
                        enItem.CantidadPedida = (decimal)dr["Cantidad Pedida"];
                        enItem.CantidadDespachada = (decimal)dr["Cantidad Despachada"];
                        enItem.PrecioVentas = (decimal)dr["Precio Ventas"];
                        enItem.Descuento = (decimal)dr["Descuento"];
                        enItem.FecDespacho = (DateTime)dr["Fec Despacho"];
                        enItem.FecUltimoDespacho = (DateTime)dr["Fec Ultimo Despacho"];
                        enItem.FecRegistro = (DateTime)dr["Fec Registro"];
                        enItem.IndReserva = dr["Ind Reserva"].ToString();
                        enItem.DesctoEspecial = (decimal)dr["Descto Especial"];
                        enItem.PesoUnidad = (decimal)dr["Peso Unidad"];
                        enItem.Impuesto = (decimal)dr["Impuesto"];
                        enItem.TasaImpuesto = (decimal)dr["Tasa Impuesto"];
                        enItem.CondPago = dr["Cond Pago"].ToString();
                        enItem.TasaCambio = (decimal)dr["Tasa Cambio"];
                        enItem.CantidadReservada = (decimal)dr["Cantidad Reservada"];
                        enItem.CodLinea = dr["Cod Linea"].ToString();
                        clItems.Add(enItem);
                    }
                    return (clItems);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnnConex.State == ConnectionState.Open)
                    cnnConex.Close();
            }
        }

     
        #endregion

        #region //******************************ESTADISTICAS DE VENTAS*************************//
        private static bool ActualizarEstadisticasVentas(string pCodEmpresa, string pCodPlanta, string pstrZonaVenta,string pstrCliente, string pstrCodProducto,
                                                        string pstrCodLinea, decimal pcurPiezas, decimal pcurToneladas, decimal pcurBsToneladas,
                                                        string pstrIndReserva, decimal pcurCantReserva,decimal pcurTonReserva, 
                                                        SqlConnection cnnConexion, SqlTransaction ObjTran, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            Hashtable htParametros = new Hashtable();
            bool blnValor = false;
            try
            {
                
                htParametros.Clear();
                htParametros.Add("@Cod_Empresa", pCodEmpresa);
                htParametros.Add("@Cod_Zona_Venta", pstrZonaVenta);
                htParametros.Add("@Cod_Cliente", pstrCliente);
                htParametros.Add("@Cod_Producto", pstrCodProducto);
                htParametros.Add("@Cod_Linea", pstrCodLinea);
                htParametros.Add("@Und_Pedidos", pcurPiezas);
                htParametros.Add("@Ton_Pedidos", pcurToneladas);
                htParametros.Add("@Bs_Pedidos", pcurBsToneladas);
                htParametros.Add("@Cant_Reservada", pcurCantReserva);
                htParametros.Add("@Ton_Reservadas", pcurTonReserva);
                htParametros.Add("@Cod_Planta", pCodPlanta);

                if (pstrIndReserva == "S")
                {
                    //Actualizar Reservacion de Pedidos
                    htParametros.Add("@Tipo", 1);                    
                    htParametros.Add("@Dolares_Pedidos", 0);
                    if (objAD.EjecutarProcedimiento("[dbo].VEActualizarAcumuladosPedidos", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                    htParametros, blnAlmacenarError, ref enError) > 0)
                        blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                    else
                        blnValor = false;
                }

                if (blnValor == false)
                    return blnValor;

                //Actualizar Estadisticas de Pedidos
                htParametros.Remove("@Tipo");
                htParametros.Add("@Tipo", 2);
                if (objAD.EjecutarProcedimiento("[dbo].VEActualizarAcumuladosPedidos", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                htParametros, blnAlmacenarError, ref enError) > 0)
                    blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                else
                    blnValor = false;

                if (blnValor == false)
                    return blnValor;

               
                htParametros.Remove("@Tipo");
                htParametros.Add("@Tipo", 3);
                if (objAD.EjecutarProcedimiento("[dbo].VEActualizarAcumuladosPedidos", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                htParametros, blnAlmacenarError, ref enError) > 0)
                    blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                else
                    blnValor = false;

                if (blnValor == false)
                    return blnValor;

 
                htParametros.Clear();
                htParametros.Add("@Cod_Empresa", pCodEmpresa);
                htParametros.Add("@Cod_Planta", pCodPlanta);
                htParametros.Add("@Cod_Almacen", "01");
                htParametros.Add("@Cod_Producto", pstrCodProducto);
                htParametros.Add("@Cantidad", pcurPiezas);
                htParametros.Add("@Tipo", "1");

                if (objAD.EjecutarProcedimiento("[dbo].VEActualizarProductos", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                htParametros, blnAlmacenarError, ref enError) > 0)
                    blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                else
                    blnValor = false;
            
                return blnValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
    
}
