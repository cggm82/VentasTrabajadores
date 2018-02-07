using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion;


namespace NGGeneral
{
    public class GNTiposDocumentos
    {
        private Error enError = new Error();
        private Utilidades.Funciones objFunciones = new Utilidades.Funciones();

        public ENGeneral.GNTiposDocumento ConsultarXCodigo(string strCodEmpresa, string strCodTipoDocumento, bool blnAlmacenarError)
        {
            ENGeneral.GNTiposDocumento enTipoDocumento = new ENGeneral.GNTiposDocumento();
            try
            {
                enTipoDocumento = ADGeneral.ADTipoDocumento.Consultar(strCodTipoDocumento,strCodEmpresa, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                return enTipoDocumento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Correlativo(string strCodEmpresa, string strCodTipoDocumento, bool blnAlmacenarError)
        {
            ENGeneral.GNTiposDocumento enTipoDocumento = new ENGeneral.GNTiposDocumento();
            string strNumDocumento = "";
            try
            {
                enTipoDocumento = ADGeneral.ADTipoDocumento.Consultar(strCodTipoDocumento, strCodEmpresa, blnAlmacenarError, ref enError);
                if (enError.MensajeError.Trim().Length > 0)
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
                if (enTipoDocumento != null)
                {
                    strNumDocumento = (enTipoDocumento.Correlativo + 1).ToString().Trim();
                    strNumDocumento = objFunciones.AddCerosIzq(strNumDocumento, 8 - strNumDocumento.Length);
                }
                return strNumDocumento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
