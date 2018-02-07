using System;
using System.Data;
using System.Collections;
using System.Linq;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using Aplicacion;

namespace Utilidades
{
    public class CargarCombo
    {
        private int[] intAnchoColumnas;
        private string[] strColumnasMostrar;
        private int intFilas;
        private Error enError = new Error();
        private Utilidades.LookUpEdit objUtilidades = new Utilidades.LookUpEdit();
        

        public void EmpresaXUsuario(DevExpress.XtraEditors.LookUpEdit cmbCombo, string  strCodUsuario, bool IndAlmacenarErrorBD)
        {
            ENGeneral.GNEmpresas clEmpresas = new ENGeneral.GNEmpresas();
            NGGeneral.GNEmpresa ngEmpresa = new NGGeneral.GNEmpresa();
            try
            {
                strColumnasMostrar = new string[] { "RazonSocial" };
                intAnchoColumnas = new int[] { 40 };

                clEmpresas = ngEmpresa.CatalogoEmpresasPorUsuario(strCodUsuario, IndAlmacenarErrorBD);
                if (clEmpresas != null)
                {
                    intFilas = clEmpresas.Count;
                    objUtilidades.LlenarConDataSource(cmbCombo, "CodEmpresa", clEmpresas, "RazonSocial", strColumnasMostrar, intAnchoColumnas, intFilas, false);
                }
                else
                    cmbCombo.Properties.DataSource = null;
            }
            catch
            {
                throw;
            }
        }

        public void PlantaXUsuario(DevExpress.XtraEditors.LookUpEdit cmbCombo, string strCodEmpresa, string strCodUsuario, bool IndAlmacenarErrorBD)
        {
            ENGeneral.GNPlantas clPlantas = new ENGeneral.GNPlantas();
            NGGeneral.NGPlanta ngPlanta = new NGGeneral.NGPlanta();
            try
            {
                intAnchoColumnas = new int[] { 40 };
                strColumnasMostrar = new string[] { "NombPlanta" };

                clPlantas = ngPlanta.CatalogoPlantasPorUsuario(strCodUsuario, strCodEmpresa, IndAlmacenarErrorBD);
                if (clPlantas != null)
                {
                    intFilas = clPlantas.Count;
                    objUtilidades.LlenarConDataSource(cmbCombo, "CodPlanta", clPlantas, "NombPlanta", strColumnasMostrar, intAnchoColumnas, intFilas, false);
                }
                else
                    cmbCombo.Properties.DataSource = null;
            }
            catch
            {
                throw;
            }
        }
    }
}
