using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion; 

namespace NGInventario
{
    public class NGProducto
    {
        private Error enError = new Error();

        public ENInventario.INProductos CatalogoProductosTrabajador(string strCodEmpresa, bool blnAlmacenarError)
        {
            ENInventario.INProductos clProductos = new ENInventario.INProductos();
            try
            {
                clProductos = ADInventario.ADProducto.Catalogo_ProductosTrabajador(strCodEmpresa,blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return clProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
