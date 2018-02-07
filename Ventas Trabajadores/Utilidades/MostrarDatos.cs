using System;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Utilidades
{
    public class MostrarDatos
    {
        private Utilidades.LookUpEdit objUtilidades = new Utilidades.LookUpEdit();

        public void CargarDatos(System.Windows.Forms.Form objForma, Object objEntidad)
        {
            string strMensaje;
            try
            {
                if (objEntidad == null)
                    return;
                foreach (System.Windows.Forms.Control objControles in objForma.Controls)
                {
                    strMensaje = objControles.Name.ToString();
                    if (string.Compare(objControles.GetType().Name.ToString(), "GroupControl", false) == 0 ||
                        string.Compare(objControles.GetType().Name.ToString(), "LayoutControl", false) == 0 ||
                        string.Compare(objControles.GetType().Name.ToString(), "XtraTabControl", false) == 0)
                    {
                        RecorrerControlesInternos(objControles, objEntidad);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecorrerControlesInternos(System.Windows.Forms.Control objControlContenedor, object objEntidad)
        {
            string strNomControl;
            try
            {
                foreach (System.Windows.Forms.Control objControl in objControlContenedor.Controls)
                {

                    if (String.Compare(objControl.GetType().Name, "TextEdit", false) == 0 ||
                        String.Compare(objControl.GetType().Name, "ButtonEdit", false) == 0 ||
                        String.Compare(objControl.GetType().Name, "MemoEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarText(objEntidad, strNomControl, objControl);
                        }
                    }
                    
                    if (String.Compare(objControl.GetType().Name, "RadioGroup", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarRadioGroup(objEntidad, strNomControl, objControl);
                        }
                    }

                    if (String.Compare(objControl.GetType().Name, "CheckEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarCheck(objEntidad, strNomControl, objControl);
                        }
                    }
                    if (String.Compare(objControl.GetType().Name, "SpinEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarSpinEdit(objEntidad, strNomControl, objControl);
                        }
                    }

                    if (String.Compare(objControl.GetType().Name, "DateEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarDateEdit(objEntidad, strNomControl, objControl);
                        }
                    }

                    if (String.Compare(objControl.GetType().Name, "PictureEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarPictureEdit(objEntidad, strNomControl, objControl);
                        }
                    }


                    if (String.Compare(objControl.GetType().Name, "XtraTabPage", false) == 0 ||
                        String.Compare(objControl.GetType().Name, "GroupControl", false) == 0 ||
                        String.Compare(objControl.GetType().Name, "LayoutControl", false) == 0)
                    {
                        RecorrerControlesInternos(objControl, objEntidad);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        private void AsignarText(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            //FormatearData  objFormatear = new FormatearData(); 
            string strNombCampo;
            decimal decValor;
            try
            {
                foreach (MemberInfo mi in objEntidad.GetType().GetMembers())
                {
                    if (mi.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo pi = mi as PropertyInfo;
                        if (pi != null)
                        {
                            strNombCampo = pi.Name.ToString();
                            if (strNomControl.Trim() == strNombCampo.Trim())
                            {
                                if (pi.GetValue(objEntidad, null) != null)
                                {
                                    objControl.Text = pi.GetValue(objEntidad, null).ToString().Trim();
                                    //switch (objControl.Tag.ToString())
                                    //{
                                    //    case "N0": //Numerico con 0 decimales 
                                    //        decValor = Convert.ToDecimal(pi.GetValue(objEntidad, null));
                                    //        objControl.Text = decValor.ToString(objControl.Tag.ToString(), ci);
                                    //        break;
                                    //    case "N2": //Numerico con 2 decimales 
                                    //        decValor = Convert.ToDecimal(pi.GetValue(objEntidad, null));
                                    //        objControl.Text = decValor.ToString(objControl.Tag.ToString(), ci);
                                    //        break;
                                    //    default:
                                    //        objControl.Text = pi.GetValue(objEntidad, null).ToString().Trim();
                                    //        break;
                                    //}
                                }


                                return;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AsignarCheck(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            string strNombCampo;
            DevExpress.XtraEditors.CheckEdit objchk;
            try
            {
                foreach (MemberInfo mi in objEntidad.GetType().GetMembers())
                {
                    if (mi.MemberType == MemberTypes.Property)
                    {

                        PropertyInfo pi = mi as PropertyInfo;
                        if (pi != null)
                        {
                            strNombCampo = pi.Name.ToString();
                            if (strNomControl.Trim() == strNombCampo.Trim())
                            {
                                objchk = (DevExpress.XtraEditors.CheckEdit)objControl;
                                if (pi.GetValue(objEntidad, null) != null)
                                    objchk.CheckState = Convert.ToBoolean(pi.GetValue(objEntidad, null)) == true ? CheckState.Checked : CheckState.Unchecked;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AsignarRadioGroup(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            string strNombCampo;
            string strTipoDato;
            string strValor;
            char strcValor;
            DevExpress.XtraEditors.RadioGroup objRadioGroup = new DevExpress.XtraEditors.RadioGroup();
            try
            {
                foreach (MemberInfo mi in objEntidad.GetType().GetMembers())
                {
                    if (mi.MemberType == MemberTypes.Property)
                    {

                        PropertyInfo pi = mi as PropertyInfo;
                        if (pi != null)
                        {
                            strNombCampo = pi.Name.ToString();
                            if (strNomControl.Trim() == strNombCampo.Trim())
                            {
                                
                                objRadioGroup = (DevExpress.XtraEditors.RadioGroup)objControl;
                                strTipoDato = pi.PropertyType.ToString();
                                if (pi.GetValue(objEntidad, null) != null)
                                {
                                    switch (strTipoDato)
                                    {
                                        case "System.Boolean":
                                            objRadioGroup.SelectedIndex = Convert.ToBoolean(pi.GetValue(objEntidad, null)) == true ? 0 : 1;
                                            return;
                                        case "System.String":
                                            strValor = Convert.ToString(pi.GetValue(objEntidad, null));
                                            for (int i = 0; i < objRadioGroup.Properties.Items.Count; i++)
                                            {
                                                if (objRadioGroup.Properties.Items[i].Value.ToString() == strValor)
                                                {
                                                    objRadioGroup.SelectedIndex = i;
                                                    break;
                                                }
                                            }
                                            return;

                                        case "System.Char":
                                            strcValor = Convert.ToChar(pi.GetValue(objEntidad, null));

                                            for (int i = 0; i < objRadioGroup.Properties.Items.Count; i++)
                                            {
                                                if (Convert.ToChar(objRadioGroup.Properties.Items[i].Value) == strcValor)
                                                {
                                                    objRadioGroup.SelectedIndex = Convert.ToInt32(i);
                                                    break;
                                                }
                                            }
                                            return;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void AsignarSpinEdit(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            string strNombCampo;
            DevExpress.XtraEditors.SpinEdit objSpinEdit;
            try
            {
                foreach (MemberInfo mi in objEntidad.GetType().GetMembers())
                {
                    if (mi.MemberType == MemberTypes.Property)
                    {

                        PropertyInfo pi = mi as PropertyInfo;
                        if (pi != null)
                        {
                            strNombCampo = pi.Name.ToString();
                            if (strNomControl.Trim() == strNombCampo.Trim())
                            {
                                objSpinEdit = (DevExpress.XtraEditors.SpinEdit)objControl;
                                if (pi.GetValue(objEntidad, null) != null)
                                    objSpinEdit.Value = Convert.ToInt16(pi.GetValue(objEntidad, null));
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AsignarDateEdit(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            string strNombCampo;
            DevExpress.XtraEditors.DateEdit objDateEdit;
            try
            {
                foreach (MemberInfo mi in objEntidad.GetType().GetMembers())
                {
                    if (mi.MemberType == MemberTypes.Property)
                    {

                        PropertyInfo pi = mi as PropertyInfo;
                        if (pi != null)
                        {
                            strNombCampo = pi.Name.ToString();
                            if (strNomControl.Trim() == strNombCampo.Trim())
                            {
                                objDateEdit = (DevExpress.XtraEditors.DateEdit)objControl;
                                if (pi.GetValue(objEntidad, null) != null)
                                    objDateEdit.DateTime = Convert.ToDateTime(pi.GetValue(objEntidad, null));
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AsignarPictureEdit(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            string strNombCampo;
            DevExpress.XtraEditors.PictureEdit objPictureEdit;
            try
            {
                foreach (MemberInfo mi in objEntidad.GetType().GetMembers())
                {
                    if (mi.MemberType == MemberTypes.Property)
                    {

                        PropertyInfo pi = mi as PropertyInfo;
                        if (pi != null)
                        {
                            strNombCampo = pi.Name.ToString();
                            if (strNomControl.Trim() == strNombCampo.Trim())
                            {
                                objPictureEdit = (DevExpress.XtraEditors.PictureEdit)objControl;
                                if (pi.GetValue(objEntidad, null) != null)
                                {
                                    if (pi.GetValue(objEntidad, null).ToString() != "")
                                        objPictureEdit.Image = System.Drawing.Image.FromFile(pi.GetValue(objEntidad, null).ToString());
                                }

                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }

  
}
