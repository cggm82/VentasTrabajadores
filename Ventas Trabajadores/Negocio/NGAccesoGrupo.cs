using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion; 

namespace NGGeneral
{
    public class GNAccesoGrupo
    {
        //Utilidades
        private Error enError = new Error();

        public ENGeneral.GNAccesosGrupo OpcionesPorPantalla(string strCodEmpresa, string strCodGrupoUsuario, string strIdentificadorOpcion,
                                                            bool blnAlmacenarError)
        {
            ENGeneral.GNAccesosGrupo enAccesoGrupo = new ENGeneral.GNAccesosGrupo();
            try
            {
                enAccesoGrupo = ADGeneral.ADAccesoGrupo.OpcionesPorPantalla(strCodEmpresa, strCodGrupoUsuario, strIdentificadorOpcion, 
                                                                            blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enAccesoGrupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
