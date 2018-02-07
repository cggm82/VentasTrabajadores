using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Aplicacion;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls; 

namespace Utilidades
{
    public class XtraForm
    {
        private LookUpEdit objUtilidades = new LookUpEdit();
        private ImageComboBoxEdit objUtImgCombo = new ImageComboBoxEdit();
        private Utilidades.Funciones objFunciones = new Funciones();

        public void BloquearControles(System.Windows.Forms.Form objForma, bool blnActivo)
        {
            try
            {
                foreach (System.Windows.Forms.Control objControles in objForma.Controls)
                {
                    if (objControles.Name.Length > 0)
                        objControles.Enabled = blnActivo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void LimpiarControles(System.Windows.Forms.Form objForma)
        {
            try
            {
                string strMensaje;
                string strControl;
                DevExpress.XtraGrid.GridControl objGrid;
                foreach (System.Windows.Forms.Control objControles in objForma.Controls)
                {
                    strMensaje = objControles.Name.ToString();
                    if (string.Compare(objControles.GetType().Name.ToString(), "GroupControl", false) == 0 ||
                        string.Compare(objControles.GetType().Name.ToString(), "LayoutControl", false) == 0 ||
                        string.Compare(objControles.GetType().Name.ToString(), "XtraTabControl", false) == 0)
                    {
                        RecorrerControles(objControles);
                    }
                    else
                    {
                        strControl = objControles.Name.ToString();
                        if (String.Compare(objControles.GetType().Name, "TextBox", false) == 0 ||
                            String.Compare(objControles.GetType().Name, "ComboBox", false) == 0 ||
                            String.Compare(objControles.GetType().Name, "TextEdit", false) == 0 ||
                            String.Compare(objControles.GetType().Name, "MemoEdit", false) == 0 ||
                            String.Compare(objControles.GetType().Name, "CheckedComboBoxEdit", false) == 0 ||
                            String.Compare(objControles.GetType().Name, "ButtonEdit", false) == 0)
                        {
                            objControles.Text = "";
                            objControles.Tag = "";
                            PintarBackColor(objControles);
                        }
                        else
                            if (String.Compare(objControles.GetType().Name, "PictureEdit", false) == 0)
                                objControles.Tag = "";

                        if (String.Compare(objControles.GetType().Name, "LabelControl", false) == 0 ||
                            String.Compare(objControles.GetType().Name.Substring(1, 3), "lbl", false) == 0)
                            PintarForeColor(objControles);


                        if (string.Compare(objControles.GetType().Name.ToString(), "GroupControl", false) == 0 ||
                            string.Compare(objControles.GetType().Name.ToString(), "LayoutControl", false) == 0)
                            PintarControlesInternos(objControles);

                        if (String.Compare(objControles.GetType().Name, "GridControl", false) == 0)
                        {
                            objGrid = (DevExpress.XtraGrid.GridControl)objControles;
                            objGrid.DataSource = null;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void PintarBackColor(System.Windows.Forms.Control objControl)
        {
            try
            {
                if (objControl.Tag != null && objControl.Tag.ToString().Length > 0)
                {
                    switch (objControl.Tag.ToString())
                    {
                        case "Caramel":
                            objControl.BackColor = ColorTranslator.FromHtml(Aplicacion.Constantes.CuadroTextoCaramelo);
                            break;
                        case "Money Twins":
                        case "Blue":
                            objControl.BackColor = ColorTranslator.FromHtml(Aplicacion.Constantes.CuadroTextoAzul);
                            break;
                        case "Lilian":
                            objControl.BackColor = ColorTranslator.FromHtml(Aplicacion.Constantes.CuadroTextoMorado);
                            break;
                        case "DevExpress Dark Style":
                        case "Black":
                            objControl.BackColor = ColorTranslator.FromHtml(Aplicacion.Constantes.CuadroTextoNegro);
                            break;
                        case "DevExpress Style":
                        case "iMaginary":
                            objControl.BackColor = ColorTranslator.FromHtml(Aplicacion.Constantes.CuadroTextoDark);
                            break;
                        default:
                            objControl.BackColor = ColorTranslator.FromHtml(Aplicacion.Constantes.CuadroTextoOriginal);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PintarForeColor(System.Windows.Forms.Control objControl)
        {
            try
            {
                if (objControl.Tag != null && objControl.Tag.ToString().Length > 0)
                {
                    switch (objControl.Tag.ToString())
                    {
                        case "Caramel":
                            objControl.ForeColor = ColorTranslator.FromHtml(Aplicacion.Constantes.EtiquetaCaramelo);
                            break;
                        case "Money Twins":
                        case "Blue":
                            objControl.ForeColor = ColorTranslator.FromHtml(Aplicacion.Constantes.EtiquetaAzul);
                            break;
                        case "Lilian":
                            objControl.ForeColor = ColorTranslator.FromHtml(Aplicacion.Constantes.EtiquetaMorado);
                            break;
                        case "Black":
                        case "DevExpress Style":
                        case "iMaginary":
                            objControl.ForeColor = ColorTranslator.FromHtml(Aplicacion.Constantes.EtiquetaNegro);
                            break;
                        case "DevExpress Dark Style":
                            objControl.ForeColor = ColorTranslator.FromHtml(Aplicacion.Constantes.EtiquetaDark);
                            break;
                        default:
                            objControl.ForeColor = ColorTranslator.FromHtml(Aplicacion.Constantes.EtiquetaOriginal);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecorrerControles(System.Windows.Forms.Control objControlContenedor)
        {
            string strControl;
            DevExpress.XtraEditors.CheckEdit objCheckEdit;
            DevExpress.XtraEditors.RadioGroup objRadioGroup;
            DevExpress.XtraEditors.DateEdit objDateEdit;
            DevExpress.XtraGrid.GridControl objGrid;
            DevExpress.XtraEditors.LookUpEdit objLookUpEdit;
            DevExpress.XtraEditors.ImageComboBoxEdit objImageComboBoxEdit;
            DevExpress.XtraEditors.CheckedComboBoxEdit objCheckedComboBoxEdit;

            foreach (System.Windows.Forms.Control objControl in objControlContenedor.Controls)
            {
                strControl = objControl.Name.ToString();
                if (String.Compare(objControl.GetType().Name, "TextBox", false) == 0 ||
                    String.Compare(objControl.GetType().Name, "ComboBox", false) == 0 ||
                    String.Compare(objControl.GetType().Name, "TextEdit", false) == 0 ||
                    String.Compare(objControl.GetType().Name, "MemoEdit", false) == 0 ||
                    String.Compare(objControl.GetType().Name, "CheckedComboBoxEdit", false) == 0 ||
                    String.Compare(objControl.GetType().Name, "ButtonEdit", false) == 0)
                {
                    objControl.Text = "";
                    objControl.Tag = "";
                    PintarBackColor(objControl);
                }

                if (String.Compare(objControl.GetType().Name, "CheckEdit", false) == 0)
                {
                    objCheckEdit = (DevExpress.XtraEditors.CheckEdit)objControl;
                    objCheckEdit.Checked = false;
                }

                if (String.Compare(objControl.GetType().Name, "LookUpEdit", false) == 0)
                {
                    objLookUpEdit = (DevExpress.XtraEditors.LookUpEdit)objControl;
                    if (objLookUpEdit.Properties.AccessibleName != null && objLookUpEdit.Properties.DataSource != null)
                        objFunciones.UbicarItem(objLookUpEdit, objControl.AccessibleName, null);
                }

                if (String.Compare(objControl.GetType().Name, "ImageComboBoxEdit", false) == 0)
                {
                    objImageComboBoxEdit = (DevExpress.XtraEditors.ImageComboBoxEdit)objControl;
                    if (objImageComboBoxEdit.Properties.AccessibleName != null)
                        objFunciones.UbicarItem(objImageComboBoxEdit, null);
                }
                if (String.Compare(objControl.GetType().Name, "GridControl", false) == 0)
                {
                    objGrid = (DevExpress.XtraGrid.GridControl)objControl;
                    objGrid.DataSource = null;
                }
                if (String.Compare(objControl.GetType().Name, "RadioGroup", false) == 0)
                {
                    objRadioGroup = (DevExpress.XtraEditors.RadioGroup)objControl;
                    objRadioGroup.SelectedIndex = -1;
                }
                if (String.Compare(objControl.GetType().Name, "DateEdit", false) == 0)
                {
                    objDateEdit = (DevExpress.XtraEditors.DateEdit)objControl;
                    objDateEdit.Properties.NullText = "";
                    objDateEdit.Properties.NullDate = DateTime.MinValue;
                }
                if (String.Compare(objControl.GetType().Name, "CheckedComboBoxEdit", false) == 0)
                {
                    objCheckedComboBoxEdit = (DevExpress.XtraEditors.CheckedComboBoxEdit)objControl;
                    for (int i = 0; i < objCheckedComboBoxEdit.Properties.GetItems().Count; i++)
                        objCheckedComboBoxEdit.Properties.Items[i].CheckState = CheckState.Unchecked;
                    objCheckedComboBoxEdit.Refresh();
                }

                if (String.Compare(objControl.GetType().Name, "LabelControl", false) == 0)
                    PintarForeColor(objControl);

                if (String.Compare(objControl.GetType().Name, "XtraTabPage", false) == 0 ||
                    String.Compare(objControl.GetType().Name, "GroupControl", false) == 0 ||
                    String.Compare(objControl.GetType().Name, "LayoutControl", false) == 0)
                {
                    RecorrerControles(objControl);
                    PintarControlesInternos(objControl);
                }

            }
        }

        private void PintarControlesInternos(System.Windows.Forms.Control objControlContenedor)
        {
            try
            {
                if (string.Compare(objControlContenedor.GetType().Name.ToString(), "GroupControl", false) == 0 ||
                    string.Compare(objControlContenedor.GetType().Name.ToString(), "LayoutControl", false) == 0)
                {
                    foreach (System.Windows.Forms.Control objControlInterno in objControlContenedor.Controls)
                    {
                        if (String.Compare(objControlInterno.GetType().Name, "TextBox", false) == 0 ||
                                String.Compare(objControlInterno.GetType().Name, "ComboBox", false) == 0 ||
                                String.Compare(objControlInterno.GetType().Name, "TextEdit", false) == 0 ||
                                String.Compare(objControlInterno.GetType().Name, "MemoEdit", false) == 0 ||
                                String.Compare(objControlInterno.GetType().Name, "CheckedComboBoxEdit", false) == 0 ||
                                String.Compare(objControlInterno.GetType().Name, "ButtonEdit", false) == 0)
                        {
                            PintarBackColor(objControlInterno);
                        }
                        if (String.Compare(objControlInterno.GetType().Name, "LabelControl", false) == 0)
                        {
                            PintarForeColor(objControlInterno);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CenterForm(System.Windows.Forms.Form Forma)
        {
            Forma.Left = (Screen.PrimaryScreen.Bounds.Width / 2) - (Forma.Width / 2);
            Forma.Top = (Screen.PrimaryScreen.Bounds.Height / 4) - (Forma.Height / 4);
            if (Screen.PrimaryScreen.Bounds.Height < Forma.Top + Forma.Height)
                Forma.Top = 0;
        }


    }
}
