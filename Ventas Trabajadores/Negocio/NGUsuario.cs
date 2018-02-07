using System;
using Aplicacion;
using System.Linq;
using ENGeneral;

namespace NGGeneral
{
    public class GNUsuarios
    {
        private Error enError = new Error();


        public ENGeneral.GNUsuario Consultar(string strLogin, bool blnAlmacenarError)
        {
            ENGeneral.GNUsuario enUsuarios = new ENGeneral.GNUsuario();
            try
            {
                enUsuarios = ADGeneral.ADUsuario.Consultar(strLogin, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
