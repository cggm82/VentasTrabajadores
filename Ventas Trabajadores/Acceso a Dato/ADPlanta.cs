using System;
using System.Data;
using System.Linq;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using AccesoDatoGeneral;
using ENGeneral;

namespace ADGeneral
{
    public class ADPlanta
    {
        public static ENGeneral.GNPlantas CatalogoPlantasPorUsuario(string strCodUsuario, string strCodEmpresa, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAd = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            ENGeneral.GNPlantas clPlanta = new ENGeneral.GNPlantas();
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            try
            {
                cnnConexion = objAd.AbrirConexion();
                htParametros.Add("@Login", strCodUsuario);
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                dt = objAd.EjecutarConsulta("[dbo].GNSqlPlantaPorUsuario", cnnConexion,
                                            null, Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ENGeneral.GNPlanta enPlanta;
                    foreach (DataRow dr in dt.Rows)
                    {
                        enPlanta = new ENGeneral.GNPlanta();
                        enPlanta.CodPlanta =  dr["Cod Planta"].ToString();
                        enPlanta.NombPlanta = dr["Nom Planta"].ToString();
                        clPlanta.Add(enPlanta);
                    }
                    return clPlanta;
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
