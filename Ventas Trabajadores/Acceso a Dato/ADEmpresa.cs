using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;

namespace ADGeneral
{
    public class ADEmpresa
    {
        public static ENGeneral.GNEmpresas CatalogoEmpresasPorUsuario(string strCodUsuario, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            ENGeneral.GNEmpresas clEmpresa = new ENGeneral.GNEmpresas();
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            try
            {
                cnnConexion = objAD.AbrirConexion();
                htParametros.Add("@Login", strCodUsuario);
                dt = objAD.EjecutarConsulta("[dbo].GNSqlEmpresaPorUsuario", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ENGeneral.GNEmpresa enEmpresa;
                    foreach (DataRow dr in dt.Rows)
                    {
                        enEmpresa = new ENGeneral.GNEmpresa();
                        enEmpresa.CodEmpresa = dr["Cod Empresa"].ToString();
                        enEmpresa.RazonSocial = dr["Razon Social"].ToString().Trim();
                        clEmpresa.Add(enEmpresa);
                    }
                    objAD.CerrarConexion(cnnConexion);
                    return (clEmpresa);
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
                if (cnnConexion.State == ConnectionState.Open)
                    cnnConexion.Close();
            }
        }

        public static ENGeneral.GNEmpresa Consultar(bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            ENGeneral.GNEmpresa enEmpresa = new ENGeneral.GNEmpresa();
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            try
            {
                cnnConexion = objAD.AbrirConexion();
                dt = objAD.EjecutarConsulta("[dbo].GNConsultarEmpresa", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enEmpresa.CodEmpresa = dt.Rows[0]["Cod Empresa"].ToString();
                    enEmpresa.RazonSocial = dt.Rows[0]["Razon Social"].ToString().Trim();
                    enEmpresa.CantLaminas = (int)dt.Rows[0]["Cant Laminas"];
                    enEmpresa.TasaImpuesto = (decimal)dt.Rows[0]["Tasa Impuesto"];
                    enEmpresa.FechaTopeMov = (DateTime)dt.Rows[0]["Fecha Tope Movimiento"];
                    enEmpresa.IndValDiasPedido = Convert.ToChar(dt.Rows[0]["Ind Val Dias Pedido"]);
                    enEmpresa.IndValPedidoCierre = Convert.ToChar(dt.Rows[0]["Ind Val Pedido Cierre"]);
                    enEmpresa.IndValHoraPedido = dt.Rows[0]["Val Hora Pedido"].ToString();
                    enEmpresa.DescTasaImpTransfA = (decimal)dt.Rows[0]["Desc Tasa Impuesto Trans A"];
                    enEmpresa.DescTasaImpTransfB = (decimal)dt.Rows[0]["Desc Tasa Impuesto Trans B"];
                    enEmpresa.IndTopeDescImpuestoTransf = (decimal)dt.Rows[0]["Ind Tope Descuento Imp Trans"];
                    enEmpresa.FechaFinDescTopeTransf = (DateTime)dt.Rows[0]["Ind Fecha Fin Desc Imp Trans"];
                    objAD.CerrarConexion(cnnConexion);
                    return (enEmpresa);
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
                if (cnnConexion.State == ConnectionState.Open)
                    cnnConexion.Close();
            }
        }
    }
}
