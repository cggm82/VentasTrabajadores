using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion; 

namespace NGVenta
{
    public class NGPedido
    {
        private Error enError = new Error();

        #region //**************************************PEDIDO**************************************//
        public bool Procesar(ENventa.VEPedido enPedido, ENventa.VEPedidoItems clPedidoItem,
                            string strRutaArchivo,string strNombImpresora, Enumerado.AccionSQL Accion, 
                            bool blnAlmacenarError)
        {
            bool blnProceso;
            try
            {

                switch (Accion)
                {
                    //case Enumerado.AccionSQL.Delete:
                    //    blnProceso = ADVenta.ADPedido.EliminarPedido(enPedido, clPedidoItem, blnAlmacenarError, ref enError);
                    //    if (enError.MensajeError.Trim().Length > 0)
                    //        throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                    //    break;
                    case Enumerado.AccionSQL.Insert:
                        enPedido.TipoTransporte = "R"; //Retirado
                        enPedido.TipoPedido = "O"; //Oficina
                        enPedido.EstadoDocumento = "02"; //Autorizado
                        enPedido.IndConsignacion = "N";
                        enPedido.IndPedidoTrabajador = "S";
                        enPedido.TasaCambio = 1;
                        
                        blnProceso = ADVenta.ADPedido.RegistrarPedido(enPedido,clPedidoItem,strRutaArchivo,strNombImpresora,blnAlmacenarError, ref enError);

                        if (enError.MensajeError.Trim().Length > 0)
                            throw new ArgumentException(enError.MensajeError, enError.OrigenError);

                        break;
                    //case Enumerado.AccionSQL.Update:
                    //    if (enSolicitudMovAlmacen.CodCondicion != 1)
                    //        blnProceso = ADInventario.SolicitudMovAlmacen.ActualizarSolicitud(enSolicitudMovAlmacen, clSolicitudMovAlmacenItem,
                    //                                                                          blnAlmacenarError, ref enError);
                    //    else
                    //        blnProceso = true;

                    //    break;
                    default:
                        blnProceso = false;
                        break;
                }
                return blnProceso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ENventa.VEPedido FacturaTrabajadorMes(string strCodEmpresa, string strCodCliente, string strFechaDesde, string strFechaHasta,
                                                  bool blnAlmacenarError)
        {
            ENventa.VEPedido enPedido = new ENventa.VEPedido();
            try
            {
                enPedido = ADVenta.ADPedido.PepidoEnProceso(strCodEmpresa, strCodCliente, strFechaDesde,strFechaHasta,
                                                            blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enPedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ENventa.VEPedidos PedidosPendienteTrabajador(string strCodEmpresa, string strCodCliente, string strFechaDesde, string strFechaHasta, bool blnAlmacenarError)
        {
            ENventa.VEPedidos clPedido = new ENventa.VEPedidos();
            try
            {
                clPedido = ADVenta.ADPedido.PedidosPendienteTrabajador(strCodEmpresa, strCodCliente,strFechaDesde, strFechaHasta,blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return clPedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region //**************************************ITEM PEDIDO**************************************//
        public  ENventa.VEPedidoItems PedidoItemsVacio()
        {
            ENventa.VEPedidoItem enPedidoItem = new ENventa.VEPedidoItem();
            ENventa.VEPedidoItems clPedidoItem = new ENventa.VEPedidoItems();

            enPedidoItem.CodEmpresa = "";
            enPedidoItem.CodTipoDocumento = "";
            enPedidoItem.NumDocumento = "";
            enPedidoItem.CodProducto = "";
            enPedidoItem.DescProducto = "";
            enPedidoItem.SerialProducto = "";
            enPedidoItem.NumItem = "";
            enPedidoItem.CantidadPedida  = 0;
            enPedidoItem.CantidadDespachada  = 0;
            enPedidoItem.PrecioVentas = 0;
            enPedidoItem.PrecioUnitario = 0;
            enPedidoItem.PrecioUnitarioTrab = 0;
            enPedidoItem.Descuento  = 0;
            enPedidoItem.FecDespacho = Convert.ToDateTime("01/01/1900");
            enPedidoItem.FecUltimoDespacho = Convert.ToDateTime("01/01/1900");
            enPedidoItem.FecRegistro = Convert.ToDateTime("01/01/1900");
            enPedidoItem.IndReserva  = "";
            enPedidoItem.DesctoEspecial = 0;
            enPedidoItem.PesoUnidad = 0;
            enPedidoItem.Impuesto  = 0;
            enPedidoItem.TasaImpuesto = 0;
            enPedidoItem.CondPago = "";
            enPedidoItem.TasaCambio  = 0;
            enPedidoItem.CantidadReservada = 0;
            enPedidoItem.CodLinea = "";
            enPedidoItem.CodProductoTrab = "";
            enPedidoItem.MontoNeto = 0;
            enPedidoItem.CodAlmacen = "";
            enPedidoItem.CodPlanta = "";
            enPedidoItem.MontoBruto = 0;
            enPedidoItem.PesoToneladas = 0;
            enPedidoItem.ExistenciaDisponible = 0; 
            clPedidoItem.Add(enPedidoItem);
            return clPedidoItem;
        }

        public ENventa.VEPedidoItems ItemsPedidoTrabajador(string strCodEmpresa, string strCodTipoDocumento, string strNumDocumento, bool blnAlmacenarError)
        {
            ENventa.VEPedidoItems clItems = new ENventa.VEPedidoItems();
            try
            {
                clItems = ADVenta.ADPedido.ItemsPedidoTrabajador(strCodEmpresa, strCodTipoDocumento, strNumDocumento, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return clItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}

