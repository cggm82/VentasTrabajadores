using System;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using Aplicacion;
using DevExpress.XtraEditors;

namespace Ventas_Trabajadores
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        //Variables Globales al Formulario
        public Utilidades.FormatoPropio objFormato = new Utilidades.FormatoPropio();

        private short mintIntentos = 0;
        private string mstrNomModulo = "Principal";
        private Aplicacion.Error enError = new Aplicacion.Error();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            NGGeneral.Entorno ngEntorno = new NGGeneral.Entorno();
            Utilidades.Funciones objUtFunciones = new Utilidades.Funciones();
            string strClaveEncrip = "";
            try
            {
                enError.LimpiarError();
                //Validar Campos
                if (txtCodUsuario.Text.Length <= 0)
                {
                    MessageBox.Show("Tipee el código de usuario", mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodUsuario.Focus();
                    return;
                }

                if (cmbEmpresa.Text == null || cmbEmpresa.Text == "")
                {
                    MessageBox.Show("Seleccione la Empresa", mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbEmpresa.Focus();
                    return;
                }

                if (cmbSucursal.Text == null || cmbSucursal.Text == "")
                {
                    MessageBox.Show("Seleccione la Sucursal", mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSucursal.Focus();
                    return;
                }

                if (mintIntentos == 2)
                {
                    MessageBox.Show("Acceso Denegado, Violacion de Seguridad", mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.btnCancelar_Click(this, e);
                    return;
                }

                

                //Grabar variables de entorno 
                strClaveEncrip = objUtFunciones.Encriptar(txtContraseña.Text, "E", false);
                if (ngEntorno.GrabarEntorno(txtCodUsuario.Text.ToString(), strClaveEncrip,
                                            cmbEmpresa.GetColumnValue("CodEmpresa").ToString(),
                                            cmbEmpresa.Text, cmbSucursal.GetColumnValue("CodPlanta").ToString(),
                                            true, ref enError) == false)
                {
                    if (enError.MensajeError.Trim().Length > 0)
                    {
                        if (enError.TipoError == Convert.ToInt32(Enumerado.TipoError.Validacion))
                        {
                            MessageBox.Show(enError.MensajeError, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mintIntentos = 0;
                        }
                        else
                        {
                            MessageBox.Show(mstrNomModulo + enError.MensajeError, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    mintIntentos++;
                    this.Hide();
                    frmMenuPrincipal objForma = new frmMenuPrincipal();
                    objForma.Show();
                    //this.btnCancelar_Click(this, e);
                }
                else
                {
                    //CultureInfo actual = System.Threading.Thread.CurrentThread.CurrentCulture;
                    System.Threading.Thread.CurrentThread.CurrentCulture = objFormato;
                    this.Hide();
                    frmMenuPrincipal objForma = new frmMenuPrincipal();
                    objForma.Show();
                    //this.btnCancelar_Click(this, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(mstrNomModulo + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodUsuario_Leave(object sender, EventArgs e)
        {
            ENGeneral.GNEmpresas clEmpresas = new ENGeneral.GNEmpresas();
            NGGeneral.GNEmpresa ngEmpresa = new NGGeneral.GNEmpresa();

            ENGeneral.GNUsuario enUsuario = new ENGeneral.GNUsuario();
            NGGeneral.GNUsuarios ngUsuario = new NGGeneral.GNUsuarios();

            Utilidades.CargarCombo objCargarCombo = new Utilidades.CargarCombo();

            try
            {
                if (txtCodUsuario.Text.Length == 0)
                    return;

                if (txtCodUsuario.Text.Length >= 6 || txtCodUsuario.Text.Length <= 10)
                {
                    //Buscar el Codigo del Usuario
                    enUsuario = ngUsuario.Consultar(txtCodUsuario.Text.Trim(), true);

                    if (enUsuario == null)
                    {
                        MessageBox.Show("Usuario no Existe", mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    clEmpresas = ngEmpresa.CatalogoEmpresasPorUsuario(enUsuario.Login, true);
                    if (clEmpresas == null)
                    {
                        MessageBox.Show("Usuario no Existe o no tiene empresas asociadas ", mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        objCargarCombo.EmpresaXUsuario(cmbEmpresa, txtCodUsuario.Text, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(mstrNomModulo + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void cmbEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            Utilidades.CargarCombo objCargarCombo = new Utilidades.CargarCombo();
            try
            {
                if (cmbEmpresa.Text == null || cmbEmpresa.Text == "")
                {
                    MessageBox.Show("Seleccione la Empresa", mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbEmpresa.Focus();
                    return;
                }
                else
                {

                    objCargarCombo.PlantaXUsuario(cmbSucursal, cmbEmpresa.GetColumnValue("CodEmpresa").ToString(),
                                                  txtCodUsuario.Text, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(mstrNomModulo + ex.Message, mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}