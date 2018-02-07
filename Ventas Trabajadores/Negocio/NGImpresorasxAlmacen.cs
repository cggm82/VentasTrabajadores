using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion;


namespace NGGeneral
{
    public class GNImpresorasxAlmacen
    {
        //Utilidades
        private Error enError = new Error();

        public  ENGeneral.GNImpresorasxAlmacen Consultar(string strCodEmpresa, string strCodPlanta, string strCodAlmacen, string strCodImpresora, bool blnAlmacenarError)
        {
            ENGeneral.GNImpresorasxAlmacen enImpresora;
            try
            {
                enImpresora = ADGeneral.ADImpresorasxAlmacen.Consultar(strCodEmpresa, strCodPlanta, strCodAlmacen, strCodImpresora, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enImpresora;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
