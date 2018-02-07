using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;


namespace ADGeneral
{
    public class ADEnroll
    {

        public static ENGeneral.ENEnroll HuellaPorTrabajador(string strCodTrabajador, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConex = new SqlConnection();
            SqlTransaction ObjTran = null;
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENGeneral.ENEnroll enEnroll = new ENGeneral.ENEnroll();
            try
            {
                cnnConex = objAD.AbrirConexion();
                htParametros.Add("@CodTrabajador", strCodTrabajador);
                dt = objAD.EjecutarConsulta("[dbo].SqlEnrollTrab", cnnConex, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enEnroll.ID = (int)dt.Rows[0]["ID"];
                    enEnroll.CodTrabajador = dt.Rows[0]["CodTrabajador"].ToString();
                    enEnroll.quality = (int)dt.Rows[0]["quality"];
                    enEnroll.Template = (byte[])dt.Rows[0]["template"];
                    return (enEnroll);
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
    }
}
