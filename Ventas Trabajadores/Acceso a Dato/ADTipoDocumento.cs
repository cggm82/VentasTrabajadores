using System;
using System.Collections;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Aplicacion;
using AccesoDatoGeneral;


namespace ADGeneral
{
    public class ADTipoDocumento
    {
        public static ENGeneral.GNTiposDocumento Consultar(string strCodTipoDocumento, string strCodEmpresa, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENGeneral.GNTiposDocumento enTipoDocumento;
            try
            {
                cnnConexion = objAD.AbrirConexion();
                htParametros.Add("@CodTipoDocumento", strCodTipoDocumento);
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                dt = objAD.EjecutarConsulta("[dbo].GNSqlTipoDocumentos", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);

                if (dt != null && dt.Rows.Count > 0)
                {
                    enTipoDocumento = new ENGeneral.GNTiposDocumento();
                    enTipoDocumento.CodEmpresa = dt.Rows[0]["Cod Empresa"].ToString();
                    enTipoDocumento.CodTipoDocumento = dt.Rows[0]["Cod Tipo Documento"].ToString().Trim();
                    enTipoDocumento.NomTipoDocumento = dt.Rows[0]["Nom Tipo Documento"].ToString().Trim();
                    enTipoDocumento.NomAbreviado = dt.Rows[0]["Nom Abreviado"].ToString().Trim();
                    enTipoDocumento.ModuloActivo = dt.Rows[0]["Modulo Activo"].ToString();
                    enTipoDocumento.Naturaleza = dt.Rows[0]["Naturaleza"].ToString();
                    enTipoDocumento.Correlativo = (decimal)dt.Rows[0]["Correlativo"];
                    enTipoDocumento.Visible = dt.Rows[0]["Visible"].ToString();
                    enTipoDocumento.NomTablaDocAsociado = dt.Rows[0]["Nom Tabla DocAsociado"].ToString();
                    enTipoDocumento.IndAplicaITF = dt.Rows[0]["Ind Aplica ITF"].ToString();
                }
                else
                    return null;
                return enTipoDocumento;
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

        public static bool ActualizarCorrelativo(string strCodEmpresa, string strCodTipoDocumento, string strCodModulo, decimal decCorrelativo, 
                                                 SqlConnection cnnConexion, SqlTransaction ObjTran,
                                                 bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            Hashtable htParametros = new Hashtable();
            try
            {               
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodTipoDocumento", strCodTipoDocumento);
                htParametros.Add("@ModuloActivo", strCodModulo);
                htParametros.Add("@Correlativo", Convert.ToInt32(decCorrelativo));

                if (objAD.EjecutarProcedimiento("[dbo].GNUpdateTipoDocumento", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                 htParametros, blnAlmacenarError, ref enError) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
