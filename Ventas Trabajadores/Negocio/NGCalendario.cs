using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion; 

namespace NGGeneral
{
    public class NGCalendario
    {
        //Utilidades
        private Error enError = new Error();


        public ENGeneral.DimCalendario Calendario(DateTime dtFecha, bool blnAlmacenarError)
        {
            ENGeneral.DimCalendario enCalendario = new ENGeneral.DimCalendario();
            try
            {
                enCalendario = ADGeneral.ADCalendario.Calendario(dtFecha, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enCalendario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ENGeneral.DimCalendario DiaCierreAdministrativo(string strAño, string strMes, bool blnAlmacenarError)
        {
            ENGeneral.DimCalendario enCalendario = new ENGeneral.DimCalendario();
            try
            {
                enCalendario = ADGeneral.ADCalendario.DiaCierreAdministrativo(strAño, strMes, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enCalendario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
