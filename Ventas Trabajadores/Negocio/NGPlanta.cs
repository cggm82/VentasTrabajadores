using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion; 

namespace NGGeneral
{
    public class NGPlanta
    {
        //Utilidades
        private Error enError = new Error();

        public ENGeneral.GNPlantas CatalogoPlantasPorUsuario(string strCodUsuario, string strCodEmpresa, bool blnAlmacenarError)
        {
            ENGeneral.GNPlantas clPlantasXUsuario;
            try
            {
                clPlantasXUsuario = ADGeneral.ADPlanta.CatalogoPlantasPorUsuario(strCodUsuario, strCodEmpresa, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return clPlantasXUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
