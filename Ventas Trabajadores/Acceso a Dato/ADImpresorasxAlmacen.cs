using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;

namespace ADGeneral
{
    public class ADImpresorasxAlmacen
    {
        public static ENGeneral.GNImpresorasxAlmacen Consultar(string strCodEmpresa, string strCodPlanta, string strCodAlmacen, string strCodImpresora, 
                                                               bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            ENGeneral.GNImpresorasxAlmacen enImpresora = new ENGeneral.GNImpresorasxAlmacen();
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            try
            {
                cnnConexion = objAD.AbrirConexion();
                htParametros.Add ("@CodEmpresa",strCodEmpresa);
                htParametros.Add("@CodPlanta", strCodPlanta);
                htParametros.Add("@CodAlmacen", strCodAlmacen);
                htParametros.Add("@CodImpresora", strCodImpresora);

                dt = objAD.EjecutarConsulta("[dbo].GNSqlImpresoraxAlmacen", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enImpresora.CodEmpresa = dt.Rows[0]["Cod Empresa"].ToString();
                    enImpresora.CodPlanta = dt.Rows[0]["Cod Planta"].ToString().Trim();
                    enImpresora.CodAlmacen  = dt.Rows[0]["Cod Almacen"].ToString().Trim();
                    enImpresora.CodImpresora = dt.Rows[0]["Cod Impresora"].ToString().Trim();
                    enImpresora.NomImpresora = dt.Rows[0]["Nom Impresora"].ToString().Trim();
                    enImpresora.NomEquipo = dt.Rows[0]["Nom Equipo"].ToString().Trim();
                    enImpresora.CondImpresora = dt.Rows[0]["Cond Impresora"].ToString().Trim();
                    objAD.CerrarConexion(cnnConexion);
                    return (enImpresora);
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
