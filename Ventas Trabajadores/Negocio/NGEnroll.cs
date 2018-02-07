using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion;
//using GrFingerXLib;
//using GriauleFingerprintLibrary;
//using GriauleFingerprintLibrary.DataTypes;
//using GriauleFingerprintLibrary.Exceptions;

namespace NGGeneral
{
    public class NGEnroll
    {

        
        private Error enError = new Error();

        public ENGeneral.ENEnroll HuellaPorTrabajador(string strCodTrabajador,bool blnAlmacenarError)
        {
            ENGeneral.ENEnroll enEnroll = new ENGeneral.ENEnroll();
            try
            {
                enEnroll = ADGeneral.ADEnroll.HuellaPorTrabajador(strCodTrabajador, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enEnroll;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}
