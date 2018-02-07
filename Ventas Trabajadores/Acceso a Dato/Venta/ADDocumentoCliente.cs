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
    public class ADDocumentoCliente
    {
        private static ENventa.VEDocumentoCliente FacturaTrabajadorMes(string strCodEmpresa, string strCodCliente, string strFechaDesde, string strFechaHasta,
                                                                       bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            SqlTransaction ObjTran = null;
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            ENventa.VEDocumentoCliente enDocumentoCli = new ENventa.VEDocumentoCliente();

            try
            {
                cnnConexion = objAD.AbrirConexion();
                ObjTran = cnnConexion.BeginTransaction();
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodCliente", strCodCliente);
                htParametros.Add("@FechaDesde", strFechaDesde);
                htParametros.Add("@FechaHasta", strFechaHasta);
                dt = objAD.EjecutarConsulta("[dbo].VeFacturaTrabajadorMes", cnnConexion, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {

                    enDocumentoCli.CodEmpresa = dt.Rows[0]["Cod Empresa"].ToString();
                    enDocumentoCli.CodPlanta = dt.Rows[0]["Cod Planta"].ToString();
                    enDocumentoCli.CodTipoDocumento = dt.Rows[0]["Cod Tipo Documento"].ToString();
                    enDocumentoCli.NumDocumento = dt.Rows[0]["Num Documento"].ToString();
                    enDocumentoCli.FecEmision = (DateTime)dt.Rows[0]["Fec Emision"];
                    enDocumentoCli.CodCliente = dt.Rows[0]["Cod Cliente"].ToString();
                    enDocumentoCli.NomCliente = dt.Rows[0]["Nom Cliente"].ToString();
                    return enDocumentoCli;
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
