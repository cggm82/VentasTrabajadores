using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion; 


namespace NGGeneral
{
    public class GNOpcionesSistema
    {
        private Error enError = new Error();

        public ENGeneral.GNOpcionesSistemas  CatalogoOpcionSistema(bool blnAlmacenarError)
        {
            ENGeneral.GNOpcionesSistemas clOpcionesSist = new ENGeneral.GNOpcionesSistemas();
            try
            {
                clOpcionesSist = ADGeneral.ADOpcionSistema.Catalogo(blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return clOpcionesSist;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ENGeneral.GNOpcionesSistema ConsultarOpcionSistema(string strIdentificadorOpcion, bool blnAlmacenarError)
        {
            ENGeneral.GNOpcionesSistema enOpcionesSist = new ENGeneral.GNOpcionesSistema();
            try
            {
                enOpcionesSist = ADGeneral.ADOpcionSistema.Consultar(strIdentificadorOpcion, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enOpcionesSist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
