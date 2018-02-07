using System;
using System.IO;
using System.Reflection;

namespace Utilidades
{
    public class CargarEntidad
    {
        string strNombCampo;
        string strTipoDato;
        string strNomControl;

        public void LlenarEntidad(System.Windows.Forms.Form objForma, Object objEntidad)
        {
            try
            {
                string strMensaje;
                foreach (System.Windows.Forms.Control objControles in objForma.Controls)
                {
                    strMensaje = objControles.Name.ToString();
                    if (string.Compare(objControles.GetType().Name.ToString(), "GroupControl", false) == 0 ||
                        string.Compare(objControles.GetType().Name.ToString(), "LayoutControl", false) == 0 ||
                        string.Compare(objControles.GetType().Name.ToString(), "XtraTabControl", false) == 0)
                    {
                        RecorrerControlesInternos(objControles, objEntidad);
                    }
                    else
                    {
                        if (String.Compare(objControles.GetType().Name, "TextEdit", false) == 0 ||
                            String.Compare(objControles.GetType().Name, "ButtonEdit", false) == 0 ||
                            String.Compare(objControles.GetType().Name, "MemoEdit", false) == 0)
                        {
                            if (objControles.AccessibleName != null)
                            {
                                strNomControl = objControles.AccessibleName.ToString();
                                AsignarCamposText(objEntidad, strNomControl, objControles);
                            }
                        }
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
                            AsignarCamposText(objEntidad, strNomControl, objControl);
                        }
                    }


                    if (String.Compare(objControl.GetType().Name, "LookUpEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarCamposCombos(objEntidad, strNomControl, objControl);
                        }
                    }

                    if (String.Compare(objControl.GetType().Name, "RadioGroup", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarCamposRadioGroup(objEntidad, strNomControl, objControl);
                        }
                    }

                    if (String.Compare(objControl.GetType().Name, "CheckEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarCamposCheck(objEntidad, strNomControl, objControl);
                        }
                    }


                    if (String.Compare(objControl.GetType().Name, "SpinEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarCamposSpinEdit(objEntidad, strNomControl, objControl);
                        }
                    }

                    if (String.Compare(objControl.GetType().Name, "DateEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarCamposDateEdit(objEntidad, strNomControl, objControl);
                        }
                    }

                    if (String.Compare(objControl.GetType().Name, "PictureEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarCamposPictureEdit(objEntidad, strNomControl, objControl);
                        }
                    }

                    if (String.Compare(objControl.GetType().Name, "ImageComboBoxEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarCamposImageCombo(objEntidad, strNomControl, objControl);
                        }

                    }
                    if (String.Compare(objControl.GetType().Name, "CheckedComboBoxEdit", false) == 0)
                    {
                        if (objControl.AccessibleName != null)
                        {
                            strNomControl = objControl.AccessibleName.ToString();
                            AsignarCamposCheckComboEdit(objEntidad, strNomControl, objControl);
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

        private void AsignarCamposCombos(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            DevExpress.XtraEditors.LookUpEdit objCombo;
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
                                if (objControl.Text != null)
                                {
                                    strTipoDato = pi.PropertyType.ToString();
                                    objCombo = (DevExpress.XtraEditors.LookUpEdit)objControl;
                                    switch (strTipoDato)
                                    {
                                        case "System.String":
                                            pi.SetValue(objEntidad, Convert.ToString(objCombo.GetColumnValue(strNombCampo)), null);
                                            return;
                                        case "System.Boolean":
                                            pi.SetValue(objEntidad, Convert.ToBoolean(objCombo.GetColumnValue(strNombCampo)), null);
                                            return;
                                        case "System.Int16":
                                            pi.SetValue(objEntidad, Convert.ToInt16(objCombo.GetColumnValue(strNombCampo)), null);
                                            return;
                                    }
                                }
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

        private void AsignarCamposText(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
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
                                if (objControl.Text != null)
                                {

                                    strTipoDato = pi.PropertyType.ToString();
                                    switch (strTipoDato)
                                    {
                                        case "System.String":
                                            pi.SetValue(objEntidad, objControl.Text.ToString(), null);
                                            return;
                                        case "System.Char":
                                            pi.SetValue(objEntidad, Convert.ToChar(objControl.Text), null);
                                            return;
                                        case "System.Boolean":
                                            pi.SetValue(objEntidad, Convert.ToBoolean(objControl.Text), null);
                                            return;
                                        case "System.Int16":
                                            if (objControl.Text.Trim().Length == 0)
                                                pi.SetValue(objEntidad, 0, null);
                                            else
                                                pi.SetValue(objEntidad, Convert.ToInt16(objControl.Text), null);
                                            return;
                                        case "System.Int32":
                                            if (objControl.Text.Trim().Length == 0)
                                                pi.SetValue(objEntidad, 0, null);
                                            else
                                                pi.SetValue(objEntidad, Convert.ToInt32(objControl.Text), null);
                                            return;
                                        case "System.Decimal":
                                            if (objControl.Text.Trim().Length == 0)
                                                pi.SetValue(objEntidad, 0, null);
                                            else
                                                pi.SetValue(objEntidad, Convert.ToDecimal(objControl.Text), null);
                                            return;
                                    }
                                }
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

        private void AsignarCamposRadioGroup(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {

            DevExpress.XtraEditors.RadioGroup objRadioGroup;

            try
            {
                objRadioGroup = (DevExpress.XtraEditors.RadioGroup)objControl;

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
                                if (objRadioGroup.SelectedIndex != -1)
                                {
                                    strTipoDato = pi.PropertyType.ToString();
                                    switch (strTipoDato)
                                    {
                                        case "System.String":
                                            pi.SetValue(objEntidad, Convert.ToString(objRadioGroup.Properties.Items[objRadioGroup.SelectedIndex].Value), null);

                                            return;
                                        case "System.Boolean":
                                            pi.SetValue(objEntidad, Convert.ToBoolean(objRadioGroup.Properties.Items[objRadioGroup.SelectedIndex].Value), null);
                                            return;

                                        case "System.Char":
                                            pi.SetValue(objEntidad, Convert.ToChar(objRadioGroup.Properties.Items[objRadioGroup.SelectedIndex].Value), null);
                                            return;
                                    }
                                }
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

        private void AsignarCamposCheck(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            DevExpress.XtraEditors.CheckEdit objCheckEdit;
            try
            {
                objCheckEdit = (DevExpress.XtraEditors.CheckEdit)objControl;

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
                                if (objControl.Text != null)
                                {
                                    pi.SetValue(objEntidad, Convert.ToBoolean(objCheckEdit.Checked == true ? true : false), null);
                                    return;
                                }
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

        private void AsignarCamposSpinEdit(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            DevExpress.XtraEditors.SpinEdit objSpinEdit;
            try
            {
                objSpinEdit = (DevExpress.XtraEditors.SpinEdit)objControl;

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
                                if (objControl.Text != null)
                                {
                                    strTipoDato = pi.PropertyType.ToString();
                                    switch (strTipoDato)
                                    {
                                        case "System.Int16":
                                            pi.SetValue(objEntidad, Convert.ToInt16(objSpinEdit.Value), null);
                                            return;
                                    }
                                }
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

        private void AsignarCamposDateEdit(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            DevExpress.XtraEditors.DateEdit objDateEdit;
            try
            {
                objDateEdit = (DevExpress.XtraEditors.DateEdit)objControl;

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
                                if (objDateEdit.Text != null)
                                {
                                    if (Convert.ToString(objDateEdit.Text) == "")
                                        pi.SetValue(objEntidad, Convert.ToDateTime("01/01/1900"), null);
                                    else
                                        pi.SetValue(objEntidad, Convert.ToDateTime(objDateEdit.Text), null);
                                    return;
                                }
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

        private void AsignarCamposPictureEdit(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            DevExpress.XtraEditors.PictureEdit objPictureEdit;
            try
            {
                objPictureEdit = (DevExpress.XtraEditors.PictureEdit)objControl;

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
                                if (Convert.ToString(objPictureEdit.Image) == "" || objPictureEdit.Image == null)
                                    pi.SetValue(objEntidad, "", null);
                                else
                                    pi.SetValue(objEntidad, objPictureEdit.Tag, null);
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

        private void AsignarCamposImageCombo(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            DevExpress.XtraEditors.ImageComboBoxEdit objImgCombo;
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
                                if (objControl.Text != null)
                                {
                                    strTipoDato = pi.PropertyType.ToString();
                                    objImgCombo = (DevExpress.XtraEditors.ImageComboBoxEdit)objControl;
                                    switch (strTipoDato)
                                    {
                                        case "System.String":
                                            pi.SetValue(objEntidad, Convert.ToString(objImgCombo.EditValue), null);
                                            return;
                                        case "System.Boolean":
                                            pi.SetValue(objEntidad, Convert.ToBoolean(objImgCombo.EditValue), null);
                                            return;
                                        case "System.Int16":
                                            pi.SetValue(objEntidad, Convert.ToInt16(objImgCombo.EditValue), null);
                                            return;
                                    }
                                }
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

        private void AsignarCamposCheckComboEdit(object objEntidad, string strNomControl, System.Windows.Forms.Control objControl)
        {
            DevExpress.XtraEditors.CheckedComboBoxEdit objChkCombo;
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
                                if (objControl.Text != null)
                                {
                                    strTipoDato = pi.PropertyType.ToString();
                                    objChkCombo = (DevExpress.XtraEditors.CheckedComboBoxEdit)objControl;
                                    switch (strTipoDato)
                                    {
                                        case "System.String":
                                            pi.SetValue(objEntidad, Convert.ToString(objChkCombo.EditValue), null);
                                            return;
                                        case "System.Boolean":
                                            pi.SetValue(objEntidad, Convert.ToBoolean(objChkCombo.EditValue), null);
                                            return;
                                        case "System.Int16":
                                            pi.SetValue(objEntidad, Convert.ToInt16(objChkCombo.EditValue), null);
                                            return;
                                    }
                                }
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

        public void AsignarValoresaCamposNull(object objEntidad)
        {
            try
            {
                foreach (MemberInfo mi in objEntidad.GetType().GetMembers())
                {
                    if (mi.MemberType == MemberTypes.Property)
                    {

                        PropertyInfo pi = mi as PropertyInfo;
                        strTipoDato = pi.PropertyType.ToString();
                        if (strTipoDato == "System.DateTime")
                            if (Convert.ToDateTime(pi.GetValue(objEntidad, null)) == Convert.ToDateTime("01/01/0001"))
                                pi.SetValue(objEntidad, Convert.ToDateTime("01/01/1900"), null);

                        if (pi.GetValue(objEntidad, null) == null)
                        {

                            switch (strTipoDato)
                            {
                                case "System.String":
                                    pi.SetValue(objEntidad, "", null);
                                    break;
                                case "System.Char":
                                    pi.SetValue(objEntidad, "", null);
                                    break;
                                case "System.Boolean":
                                    pi.SetValue(objEntidad, false, null);
                                    break;
                                case "System.Int16":
                                    pi.SetValue(objEntidad, 0, null);
                                    break;
                                case "System.Int32":
                                    pi.SetValue(objEntidad, 0, null);
                                    break;
                                case "System.Decimal":
                                    pi.SetValue(objEntidad, 0, null);
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



    }
}
