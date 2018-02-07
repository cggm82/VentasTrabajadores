using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion;

namespace NGPersonal
{
    public class PEInformacionLaboral
    {
        //Utilidades
        private Error enError = new Error();

        public ENPersonal.PEInformacionLaboral Consultar(string strCedula, string strCodEmpresa, bool blnAlmacenarError)
        {
            ENPersonal.PEInformacionLaboral enTrabajador = new ENPersonal.PEInformacionLaboral();
            try
            {
                enTrabajador = ADPersonal.ADInformacionLaboral.Consultar(strCedula, strCodEmpresa, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enTrabajador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ENPersonal.PEInformacionLaborals TrabajadoresActivos(string strCodEmpresa, bool blnAlmacenarError)
        {
            ENPersonal.PEInformacionLaborals clTrabajador = new ENPersonal.PEInformacionLaborals();
            try
            {
                clTrabajador = ADPersonal.ADInformacionLaboral.TrabajadoresActivos(strCodEmpresa, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return clTrabajador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
