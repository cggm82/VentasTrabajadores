using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;

namespace ADGeneral
{
    public class ADOpcionSistema
    {
        public static ENGeneral.GNOpcionesSistemas Catalogo(bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            SqlTransaction ObjTran = null;
            Hashtable htParametros = new Hashtable();
            ENGeneral.GNOpcionesSistemas clOpcionSistema = new ENGeneral.GNOpcionesSistemas();
            DataTable dt = new DataTable();
            try
            {
                cnnConexion = objAD.AbrirConexion();
                htParametros.Add("@Catalogo", true);
                htParametros.Add("@CodOpcion", 0);


                dt = objAD.EjecutarConsulta("[GN].SqlOpcionSistema", cnnConexion, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);

                if (dt != null && dt.Rows.Count > 0)
                {
                    ENGeneral.GNOpcionesSistema enOpcionSistema;

                    foreach (DataRow dr in dt.Rows)
                    {
                        enOpcionSistema = new ENGeneral.GNOpcionesSistema();
                        enOpcionSistema.DescripcionOpcion = dr["Descripcion Opcion"].ToString();
                        enOpcionSistema.IdentificadorOpcion = dr["Identificador Opcion"].ToString();
                        enOpcionSistema.IdentificadorAsociado = dr["Identificador Asociado"].ToString();
                        enOpcionSistema.TipoOpcion = dr["Tipo Opcion"].ToString();
                        enOpcionSistema.ModuloOrigen = dr["Modulo Origen"].ToString();
                        enOpcionSistema.PosicionOpcion = dr["Posicion Opcion"].ToString();
                        enOpcionSistema.Condicion = dr["Condicion"].ToString();
                        enOpcionSistema.AtributosOpcion = dr["Atributos Opcion"].ToString();
                        enOpcionSistema.IndIncluir = (enOpcionSistema.AtributosOpcion.Substring(0,1)=="I"?true:false);
                        enOpcionSistema.IndModificar = (enOpcionSistema.AtributosOpcion.Substring(1, 1) == "M" ? true : false);
                        enOpcionSistema.IndEliminar = (enOpcionSistema.AtributosOpcion.Substring(2, 1) == "E" ? true : false);
                        enOpcionSistema.IndAutorizar = (enOpcionSistema.AtributosOpcion.Substring(3, 1) == "A" ? true : false);
                        enOpcionSistema.IndConsultar = (enOpcionSistema.AtributosOpcion.Substring(4, 1) == "C" ? true : false);
                        enOpcionSistema.IndImprimir = true;
                        enOpcionSistema.IndManualSistema = true;
                        clOpcionSistema.Add(enOpcionSistema);
                    }
                    return (clOpcionSistema);
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

        public static ENGeneral.GNOpcionesSistema Consultar(string strIdentificadorOpcion, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENGeneral.GNOpcionesSistema enOpcionSistema;

            try
            {
                cnnConexion = objAD.AbrirConexion();

                htParametros.Add("@Catalogo", false);
                htParametros.Add("@IdentificadorOpcion", strIdentificadorOpcion);
                //Falta Crear el SP
                dt = objAD.EjecutarConsulta("[GN].SqlOpcionSistema", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enOpcionSistema = new ENGeneral.GNOpcionesSistema();
                    enOpcionSistema.DescripcionOpcion = dt.Rows[0]["Descripcion Opcion"].ToString();
                    enOpcionSistema.IdentificadorOpcion = dt.Rows[0]["Identificador Opcion"].ToString();
                    enOpcionSistema.IdentificadorAsociado = dt.Rows[0]["Identificador Asociado"].ToString();
                    enOpcionSistema.TipoOpcion = dt.Rows[0]["Tipo Opcion"].ToString();
                    enOpcionSistema.ModuloOrigen = dt.Rows[0]["Modulo Origen"].ToString();
                    enOpcionSistema.PosicionOpcion = dt.Rows[0]["Posicion Opcion"].ToString();
                    enOpcionSistema.Condicion = dt.Rows[0]["Condicion"].ToString();
                    enOpcionSistema.AtributosOpcion = dt.Rows[0]["Atributos Opcion"].ToString();
                    enOpcionSistema.IndIncluir = (enOpcionSistema.AtributosOpcion.Substring(0, 1) == "I" ? true : false);
                    enOpcionSistema.IndModificar = (enOpcionSistema.AtributosOpcion.Substring(1, 1) == "M" ? true : false);
                    enOpcionSistema.IndEliminar = (enOpcionSistema.AtributosOpcion.Substring(2, 1) == "E" ? true : false);
                    enOpcionSistema.IndAutorizar = (enOpcionSistema.AtributosOpcion.Substring(3, 1) == "A" ? true : false);
                    enOpcionSistema.IndConsultar = (enOpcionSistema.AtributosOpcion.Substring(4, 1) == "C" ? true : false);
                    enOpcionSistema.IndImprimir = true;
                    enOpcionSistema.IndManualSistema = true;
                }
                else
                    return null;
                return enOpcionSistema;
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
