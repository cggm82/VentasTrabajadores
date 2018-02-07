using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime; 
using System.IO;
using System.Linq;
using System.Text;
using Aplicacion;


namespace Utilidades
{
    public class Procedimientos
    {
        #region Impresion
        public void ImprimirTicketPedido(string strNombCompletoImp, string strRutaArchivoImp,
                                        string strNumeroPedido, string  strCodCli, string strNombCliente, 
                                        ENventa.VEPedidoItems clPedidoItem, ref bool blnTerminado)
        {
            Ticket objTicket = new Ticket();
            string strFecha = DateTime.Now.Date.ToShortDateString();
            string strHora = DateTime.Now.Hour.ToString() + ":" +
                            (DateTime.Now.Minute.ToString().Length < 2 ? "0" + DateTime.Now.Minute.ToString() :
                             DateTime.Now.Minute.ToString());
            string[] strLineaEncabezado = { "Codigo", "Producto", "Cant." };
            string[] strLineaFecha = { "Fecha: " + strFecha, "Hora: " + strHora };
            int intCuantos = 0, intPosInicio = 0;
            string strNombProducto = "";
            try
            {
                blnTerminado = false;
                using (StreamWriter sw = new StreamWriter(strRutaArchivoImp))
                {
                    sw.WriteLine(objTicket.TextoCentro("PEDIDO DE VENTA", Constantes.CaracteresEpsonTMU));
                    sw.WriteLine(objTicket.LineasGuion(Constantes.CaracteresEpsonTMU));
                    sw.WriteLine(objTicket.TextoIzquierda("Pedido Nro: " + strNumeroPedido, Constantes.CaracteresEpsonTMU));
                    sw.WriteLine(objTicket.TextoDistribuido(strLineaFecha, strLineaFecha.Length, Constantes.CaracteresEpsonTMU));
                    sw.WriteLine(objTicket.TextoIzquierda("Cliente: " + strCodCli + "-" + strNombCliente, Constantes.CaracteresEpsonTMU));
                    sw.WriteLine(" ");
                    sw.WriteLine(objTicket.TextoDistribuido(strLineaEncabezado, strLineaEncabezado.Length, Constantes.CaracteresEpsonTMU));
                    sw.WriteLine(objTicket.LineasGuion(Constantes.CaracteresEpsonTMU));

                    foreach (ENventa.VEPedidoItem enPedidoItem in clPedidoItem)
                    {
                        intPosInicio = Constantes.CaracteresEpsonTMU - (enPedidoItem.CodProducto.ToString().Length +
                                                                        enPedidoItem.CantidadPedida.ToString().Length + 2);
                        if (enPedidoItem.DescProducto.Trim().Length > intPosInicio)
                        {
                            intCuantos = enPedidoItem.DescProducto.Trim().Length - intPosInicio;
                            strNombProducto = enPedidoItem.DescProducto.Trim().Remove(intPosInicio, intCuantos);
                        }
                        else strNombProducto = enPedidoItem.DescProducto.Trim();

                        string[] strLineaItem = {enPedidoItem.CodProductoTrab.ToString(),
                                                strNombProducto,
                                                enPedidoItem.CantidadPedida.ToString()};
                        sw.WriteLine(objTicket.TextoDistribuido(strLineaItem, strLineaItem.Length, Constantes.CaracteresEpsonTMU));
                    }
                    sw.WriteLine(" ");
                    sw.WriteLine(objTicket.TextoIzquierda("Total Items: " + clPedidoItem.Count.ToString(), Constantes.CaracteresEpsonTMU));
                    sw.WriteLine(" ");
                    sw.WriteLine(objTicket.TextoCentro("La vigencia del pedido es de 1 semana",Constantes.CaracteresEpsonTMU));
                    sw.WriteLine(" ");
                    sw.WriteLine(" ");
                    sw.WriteLine(" ");
                    sw.WriteLine(" ");
                    sw.WriteLine(" ");
                    sw.WriteLine(" ");
                    sw.WriteLine(" ");
                    sw.Close();
                }
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                pd.PrinterSettings.PrinterName = strNombCompletoImp;
                pd.PrinterSettings.PrintFileName = strRutaArchivoImp;
                RawPrinterHelper.SendFileToPrinter(strNombCompletoImp, strRutaArchivoImp);
                blnTerminado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
