using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Aplicacion;
using ENGeneral;
using AccesoDatoGeneral;

namespace ADGeneral
{
    public class ADDeudorAcreedor
    {
        public static ENGeneral.GNDeudoresAcreedor Consultar(string strRif,bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            AccesoDato objAD = new AccesoDato();
            SqlConnection cnnConex = new SqlConnection();
            SqlTransaction ObjTran = null;
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            ENGeneral.GNDeudoresAcreedor enDeudorAcreedor = new ENGeneral.GNDeudoresAcreedor();
            try
            {
                cnnConex = objAD.AbrirConexion();
                htParametros.Add("@Rif", strRif);                
                dt = objAD.EjecutarConsulta("[dbo].GNSqlDeudorAcreedor", cnnConex, ObjTran,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                if (dt != null && dt.Rows.Count > 0)
                {
                    enDeudorAcreedor.CliProveedor = dt.Rows[0]["Cli Proveedor"].ToString();
                    enDeudorAcreedor.NomCliProveedor = dt.Rows[0]["Nom Cli Proveedor"].ToString();
                    enDeudorAcreedor.Dir1 = dt.Rows[0]["Dir 1"].ToString();
                    enDeudorAcreedor.Dir2 = dt.Rows[0]["Dir 2"].ToString();
                    enDeudorAcreedor.Dir3 = dt.Rows[0]["Dir 3"].ToString();
                    enDeudorAcreedor.Rif = dt.Rows[0]["Rif"].ToString();
                    enDeudorAcreedor.CondPagoAcreedor = dt.Rows[0]["Cond Pago Acreedor"].ToString();
                    enDeudorAcreedor.CondPagoDeudor = dt.Rows[0]["Cond Pago Deudor"].ToString();
                    enDeudorAcreedor.CodCiudad = dt.Rows[0]["Cod Ciudad"].ToString();
                    enDeudorAcreedor.CodZonaVenta = dt.Rows[0]["Cod Zona Venta"].ToString();
                    enDeudorAcreedor.CodZonaDespacho = dt.Rows[0]["Cod Zona Despacho"].ToString();
                    enDeudorAcreedor.CodGrupoCliente = dt.Rows[0]["Cod Grupo Cliente"].ToString();
                    enDeudorAcreedor.CodPais = dt.Rows[0]["Cod Pais"].ToString();
                    enDeudorAcreedor.CodZonaVentaNuevo = dt.Rows[0]["Cod Zona Venta Nuevo"].ToString();
                    enDeudorAcreedor.CodZonaDespachoNuevo = dt.Rows[0]["Cod Zona Despacho Nuevo"].ToString();
                    return (enDeudorAcreedor);
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
