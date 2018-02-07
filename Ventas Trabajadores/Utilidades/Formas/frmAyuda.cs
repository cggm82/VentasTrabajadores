using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Aplicacion;
using AxWMPLib;

namespace PRUtilidades.Formas
{
    public partial class frmAyuda : DevExpress.XtraEditors.XtraForm
    {
        //Utilidades
        private Aplicacion.Error enError = new Aplicacion.Error();

        //Entidades y Negocio
        //private ENGeneral.DocumentacionSistema enDocSistema = new ENGeneral.DocumentacionSistema();
        //private NGGeneral.DocumentacionSistema ngDocSistema = new NGGeneral.DocumentacionSistema();

        public frmAyuda()
        {
            InitializeComponent();
            //enDocSistema = ngDocSistema.Consultar(intCodOpcion, true);
            //txtCodOpcion.Text = intCodOpcion.ToString();
            xtpVideo.PageVisible = true;
            
            
            //xtpManualSistema.PageVisible = blnManualSistema;
            //xtpManualProcedimiento.PageVisible = blnManualProc;
        }


        private void frmAyuda_Load(object sender, EventArgs e)
        {
            try
            {
                    //txtNombOpcion.Text = enDocSistema.NombOpcion.Trim();
                                  
                    
                    //wbManualSistema.Navigate(enDocSistema.RutaManualSistema);
                    //wbManualProcedimiento.Navigate(enDocSistema.RutaManualProcedimiento);
                    //dateEdFecMovimiento.Text = enDocSistema.FecMovimiento.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}