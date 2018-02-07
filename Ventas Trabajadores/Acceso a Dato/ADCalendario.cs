using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;

namespace ADGeneral
{
    public class ADCalendario
    {
        public static ENGeneral.DimCalendario Calendario(DateTime dtFecha, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConex = new SqlConnection();
            SqlTransaction ObjTran = null;
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENGeneral.DimCalendario enCalendario = new ENGeneral.DimCalendario();
            try
            {
                cnnConex = objAD.AbrirConexion();
                htParametros.Add("@Fecha", dtFecha);
                dt = objAD.EjecutarConsulta("[dbo].SqlCalendario", cnnConex, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enCalendario.Id = (int)dt.Rows[0]["Id"];
                    enCalendario.Fecha  = (DateTime)dt.Rows[0]["Fecha"];
                    enCalendario.Horasdetrabajo = (decimal)dt.Rows[0]["Horas de trabajo"];
                    enCalendario.Motivo = dt.Rows[0]["Motivo"].ToString();
                    enCalendario.Año = dt.Rows[0]["Año"].ToString();
                    enCalendario.Mes = dt.Rows[0]["Mes"].ToString();
                    enCalendario.NombredelMes = dt.Rows[0]["Nombre del Mes"].ToString();
                    enCalendario.DiadelaSemana = dt.Rows[0]["Dia de la Semana"].ToString();
                    enCalendario.DiadelMes = dt.Rows[0]["Dia del Mes"].ToString();
                    enCalendario.DiadelAño = dt.Rows[0]["Dia del Año"].ToString();
                    enCalendario.IndCierreMensual = (bool)dt.Rows[0]["Ind Cierre Mensual"];

                    return (enCalendario);
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


        public static ENGeneral.DimCalendario DiaCierreAdministrativo(string strAño, string strMes, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConex = new SqlConnection();
            SqlTransaction ObjTran = null;
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENGeneral.DimCalendario enCalendario = new ENGeneral.DimCalendario();
            try
            {
                cnnConex = objAD.AbrirConexion();
                htParametros.Add("@Mes", strMes);
                htParametros.Add("@Año", strAño);
                dt = objAD.EjecutarConsulta("[dbo].SqlDiaCierreAdm", cnnConex, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enCalendario.Id = (int)dt.Rows[0]["Id"];
                    enCalendario.Fecha = (DateTime)dt.Rows[0]["Fecha"];
                    enCalendario.Horasdetrabajo = (decimal)dt.Rows[0]["Horas de trabajo"];
                    enCalendario.Motivo = dt.Rows[0]["Motivo"].ToString();
                    enCalendario.Año = dt.Rows[0]["Año"].ToString();
                    enCalendario.Mes = dt.Rows[0]["Mes"].ToString();
                    enCalendario.NombredelMes = dt.Rows[0]["Nombre del Mes"].ToString();
                    enCalendario.DiadelaSemana = dt.Rows[0]["Dia de la Semana"].ToString();
                    enCalendario.DiadelMes = dt.Rows[0]["Dia del Mes"].ToString();
                    enCalendario.DiadelAño = dt.Rows[0]["Dia del Año"].ToString();
                    enCalendario.IndCierreMensual = (bool)dt.Rows[0]["Ind Cierre Mensual"];
                    return (enCalendario);
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
