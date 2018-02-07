using System;
using Aplicacion;

namespace Utilidades.Personal
{
    public class BuscarDatos
    {
        private Error enError = new Error();
        private string[] strTitulos;

        public ENPersonal.PEInformacionLaboral TrabajadoresActivos(string strCodEmpresa, bool IndAlmacenaError, ref bool blnExistenDatos)
        {
            ENPersonal.PEInformacionLaboral enTrabajador = new ENPersonal.PEInformacionLaboral();
            NGPersonal.PEInformacionLaboral ngTrabajador = new NGPersonal.PEInformacionLaboral();
            try
            {
                int[] intAnchoColumnas = { 100, 200 };
                string[] strTitulosColumnas = { "Cod Trabajador", "Nombre" };
                string[] strNombreCampo = { "Cod Trabajador", "Nombre"  };

                PRUtilidades.Formas.frmCatalogo objCatalogo;
                objCatalogo = new PRUtilidades.Formas.frmCatalogo(ngTrabajador.TrabajadoresActivos(strCodEmpresa, IndAlmacenaError));

                if (objCatalogo.ExistenDatos)
                {
                    blnExistenDatos = true;
                    using (objCatalogo)
                    {
                        objCatalogo.Text = "Trabajadores Activos";
                        objCatalogo.AnchoColumnas = intAnchoColumnas;
                        objCatalogo.TitulosColumnas = strTitulosColumnas;
                        objCatalogo.NombreCampo = strNombreCampo;

                        objCatalogo.ShowDialog();
                        if (objCatalogo.Selecciono)
                        {
                            enTrabajador = (ENPersonal.PEInformacionLaboral)objCatalogo.FilaSeleccionada;
                            return enTrabajador;
                        }
                        else
                            return null;
                    }
                }
                else
                {
                    blnExistenDatos = false;
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
