using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;

namespace ADInventario
{
    public class ADExistenciaProducto
    {
        public static ENInventario.INExistenciasProducto Consultar(string strCodEmpresa, string strCodPlanta, string strCodAlmacen, 
                                                                   string strCodProducto, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            ENInventario.INExistenciasProducto enExistenciaProducto = new ENInventario.INExistenciasProducto();
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            try
            {
                cnnConexion = objAD.AbrirConexion();
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodPlanta", strCodPlanta);
                htParametros.Add("@CodAlmacen", strCodAlmacen);
                htParametros.Add("@CodProducto", strCodProducto);

                dt = objAD.EjecutarConsulta("[dbo].INSqlExistenciaProducto", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enExistenciaProducto.CodEmpresa = dt.Rows[0]["Cod Empresa"].ToString();
                    enExistenciaProducto.CodPlanta = dt.Rows[0]["Cod Planta"].ToString();
                    enExistenciaProducto.CodAlmacen = dt.Rows[0]["Cod Almacen"].ToString();
                    enExistenciaProducto.CodProducto = dt.Rows[0]["Cod Producto"].ToString();
                    enExistenciaProducto.DescProducto= dt.Rows[0]["Desc Producto"].ToString().Trim();
                    enExistenciaProducto.ExistenciaDisponible = (decimal)dt.Rows[0]["Existencia Disponible"];
                    enExistenciaProducto.ExistenciaFisica = (decimal)dt.Rows[0]["Existencia Fisica"];
                    enExistenciaProducto.ExistenciaReservada = (decimal)dt.Rows[0]["Existencia Disponible"];
                }
                else
                    return null;
                return enExistenciaProducto;

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

        public static bool ReservarExistencia(string strCodEmpresa, string strCodPlanta, string strCodAlmacen,
                                              string strCodProducto, decimal decExistencia, string strTipoOperacion,
                                              SqlConnection cnnConexion, SqlTransaction ObjTran,
                                              bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            ENInventario.INExistenciasProducto enExistenciaProducto = new ENInventario.INExistenciasProducto();
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            bool blnValor = false;
            try
            {
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodPlanta", strCodPlanta);
                htParametros.Add("@CodAlmacen", strCodAlmacen);
                htParametros.Add("@CodProducto", strCodProducto);
                htParametros.Add("@ExistenciaReservada", decExistencia);
                htParametros.Add("@TipoOperacion", strTipoOperacion);

                if (objAD.EjecutarProcedimiento("[dbo].INReservarExistenciaProd", cnnConexion, ObjTran, Enumerado.TipoComando.SP,
                                                htParametros, blnAlmacenarError, ref enError) > 0)
                    blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                else
                    blnValor = false;
                return blnValor;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
