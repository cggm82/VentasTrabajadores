using System;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using ENGeneral;


namespace Utilidades
{
    public class Ribbon
    /*Obj:Manejar todo lo referente al menu de la aplicación*/
    {
        public void ActivarBotonesCargar(RibbonControl objBarra, ENGeneral.GNAccesosGrupo enAccesoGrupo)
        {
            ActivarBotones(objBarra, 3, enAccesoGrupo);
        }

        public void ActivarBotonesNuevo(RibbonControl objBarra, ENGeneral.GNAccesosGrupo enAccesoGrupo)
        {
            ActivarBotones(objBarra, 1, enAccesoGrupo);
        }

        public void ActivarBotonesBuscar(RibbonControl objBarra, ENGeneral.GNAccesosGrupo enAccesoGrupo)
        {
            ActivarBotones(objBarra, 2, enAccesoGrupo);
        }

        public void ApagarBotones(RibbonControl objBarra)
        {
            ActivarBotones(objBarra, 0, null);
        }

        public void ActivarBotonesItem(RibbonControl objBarra, ENGeneral.GNAccesosGrupo enAccesoGrupo)
        {
            ActivarBotones(objBarra, 4, enAccesoGrupo);
        }

        public void ActivarBotonExportar(RibbonControl objBarra, ENGeneral.GNAccesosGrupo enAccesoGrupo)
        {
            ActivarBotones(objBarra, 5, enAccesoGrupo);
        }

        public void ActivarBotonAyuda(RibbonControl objBarra, ENGeneral.GNAccesosGrupo enAccesoGrupo)
        {
            ActivarBotones(objBarra, 7, enAccesoGrupo);
        }

        private void ActivarBotones(RibbonControl objBarra, short nAccion, ENGeneral.GNAccesosGrupo enAccesoGrupo)
        {
            try
            {
                foreach (BarItem nItem in objBarra.Items)
                {
                    if (nItem.Name.ToString().Length != 0)
                    {
                        if (nItem.Name.Substring(0, 3) != "mnu")
                            nItem.Enabled = false;

                        if (nItem.Name == "SkinGallery")
                            nItem.Enabled = true;
                    }
                }

                switch (nAccion)
                {
                    case 1: /*Nuevo y Editar*/
                        objBarra.Items["btnCancelar"].Enabled = true;
                        objBarra.Items["btnSalir"].Enabled = true;
                        objBarra.Items["btnAyuda"].Enabled = (enAccesoGrupo.IndManualSistema == true ? true : false);
                        objBarra.Items["btnGrabar"].Enabled = (enAccesoGrupo.IndIncluir == false && enAccesoGrupo.IndModificar == false ? false : true);

                        break;
                    case 2: /*Buscar*/
                        objBarra.Items["btnEditar"].Enabled = (enAccesoGrupo.IndModificar == true ? true : false);
                        objBarra.Items["btnEliminar"].Enabled = (enAccesoGrupo.IndEliminar == true ? true : false);
                        objBarra.Items["btnImprimir"].Enabled = (enAccesoGrupo.IndImprimir == true ? true : false);
                        objBarra.Items["btnCancelar"].Enabled = true;
                        objBarra.Items["btnSalir"].Enabled = true;
                        break;
                    case 3: /*Cargar y Cancelar*/
                        objBarra.Items["btnSalir"].Enabled = true;
                        objBarra.Items["btnNuevo"].Enabled = (enAccesoGrupo.IndIncluir == true ? true : false);
                        objBarra.Items["btnBuscar"].Enabled = (enAccesoGrupo.IndConsultar == true ? true : false);
                        objBarra.Items["btnImprimir"].Enabled = false;
                        objBarra.Items["btnCancelar"].Enabled = true;
                        objBarra.Items["btnAyuda"].Enabled = (enAccesoGrupo.IndManualSistema == true ? true : false);

                        break;
                    case 4:  //Items                       
                        objBarra.Items["btnGrabar"].Enabled = (enAccesoGrupo.IndIncluir == true ? true : false);
                        objBarra.Items["btnCancelar"].Enabled = true;
                        break;
                    case 5: //Exportar
                        objBarra.Items["btnGrabar"].Enabled = (enAccesoGrupo.IndIncluir == true ? true : false);
                        objBarra.Items["btnCancelar"].Enabled = true;
                        objBarra.Items["btnSalir"].Enabled = true;
                        break;
                    case 6:
                        objBarra.Items["btnSalir"].Enabled = true;
                        break;
                    case 7:
                        objBarra.Items["btnAyuda"].Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void HabilitarOpcionMenu(RibbonControl objBarra, string strNombreOpcion, bool blnAccion)
        {
            try
            {
                foreach (BarItem nItem in objBarra.Items)
                {
                    if (nItem.Name == strNombreOpcion)
                    {
                        nItem.Enabled = blnAccion;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
