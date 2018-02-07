using System;
using DevExpress.XtraEditors.Repository ;


namespace PRUtilidades.Clases
{
    internal class LookUpEdit
    {
       protected internal object LlenarConDataSource(DevExpress.XtraEditors.LookUpEdit objCombo,
                                          string strValueMember,
                                          object DataSource,
                                          string strDisplayMember,
                                          string[] arColumnasMostrar,
                                          int[] arAnchoCol,
                                          int intFilas,
                                          bool blnMuestraCabecera)
        {
            bool blnEncontro = false;
            try
            {
                //objCombo.Properties.Columns.Clear();
                objCombo.Properties.ShowHeader = blnMuestraCabecera;
                objCombo.Properties.ShowFooter = false;
                objCombo.Properties.NullText = "";
                objCombo.Properties.ValueMember = strValueMember;
                objCombo.Properties.DisplayMember = strDisplayMember;
                objCombo.Properties.DataSource = DataSource;
                objCombo.Properties.ForceInitialize();
                objCombo.Properties.PopulateColumns();
                

                if (intFilas >= 10)
                    objCombo.Properties.DropDownRows = 10;
                else
                    objCombo.Properties.DropDownRows = intFilas++;

                               
                objCombo.Refresh();

                for (int col = 0; col < objCombo.Properties.Columns.Count ; col++)
                {
                    for (int i = 0; i <= arColumnasMostrar.Length - 1; i++)
                    {
                        if (objCombo.Properties.Columns[col].FieldName == arColumnasMostrar[i].ToString())
                        {
                            //objCombo.Width = objCombo.Width + arAnchoCol[i];
                            blnEncontro = true;
                            break;
                        }
                        else
                            blnEncontro = false;
                    }
                    if (blnEncontro == false)
                        objCombo.Properties.Columns[col].Visible = false;

                }
                objCombo.ItemIndex = -1;
                objCombo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.None;
                return objCombo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected internal object LlenarConDataSource(DevExpress.XtraEditors.LookUpEdit objCombo,
                                          string strValueMember,
                                          object DataSource,
                                          string strDisplayMember,
                                          string[] arColumnasMostrar,
                                          int[] arAnchoCol,
                                          int intFilas,
                                          bool blnMuestraCabecera,
                                          bool blnMuestraPiePag,
                                          string[] arNombreColumnas)
        {
            bool blnEncontro = false;
            try
            {
                objCombo.Properties.DataSource = DataSource;
                objCombo.Properties.Columns.Clear();
                objCombo.Properties.ShowHeader = blnMuestraCabecera;
                objCombo.Properties.ShowFooter = blnMuestraPiePag;
                objCombo.Properties.ValueMember = strValueMember;
                objCombo.Properties.DisplayMember = strDisplayMember;
                objCombo.Properties.NullText = "";
                objCombo.Properties.ForceInitialize();
                objCombo.Properties.PopulateColumns();
                if (intFilas >= 10)
                    objCombo.Properties.DropDownRows = 10;
                else
                    objCombo.Properties.DropDownRows = intFilas++;

                for (int col = 0; col <= objCombo.Properties.Columns.Count - 1; col++)
                {
                    for (int i = 0; i <= arColumnasMostrar.Length - 1; i++)
                    {
                        if (objCombo.Properties.Columns[col].FieldName == arColumnasMostrar[i].ToString())
                        {
                            objCombo.Properties.Columns[col].Width = arAnchoCol[i];
                            objCombo.Width = objCombo.Width + arAnchoCol[i];
                            objCombo.Properties.Columns[col].Caption = arNombreColumnas[i];
                            blnEncontro = true;
                            break;
                        }
                        else
                            blnEncontro = false;
                    }
                    if (blnEncontro == false)
                        objCombo.Properties.Columns[col].Visible = false;

                }
                objCombo.ItemIndex = -1;
                objCombo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.None;
                return objCombo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //****************************************RepositoryItemLookUpEdit**************************//
        protected internal object LlenarConDataSource(RepositoryItemLookUpEdit objCombo,
                                         string strValueMember,
                                         object DataSource,
                                         string strDisplayMember,
                                         string[] arColumnasMostrar,
                                         int[] arAnchoCol,
                                         int intFilas,
                                         bool blnMuestraCabecera)
        {
            //Llena un lookUpEdit que esta contenido en un Grid
            bool blnEncontro = false;
            try
            {
                //objCombo.Properties.Columns.Clear();
                objCombo.ShowHeader = blnMuestraCabecera;
                objCombo.ShowFooter = true;
                objCombo.NullText = "";
                objCombo.ValueMember = strValueMember;
                objCombo.DisplayMember = strDisplayMember;
                objCombo.DataSource = DataSource;
                objCombo.ForceInitialize();
                objCombo.PopulateColumns();


                if (intFilas >= 10)
                    objCombo.DropDownRows = 10;
                else
                    objCombo.DropDownRows = intFilas++;


                for (int col = 0; col < objCombo.Columns.Count; col++)
                {
                    for (int i = 0; i <= arColumnasMostrar.Length - 1; i++)
                    {
                        if (objCombo.Columns[col].FieldName == arColumnasMostrar[i].ToString())
                        {
                            blnEncontro = true;
                            break;
                        }
                        else
                            blnEncontro = false;
                    }
                    if (blnEncontro == false)
                        objCombo.Columns[col].Visible = false;
                }
                objCombo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.None;
                return objCombo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected internal object LlenarConDataSource(RepositoryItemLookUpEdit objCombo,
                                         string strValueMember,
                                         object DataSource,
                                         string strDisplayMember,
                                         string[] arColumnasMostrar,
                                         int[] arAnchoCol,
                                         int intFilas,
                                         bool blnMuestraCabecera,
                                         bool blnMuestraFooter)
        {
            //Llena un lookUpEdit que esta contenido en un Grid
            bool blnEncontro = false;
            try
            {
                //objCombo.Properties.Columns.Clear();
                objCombo.ShowHeader = blnMuestraCabecera;
                objCombo.ShowFooter = blnMuestraFooter;
                objCombo.NullText = "";
                objCombo.ValueMember = strValueMember;
                objCombo.DisplayMember = strDisplayMember;
                objCombo.DataSource = DataSource;
                objCombo.ForceInitialize();
                objCombo.PopulateColumns();


                if (intFilas >= 10)
                    objCombo.DropDownRows = 10;
                else
                    objCombo.DropDownRows = intFilas++;


                for (int col = 0; col < objCombo.Columns.Count; col++)
                {
                    for (int i = 0; i <= arColumnasMostrar.Length - 1; i++)
                    {
                        if (objCombo.Columns[col].FieldName.Trim() == arColumnasMostrar[i].ToString().Trim())
                        {
                            blnEncontro = true;
                            break;
                        }
                        else
                            blnEncontro = false;
                    }
                    if (blnEncontro == false)
                        objCombo.Columns[col].Visible = false;
                }
                objCombo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.None;
                return objCombo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

   }


}
