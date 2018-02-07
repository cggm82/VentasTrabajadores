using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;

namespace ADPersonal
{
    public class ADInformacionLaboral
    {
        public static ENPersonal.PEInformacionLaboral Consultar(string strCedula, string strCodEmpresa, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            ENPersonal.PEInformacionLaboral enTrabajador = new ENPersonal.PEInformacionLaboral();
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            try
            {
                cnnConexion = objAD.AbrirConexion();
                htParametros.Add("@Cedula", strCedula);
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                dt = objAD.EjecutarConsulta("[dbo].PEsqlPEInformacionLaboral", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enTrabajador.CodEmpresa = dt.Rows[0]["Cod Empresa"].ToString();
                    enTrabajador.Cedula = dt.Rows[0]["Cedula"].ToString();
                    enTrabajador.CodPlanta = dt.Rows[0]["Cod Planta"].ToString();
                    enTrabajador.CodTrabajador = dt.Rows[0]["Cod Trabajador"].ToString();
                    enTrabajador.Nombre = dt.Rows[0]["Nombre"].ToString().Trim();
                    enTrabajador.Rif = dt.Rows[0]["Rif"].ToString().Trim();
                    enTrabajador.SueldoA = (decimal)dt.Rows[0]["Sueldo A"];
                }
                else
                    return null;
                return enTrabajador;

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

        public static ENPersonal.PEInformacionLaborals TrabajadoresActivos(string strCodEmpresa, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            ENPersonal.PEInformacionLaborals clTrabajador = new ENPersonal.PEInformacionLaborals();
            ENPersonal.PEInformacionLaboral enTrabajador;
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            try
            {
                cnnConexion = objAD.AbrirConexion();
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodTrabajador", "");
                dt = objAD.EjecutarConsulta("[dbo].SqlTrabajadores", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow  dr in dt.Rows)
                    {
                        enTrabajador = new ENPersonal.PEInformacionLaboral();
                        enTrabajador.CodTrabajador = dr["Cod Trabajador"].ToString();
                        enTrabajador.Nombre = dr["Nombre"].ToString().Trim();
                        clTrabajador.Add(enTrabajador);
                    }
                }
                else
                    return null;
                return clTrabajador;

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
