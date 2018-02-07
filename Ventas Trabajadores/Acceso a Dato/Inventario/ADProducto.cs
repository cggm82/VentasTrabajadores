using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;

namespace ADInventario
{
    public class ADProducto
    {
        public static ENInventario.INProductos Catalogo_ProductosTrabajador(string strCodEmpresa, bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConexion = new SqlConnection();
            ENInventario.INProductos clProductos = new ENInventario.INProductos();
            
            Hashtable htParametros = new Hashtable();
            DataTable dt = new DataTable();
            try
            {
                cnnConexion = objAD.AbrirConexion();
                htParametros.Add("@Catalogo", true);
                htParametros.Add("@CodEmpresa", strCodEmpresa);
                htParametros.Add("@CodProductoTrab", "");
                dt = objAD.EjecutarConsulta("[dbo].INSqlProductosParaTrabajadores", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ENInventario.INProducto enProducto;
                    foreach (DataRow dr in dt.Rows)
                    {
                        enProducto = new ENInventario.INProducto();
                        enProducto.CodEmpresa = dr["Cod Empresa"].ToString();
                        enProducto.CodProducto = dr["Cod Producto"].ToString();
                        enProducto.CodProductoTrab = (int)dr["Cod Producto Trab"];
                        enProducto.DescProducto = dr["Desc Producto"].ToString();
                        enProducto.CodInventario = dr["Cod Inventario"].ToString();
                        enProducto.CodFamilia = dr["Cod Familia"].ToString();
                        enProducto.CodTipo = dr["Cod Tipo"].ToString();
                        enProducto.CodCategoria = dr["Cod Categoria"].ToString();
                        enProducto.PrecioUnitario = (decimal)dr["Precio Unitario"];
                        enProducto.PrecioUnitarioTrab = (decimal)dr["Precio Unitario Trab"];
                        enProducto.PesoUnidad = (decimal)dr["Peso Unidad"];
                        enProducto.CondProducto = dr["Cond Producto"].ToString();
                        enProducto.CodLinea = dr["Cod Linea"].ToString();
                        enProducto.ExistenciaDisponible = (decimal)dr["Existencia Disponible"];
                        enProducto.ExistenciaFisica = (decimal)dr["Existencia Fisica"];
                        enProducto.ExistenciaReservada = (decimal)dr["Existencia Reservada"];
                        enProducto.CodAlmacen = dr["Cod Almacen"].ToString();
                        enProducto.CodPlanta = dr["Cod Planta"].ToString();
                        clProductos.Add(enProducto); 
                    }
                    
                }
                else
                    return null;
                return clProductos;

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
