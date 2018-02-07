using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion; 

namespace NGGeneral
{
    public class GNEmpresa
    {
        //Utilidades
        private Error enError = new Error();

        public ENGeneral.GNEmpresas CatalogoEmpresasPorUsuario(string strLogin, bool blnAlmacenarError)
        {
            ENGeneral.GNEmpresas clEmpresaxUsuario;
            try
            {
                clEmpresaxUsuario = ADGeneral.ADEmpresa.CatalogoEmpresasPorUsuario(strLogin, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return clEmpresaxUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ENGeneral.GNEmpresa Consultar(bool blnAlmacenarError)
        {
            ENGeneral.GNEmpresa enEmpresa;
            try
            {
                enEmpresa = ADGeneral.ADEmpresa.Consultar(blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enEmpresa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
