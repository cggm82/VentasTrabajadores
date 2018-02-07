using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion;

namespace NGGeneral
{
    public class GNDeudoresAcreedores
    {
        private Error enError = new Error();

        public ENGeneral.GNDeudoresAcreedor Consultar(string strRif, bool blnAlmacenarError)
        {
            ENGeneral.GNDeudoresAcreedor enDeudorAcreedor = new ENGeneral.GNDeudoresAcreedor();
            try
            {
                enDeudorAcreedor = ADGeneral.ADDeudorAcreedor.Consultar(strRif, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enDeudorAcreedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
