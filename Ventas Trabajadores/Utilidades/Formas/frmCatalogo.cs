using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using PRUtilidades;
using Aplicacion;

namespace PRUtilidades.Formas
{
    public partial class frmCatalogo : DevExpress.XtraEditors.XtraForm
   {
        public bool ExistenDatos { get; set; }
        int [] intAnchoColumnas = new int[50];
        string[] _titulosColumnas = new string[]{};
        bool[] _columnasVisibles = new bool[] { true, true};
        public int[] AnchoColumnas { get; set; }
        public bool[] ColumnasVisibles { get; set; }
        public string[] TitulosColumnas { get; set; }
        public bool Selecciono { get; set; }
        public object FilaSeleccionada { get; set; }
        public string[] NombreCampo { get; set; }

        public frmCatalogo(Object Coleccion)
        {
            InitializeComponent();
            if (Coleccion != null)
            {
                grdCatalogo.DataSource = Coleccion;
                ExistenDatos = true;
                lblCantReg.Text = grdvCatalogo.RowCount.ToString();
            }
            else ExistenDatos = false;   
        }

        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            bool blnEncontro = false;
            int intAnchoGrid = 0;
            try
            {
                grdvCatalogo.OptionsView.AllowCellMerge = true;
                if (grdvCatalogo.DataRowCount >= 1)
                {
                    for (int i = 0; i <= NombreCampo.Length - 1; i++)
                    {
                        for (int col = 0; col <= grdvCatalogo.Columns.Count - 1; col++)
                        {
                            if (grdvCatalogo.Columns[col].FieldName == NombreCampo[i].ToString())
                            {
                                if (i != col)
                                {
                                    grdvCatalogo.Columns[col].FieldName = grdvCatalogo.Columns[i].FieldName.ToString();
                                    grdvCatalogo.Columns[i].FieldName = NombreCampo[i].ToString();
                                    grdvCatalogo.Columns[i].Width = AnchoColumnas[i];

                                    intAnchoGrid = intAnchoGrid + AnchoColumnas[i];
                                    grdvCatalogo.Columns[i].Caption = TitulosColumnas[i].ToString();

                                    if (grdvCatalogo.Columns[col].FieldName == "Status" || grdvCatalogo.Columns[col].Caption == "Código")
                                        grdvCatalogo.Columns[col].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                                    else
                                        grdvCatalogo.Columns[col].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                                    break;
                                }
                                else

                                    grdvCatalogo.Columns[col].Width = AnchoColumnas[i];
                                intAnchoGrid = intAnchoGrid + AnchoColumnas[i];
                                grdvCatalogo.Columns[col].Caption = TitulosColumnas[i].ToString();
                                if (grdvCatalogo.Columns[col].FieldName == "Status" || grdvCatalogo.Columns[col].Caption == "Código")
                                    grdvCatalogo.Columns[col].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                                else
                                    grdvCatalogo.Columns[col].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                                break;
                            }
                            else
                                blnEncontro = false;
                        }
                        
                    }
                }

                for (int col = 0; col <= grdvCatalogo.Columns.Count - 1; col++)
                {

                    for (int i = 0; i <= NombreCampo.Length - 1; i++)
                    {

                        if (grdvCatalogo.Columns[col].FieldName == NombreCampo[i].ToString())
                        {
                            blnEncontro = true;
                            break;
                        }
                        else
                        {
                            blnEncontro = false;
                        }
                    }
                    if (blnEncontro == false)
                    {
                        grdvCatalogo.Columns[col].Visible = false;
                    }
                }

                grdCatalogo.Width = intAnchoGrid + 30;
                this.Width = grdCatalogo.Width + 60;
                this.Refresh();
                Selecciono = false;
                CenterForm(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        private void CenterForm(System.Windows.Forms.Form Forma)
        {
            Forma.Left = (Screen.PrimaryScreen.Bounds.Width / 2) - (Forma.Width / 2);
            Forma.Top = (Screen.PrimaryScreen.Bounds.Height / 4) - (Forma.Height / 4);
            if (Screen.PrimaryScreen.Bounds.Height < Forma.Top + Forma.Height)
                Forma.Top = 0;
        }

        private void grdCatalogo_DoubleClick(object sender, EventArgs e)
        {
            object objFila = grdvCatalogo.GetRow(grdvCatalogo.FocusedRowHandle);
            if (objFila == null)
            {
                Selecciono = false;
                return;
            }
            FilaSeleccionada = objFila;
            Selecciono = true;
            Close();
        }

        private void grdCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                object objFila = grdvCatalogo.GetRow(grdvCatalogo.FocusedRowHandle);
                if (objFila == null)
                {
                    Selecciono = false;
                    return;
                }
                FilaSeleccionada = objFila;
                Selecciono = true;
                Close();
            }
        }

        private void grdCatalogo_Load(object sender, EventArgs e)
        {
            grdvCatalogo.BestFitColumns();            
        }    
    }
}