using System;
using Aplicacion;

namespace Utilidades.Ventas
{
    public class BuscarDatos
    {
        private Error enError = new Error();
        private string[] strTitulos;

        public ENventa.VEPedido PedidosTrabajador(string strCodEmpresa, string strCodCliente, string strFechaDesde, string strFechaHasta, bool IndAlmacenaError, ref bool blnExistenDatos)
        {
            ENventa.VEPedido enProducto = new ENventa.VEPedido();
            NGVenta.NGPedido ngPedido = new NGVenta.NGPedido();
            try
            {
                int[] intAnchoColumnas = { 50, 500, 300, 300 };
                string[] strTitulosColumnas = { "Cod Cliente", "Nombre", "Num Pedido", "Fecha Registro" };
                string[] strNombreCampo = { "CodCliente", "NomCliente", "NumDocumento", "FecRegistro" };

                PRUtilidades.Formas.frmCatalogo objCatalogo;
                objCatalogo = new PRUtilidades.Formas.frmCatalogo(ngPedido.PedidosPendienteTrabajador(strCodEmpresa, strCodCliente,strFechaDesde, strFechaHasta,IndAlmacenaError));

                if (objCatalogo.ExistenDatos)
                {
                    blnExistenDatos = true;
                    using (objCatalogo)
                    {
                        objCatalogo.Text = "Pedidos Pendientes por facturar";
                        objCatalogo.AnchoColumnas = intAnchoColumnas;
                        objCatalogo.TitulosColumnas = strTitulosColumnas;
                        objCatalogo.NombreCampo = strNombreCampo;

                        objCatalogo.ShowDialog();
                        if (objCatalogo.Selecciono)
                        {
                            enProducto = (ENventa.VEPedido)objCatalogo.FilaSeleccionada;
                            return enProducto;
                        }
                        else
                            return null;
                    }
                }
                else
                {
                    blnExistenDatos = false;
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
