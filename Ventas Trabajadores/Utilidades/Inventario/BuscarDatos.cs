using System;
using Aplicacion;

namespace Utilidades.Inventario
{
    public class BuscarDatos
    {
        private Error enError = new Error();
        private string[] strTitulos;
        //private string[] strNombre;

        public ENInventario.INProducto ProductoParaTrabajadores(string strCodEmpresa,  bool IndAlmacenaError, ref bool blnExistenDatos)
        {
            ENInventario.INProducto enProducto = new ENInventario.INProducto();
            NGInventario.NGProducto ngProducto = new NGInventario.NGProducto();
            try
            {
                int[] intAnchoColumnas = { 150, 50, 300 };
                string[] strTitulosColumnas = { "Cod Producto", "Desc Producto", "Existencia Disponible" };
                string[] strNombreCampo = { "CodProductoTrab", "DescProducto", "ExistenciaDisponible" };

                PRUtilidades.Formas.frmCatalogo objCatalogo;
                objCatalogo = new PRUtilidades.Formas.frmCatalogo(ngProducto.CatalogoProductosTrabajador(strCodEmpresa, IndAlmacenaError));

                if (objCatalogo.ExistenDatos)
                {
                    blnExistenDatos = true;
                    using (objCatalogo)
                    {
                        objCatalogo.Text = "Productos";
                        objCatalogo.AnchoColumnas = intAnchoColumnas;
                        objCatalogo.TitulosColumnas = strTitulosColumnas;
                        objCatalogo.NombreCampo = strNombreCampo;

                        objCatalogo.ShowDialog();
                        if (objCatalogo.Selecciono)
                        {
                            enProducto = (ENInventario.INProducto)objCatalogo.FilaSeleccionada;
                            return enProducto;
                        }
                        else
                            return null;
                    }
                }
                else
                {
                    blnExistenDatos = false;
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
