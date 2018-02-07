using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;

namespace ADGeneral
{
    public class ADAccesoGrupo
    {

        public static ENGeneral.GNAccesosGrupo OpcionesPorPantalla(string strCodEmpresa,string strCodGrupoUsuario, string strIdentificadorOpcion,
                                                                   bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConex = new SqlConnection();
            SqlTransaction ObjTran = null;
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENGeneral.GNAccesosGrupo enAccesoGrupo = new ENGeneral.GNAccesosGrupo();
            try
            {
                cnnConex = objAD.AbrirConexion();
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodGrupo", strCodGrupoUsuario);
                htParametros.Add("@IdentificadorOpcion", strIdentificadorOpcion);
                dt = objAD.EjecutarConsulta("[dbo].GNSqlAccesoXOpcion", cnnConex, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enAccesoGrupo.CodEmpresa = dt.Rows[0]["Cod Empresa"].ToString();
                    enAccesoGrupo.CodGrupo = dt.Rows[0]["Cod Grupo"].ToString();
                    enAccesoGrupo.ModuloOrigen = dt.Rows[0]["Modulo Origen"].ToString();                   
                    enAccesoGrupo.IdentificadorOpcion = dt.Rows[0]["Identificador Opcion"].ToString();
                    enAccesoGrupo.IdentificadorAsociado = dt.Rows[0]["Identificador Asociado"].ToString();
                    enAccesoGrupo.IndAtributos = dt.Rows[0]["Ind Atributos"].ToString();
                    enAccesoGrupo.IndIncluir = (enAccesoGrupo.IndAtributos.Substring(0,1)=="I"?true:false);
                    enAccesoGrupo.IndModificar = (enAccesoGrupo.IndAtributos.Substring(1, 1) == "M" ? true : false);
                    enAccesoGrupo.IndEliminar = (enAccesoGrupo.IndAtributos.Substring(2, 1) == "E" ? true : false);
                    enAccesoGrupo.IndAutorizar = (enAccesoGrupo.IndAtributos.Substring(3, 1) == "A" ? true : false);
                    enAccesoGrupo.IndConsultar  = (enAccesoGrupo.IndAtributos.Substring(4, 1) == "C" ? true : false);
                    enAccesoGrupo.IndImprimir = true;
                    enAccesoGrupo.IndManualSistema = true;

                    return (enAccesoGrupo);
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
