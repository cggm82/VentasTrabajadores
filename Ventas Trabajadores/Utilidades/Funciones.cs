using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Utilidades
{
    public class Funciones
    {
        #region Funciones_Generales
        public string AddCerosIzq(string pCadena, int pCuantos)
        {
            try
            {
                for (int Pos = 1; Pos <= pCuantos; Pos++)
                    pCadena = "0" + pCadena;

                return pCadena;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public string AddCerosDer(string pCadena, int pCuantos)
        {
            try
            {
                for (int Pos = 1; Pos < pCuantos; Pos++)
                    pCadena = pCadena + "0";

                return pCadena;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public string AddEspacioIzq(string pCadena, int pCuantos)
        {
            string strEspacio = "";
            try
            {
                for (int i = 1; i <= pCuantos; i++)
                    strEspacio += " ";
                return pCadena = strEspacio + pCadena;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public string AddEspacioDer(string pCadena, int pCuantos)
        {
            string strEspacio = "";
            try
            {
                for (int i = 1; i <= pCuantos; i++)
                    strEspacio += " ";
                return pCadena = pCadena + strEspacio;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public string Encriptar(string strClave, string strTipo, bool blnCaracterEspacio)
        {
            int p;
            string encriptado;
            string Caracteres;
            string caracterBuscar;
            string strClaveEncrip = "";
            if (blnCaracterEspacio)
            {
                encriptado = ("£$Æ&%#¤Á@ËÃƒ}ß»ÕµÞ½Ö¾ÜÐ¥¢©§®ŸÅØªÔ¶~Ç«¡²[ï?|").ToUpper();
                Caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@.-_&= ";
            }
            else
            {
                encriptado = ("£$Æ&%#¤Á@ËÃƒ}ß»ÕµÞ½Ö¾ÜÐ¥¢©§®ŸÅØªÔ¶~Ç«¡²[ï?").ToUpper();
                Caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@.-_&=";
            }

            strClave = (strClave).ToUpper().Trim();
            try
            {
                for (int i = 0; i < strClave.Length; i++)
                {
                    caracterBuscar = strClave.Substring(i, 1);
                    for (int j = 0; j < Caracteres.Length; j++)
                    {
                        if (strTipo == "E")
                        {
                            p = Caracteres.IndexOf(caracterBuscar, j);
                            if (p >= 0)
                            {
                                strClaveEncrip = strClaveEncrip + encriptado.Substring(p, 1);
                                break;
                            }
                        }
                        else
                        {
                            p = encriptado.IndexOf(caracterBuscar, j);
                            if (p >= 0)
                            {
                                strClaveEncrip = strClaveEncrip + Caracteres.Substring(p, 1);
                                break;
                            }
                        }
                    }
                }
                return strClaveEncrip;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public bool ValidarVentanasAbiertas(System.Windows.Forms.FormCollection clForms, string strModulo)
        {
            short intsCantFormasAbiertas = 0;
            Boolean blnAbrirVentana;
            try
            {
                for (int i = 0; i < clForms.Count; i++)
                {
                    if (clForms[i].Name != "")
                    {
                        if (clForms[i].Name.Substring(3, 2) == strModulo)
                            intsCantFormasAbiertas++;
                    }
                }
                blnAbrirVentana = (intsCantFormasAbiertas < 3 ? true : false);

                return blnAbrirVentana;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SoloNumero(string strCadena)
        {
            bool blnValor = false;
            try
            {
                foreach (char Caracter in strCadena)
                {
                    if (char.IsDigit(Caracter))
                        blnValor= true;
                    else
                        blnValor= false;
                }
                return blnValor;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Funciones_Objetos
        public void UbicarItem(DevExpress.XtraEditors.LookUpEdit objCombo, string strNombColumna,
                            object valorBuscar)
        {
            try
            {
                for (int col = 0; col < objCombo.Properties.Columns.Count; col++)
                {
                    if (objCombo.Properties.Columns[col].FieldName == strNombColumna)
                    {
                        if (valorBuscar != null)
                            objCombo.ItemIndex = objCombo.Properties.GetDataSourceRowIndex(objCombo.Properties.Columns[col], valorBuscar);
                        else
                            objCombo.EditValue = null;
                        break;
                    }
                }
                objCombo.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UbicarItem(DevExpress.XtraEditors.ImageComboBoxEdit objCombo, object valorBuscar)
        {
            try
            {
                if (valorBuscar == null)
                    objCombo.SelectedItem = null;
                else
                {
                    ImageComboBoxItem item = objCombo.Properties.Items.GetItem(valorBuscar);
                    objCombo.SelectedItem = item;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UbicarItem(DevExpress.XtraEditors.CheckedComboBoxEdit objCombo, object valorBuscar)
        {
            try
            {
                for (int i = 0; i < objCombo.Properties.GetItems().Count; i++)
                {
                    if (objCombo.Properties.Items[i].Value.ToString() == valorBuscar.ToString())
                    {
                        objCombo.Properties.Items[i].CheckState = System.Windows.Forms.CheckState.Checked;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ImpresoraInstaladaEquipo(string strNombImpABuscar)
        {
            bool blnValor = false;
            int intPosc = 0;
            try
            {
                foreach (string strImpresora in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    intPosc = strImpresora.ToUpper().IndexOf(strNombImpABuscar.ToUpper());
                    if (intPosc > -1)
                    {
                        blnValor = (strImpresora.Substring(intPosc).ToUpper() == strNombImpABuscar.ToUpper() ? true : false);
                        if (blnValor)
                            break;
                    }
                    else
                    {
                        blnValor = false;
                        intPosc = 0;
                    }
                }
                return blnValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteRegistroEnGrid(DevExpress.XtraGrid.Views.Grid.GridView grdvView, string strCampo, object objValor)
        {
            bool blnValor = false;
            string strTipoDato = "";

            strTipoDato = objValor.GetType().FullName.ToString();
            switch (strTipoDato)
            {
                case "System.String":
                    for (int i = 0; i < grdvView.RowCount; i++)
                    {
                        if (grdvView.GetRowCellValue(grdvView.GetRowHandle(i), strCampo).ToString() == objValor.ToString())
                        {
                            blnValor = true;
                            break;
                        }
                        else
                            blnValor = false;
                    }
                    return blnValor;
                case "System.Char":
                    for (int i = 0; i < grdvView.RowCount; i++)
                    {
                        if (Convert.ToChar(grdvView.GetRowCellValue(grdvView.GetRowHandle(i), strCampo)) == Convert.ToChar(objValor))
                        {
                            blnValor = true;
                            break;
                        }
                        else
                            blnValor = false;
                    }
                    return blnValor;
                case "System.Boolean":
                    for (int i = 0; i < grdvView.RowCount; i++)
                    {
                        if (Convert.ToBoolean(grdvView.GetRowCellValue(grdvView.GetRowHandle(i), strCampo)) == Convert.ToBoolean(objValor))
                        {
                            blnValor = true;
                            break;
                        }
                        else
                            blnValor = false;
                    }
                    return blnValor;
                case "System.Int16":
                    for (int i = 0; i < grdvView.RowCount; i++)
                    {
                        if (Convert.ToInt16(grdvView.GetRowCellValue(grdvView.GetRowHandle(i), strCampo)) == Convert.ToInt16(objValor))
                        {
                            blnValor = true;
                            break;
                        }
                        else
                            blnValor = false;
                    }
                    return blnValor;
                case "System.Int32":
                    for (int i = 0; i < grdvView.RowCount; i++)
                    {
                        if (Convert.ToInt32(grdvView.GetRowCellValue(grdvView.GetRowHandle(i), strCampo)) == Convert.ToInt32(objValor))
                        {
                            blnValor = true;
                            break;
                        }
                        else
                            blnValor = false;
                    }
                    return blnValor;
                default:
                    return blnValor;

            }
        }
        #endregion

        #region Funciones_BD
        public bool ConsultarHuellaTrabajador(string strCodTrabajador, bool blnAlmacenarError)
        {
            ENGeneral.ENEnroll enEnroll = new ENGeneral.ENEnroll();
            NGGeneral.NGEnroll ngEnroll = new NGGeneral.NGEnroll();
            try
            {
                enEnroll = ngEnroll.HuellaPorTrabajador(strCodTrabajador, blnAlmacenarError);
                if (enEnroll != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool FechaCierreMes(DateTime dtFecha,bool blnAlmacenarError)
        {
            ENGeneral.DimCalendario enCalendario = new ENGeneral.DimCalendario();
            NGGeneral.NGCalendario ngCalendario = new NGGeneral.NGCalendario();
            bool blnValor = false;
            try
            {
                enCalendario = ngCalendario.Calendario(dtFecha, blnAlmacenarError);
                if (enCalendario != null)
                    blnValor = enCalendario.IndCierreMensual;
                return blnValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DiaAntesCierreMes(string strAño, string strMes, bool blnAlmacenarError)
        {
            ENGeneral.DimCalendario enCalendario = new ENGeneral.DimCalendario();
            NGGeneral.NGCalendario ngCalendario = new NGGeneral.NGCalendario();
            bool blnValor = false;
            try
            {
                enCalendario = ngCalendario.DiaCierreAdministrativo(strAño, strMes, blnAlmacenarError);
                if (enCalendario != null)
                {
                    if (DateTime.Now.Date == enCalendario.Fecha.AddDays(-1)) 
                        blnValor = true;
                }
                return blnValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string FechaTopeMovimiento(bool blnAlmacenarError)
        {
            ENGeneral.GNEmpresa enEmpresa = new ENGeneral.GNEmpresa();
            NGGeneral.GNEmpresa ngEmpresa = new NGGeneral.GNEmpresa();
            try
            {
                enEmpresa = ngEmpresa.Consultar(blnAlmacenarError);
                if (enEmpresa != null)
                    return  enEmpresa.FechaTopeMov.ToString();
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DateTime FechaMovimiento(bool blnAlmacenarError)
        {
            ENGeneral.GNEmpresa enEmpresa = new ENGeneral.GNEmpresa();
            NGGeneral.GNEmpresa ngEmpresa = new NGGeneral.GNEmpresa();
            DateTime dtFechaActual = DateTime.Now.Date;
            DateTime dtFechaMov;

            enEmpresa = ngEmpresa.Consultar(blnAlmacenarError);
            if (enEmpresa != null)
            {
                if (dtFechaActual <= enEmpresa.FechaTopeMov)
                    dtFechaMov = dtFechaActual;
                else
                    dtFechaMov = enEmpresa.FechaTopeMov.Date;
            }
            return dtFechaActual;
        }

        public string HoraActual()
        {
            string strHoraActual = DateTime.Now.TimeOfDay.ToString().Substring(0,5);
            return strHoraActual;
        }


        public bool HoraPedido(bool blnAlmacenarError)
        {
            ENGeneral.GNEmpresa enEmpresa = new ENGeneral.GNEmpresa();
            NGGeneral.GNEmpresa ngEmpresa = new NGGeneral.GNEmpresa();
            bool blnValor = true;

            string strHoraActual = HoraActual();
            string strHoraTopePedio = "";
            enEmpresa = ngEmpresa.Consultar(blnAlmacenarError);
            if (enEmpresa != null)
                strHoraTopePedio = (enEmpresa.IndValHoraPedido.Substring(1, 2) == "04" ? "16:00" : enEmpresa.IndValHoraPedido);
            else
                strHoraTopePedio = "";


            DateTime dtHoraActual = Convert.ToDateTime(strHoraActual);
            DateTime dtHoraPedido = Convert.ToDateTime(strHoraTopePedio);
            int intValor;
            try
            {
                intValor = DateTime.Compare(dtHoraActual, dtHoraPedido);  
                if (intValor > 0) blnValor = false;
                return blnValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

      
        #endregion
    }
}
