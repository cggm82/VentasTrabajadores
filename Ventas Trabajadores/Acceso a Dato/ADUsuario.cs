using System;
using System.Collections;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Aplicacion;
using AccesoDatoGeneral;

namespace ADGeneral
{
    public class ADUsuario
    {
        public static ENGeneral.GNUsuario Consultar(string strLogin, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENGeneral.GNUsuario enUsuario;
            try
            {
                cnnConexion = objAD.AbrirConexion();
                htParametros.Add("@Login", strLogin);
                dt = objAD.EjecutarConsulta("[dbo].GNSqlUsuario", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);

                if (dt != null && dt.Rows.Count > 0)
                {
                    enUsuario = new ENGeneral.GNUsuario();
                    enUsuario.Login = dt.Rows[0]["Login"].ToString();
                    enUsuario.Contraseña = dt.Rows[0]["Contraseña"].ToString().Trim();
                    enUsuario.Cedula = dt.Rows[0]["Cedula"].ToString().Trim();
                    enUsuario.Nom_Usuario = dt.Rows[0]["Nom Usuario"].ToString().Trim();
                    enUsuario.Cod_Empresa = dt.Rows[0]["Cod Empresa"].ToString();
                    enUsuario.Cod_Planta = dt.Rows[0]["Cod Planta"].ToString();
                    enUsuario.Cod_Grupo = dt.Rows[0]["Cod Grupo"].ToString();
                    enUsuario.Status_Cuenta = dt.Rows[0]["Status Cuenta"].ToString();
                }
                else
                    return null;
                return enUsuario;
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
