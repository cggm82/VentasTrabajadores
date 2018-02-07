using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GriauleFingerprintLibrary;
using GriauleFingerprintLibrary.DataTypes;
using GriauleFingerprintLibrary.Exceptions;
using FingerprintNetSample.DB;
using FingerprintNetSample;
using GrFingerXLib;
using Aplicacion;


namespace Ventas_Trabajadores
{
    public partial class frmRegistroBiometrico : DevExpress.XtraEditors.XtraForm, Utilidades.IBarra
    {
        #region //*****VAR: BIOMETRIA**********//
        private enum QualityTemplate
        {
            INSF = 1,
            SUF,
            GOOD,
            VERYGOOD
        }

        public FingerprintCore fingerPrint;
        public static frmRegistroBiometrico RegBio = null;
        private FingerprintRawImage rawImage;
        private FingerprintTemplate _template;
        private int stepCount;
        #endregion

        #region //********VAR:Forma*********//
        private string strRutaImagen = @"\\DESARROLLO16\Fuentes Desarrollo Industria\";
        private bool blnEditando=false;       

        //Entidades y Negocio
        private ENGeneral.Entorno genEntorno = new ENGeneral.Entorno();

        //Utilidades
        private Utilidades.XtraForm objForma;
        private Utilidades.Funciones objFunciones = new Utilidades.Funciones();

        //Barra
        private Utilidades.Ribbon objMenu = new Utilidades.Ribbon();
        private DevExpress.XtraBars.Ribbon.RibbonControl objBarra;
        #endregion

        public frmRegistroBiometrico()
        {
            InitializeComponent();
            fingerPrint = new FingerprintCore();
            fingerPrint.onStatus += new StatusEventHandler(fingerPrint_onStatus);
            fingerPrint.onFinger += new FingerEventHandler(fingerPrint_onFinger);
            fingerPrint.onImage += new ImageEventHandler(fingerPrint_onImage);
            axGrFingerXCtrl1.SetLicenseFolder(@"C:\Program Files\Griaule\Fingerprint SDK 2009\bin\");
            axGrFingerXCtrl1.InstallLicense("KVFAI-WKXYO-FCGFF-TVBJF");
        }

        private void frmRegistroBiometrico_Activated(object sender, EventArgs e)
        {
            this.Text = "Registro Biometrico";
        }


        private void frmRegistroBiometrico_Load(object sender, EventArgs e)
        {
            objBarra = (DevExpress.XtraBars.Ribbon.RibbonControl)this.Parent.Parent.Controls["rcBarra"];
            ENGeneral.GNAccesosGrupo enOpcionSistema = new ENGeneral.GNAccesosGrupo();
            NGGeneral.GNAccesoGrupo ngAccesoGrupo = new NGGeneral.GNAccesoGrupo();
            try
            {
                fingerPrint.Initialize();
                //Inicializar y limpiar botones
                objForma = new Utilidades.XtraForm();
                objForma.BloquearControles(this, false);
                objForma.LimpiarControles(this);
                genEntorno = frmMenuPrincipal.genEntorno;
                enOpcionSistema = ngAccesoGrupo.OpcionesPorPantalla(frmMenuPrincipal.genEntorno.CodEmpresa, frmMenuPrincipal.genEntorno.CodGrupoUsuario,
                                                                    "VETran_Pedidos", frmMenuPrincipal.genEntorno.IndAlmacenarErrorBD);

                System.Threading.Thread.Sleep(1000);
                fingerPrint.CaptureInitialize();
                SetLaberThreshold();
                SetStatusMessage("");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmRegistroBiometrico_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                fingerPrint.CaptureFinalize();
                fingerPrint.Finalizer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region //****************************PROCEDIMIENTO BIOMETRIA***************************//
        private void fingerPrint_onFinger(object source, GriauleFingerprintLibrary.Events.FingerEventArgs fe)
        {
            try
            {
                switch (fe.EventType)
                {
                    case GriauleFingerprintLibrary.Events.FingerEventType.FINGER_DOWN:
                        {
                            SetFingerStatus(fe.Source, 0);
                        } break;
                    case GriauleFingerprintLibrary.Events.FingerEventType.FINGER_UP:
                        {
                            SetFingerStatus(fe.Source, 1);
                        } break;
                }
            }
            catch (FingerprintException ge)
            {
                if (ge.ErrorCode == -300008)
                {
                    MessageBox.Show(ge.Message);
                    MessageBox.Show(ge.Source);
                    MessageBox.Show(ge.StackTrace);
                }
            }

        }

        private void fingerPrint_onImage(object source, GriauleFingerprintLibrary.Events.ImageEventArgs ie)
        {

            //_template = new GriauleFingerprintLibrary.DataTypes.FingerprintTemplate();
            SetFingerStatus(ie.Source, 2);
            rawImage = ie.RawImage;
            SetImage(ie.RawImage.Image);
            stepCount++;

            //ExtractTemplate();
            System.Threading.Thread.Sleep(100);
            //Identify();
            EnableOk();

        }

        void fingerPrint_onStatus(object source, GriauleFingerprintLibrary.Events.StatusEventArgs se)
        {
            if (se.StatusEventType == GriauleFingerprintLibrary.Events.StatusEventType.SENSOR_PLUG)
            {
                fingerPrint.StartCapture(source.ToString());
                SetLvwFPReaders(se.Source, 0);
            }
            else
            {
                fingerPrint.StopCapture(source);
                SetLvwFPReaders(se.Source, 1);
            }
        }

        private void SetLaberThreshold()
        {
            int thresholdId, rotationMaxId;
            try
            {
                fingerPrint.GetIdentifyParameters(out thresholdId, out rotationMaxId);

                int relationPos = (thresholdId ) / 300;

                float percent = (float)thresholdId / (float)200;

                lblThreshold2.Left = 10;
                lblThreshold.Left = 10;
                if (Convert.ToInt32(prgbMatching.Right) == null || prgbMatching.Left == null)
                {
                    lblThreshold.Left = 0;
                    lblThreshold2.Left = 0;

                }
                else
                {
                    int adj = (int)((prgbMatching.Right - prgbMatching.Left) * percent);
                    lblThreshold.Left = adj;
                    lblThreshold2.Left = adj - (lblThreshold2.Width / 2);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ExtractTemplate()
        {
            if (rawImage != null)
            {
                try
                {
                    _template = null;
                    fingerPrint.Extract(rawImage, ref _template);
                    SetQualityBar(_template.Quality);
                    DisplayImage(_template, false);

                }
                catch
                {
                    SetQualityBar(-1);
                }
            }
        }
      

        private void Identify()
        {
            GriauleFingerprintLibrary.DataTypes.FingerprintTemplate testTemplate = null;
            DataTable dt = new DataTable();
            try
            {
                if ((_template != null) && (_template.Size > 0))
                {
                    fingerPrint.IdentifyPrepare(_template);

                    IGRDal dl = DalFactory.GetDal(GrConnector.AccessDal);

                    dt = dl.GetTemplates();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            int tempId = Convert.ToInt32(dr["ID"]);
                            byte[] buff = (byte[])dr["template"];
                            int quality = Convert.ToInt32(dr["quality"]);

                            testTemplate = new GriauleFingerprintLibrary.DataTypes.FingerprintTemplate();

                            testTemplate.Size = buff.Length;
                            testTemplate.Buffer = buff;
                            testTemplate.Quality = quality;

                            int score;
                            if (Identify(testTemplate, out score))
                            {

                                SetMatchBar(score, Color.SeaGreen);
                                SetStatusMessage("Template Matched");
                                DisplayImage(_template, true);

                                return;
                            }
                            else
                            {
                                SetMatchBar(score, Color.LightCoral);
                                SetStatusMessage("Template Unmatched");
                            }

                            SetMatchBar(0, Color.Gray);
                            SetStatusMessage("Template Unmatched");
                        }
                    }
                }
            }
            catch (FingerprintException ge)
            {
                if (ge.ErrorCode == -8)
                {
                    System.IO.FileStream dumpTemplate = System.IO.File.Create(@".\Dumptemplate.gt");
                    System.IO.StreamWriter stWriter = new System.IO.StreamWriter(dumpTemplate);

                    stWriter.WriteLine(BitConverter.ToString(testTemplate.Buffer, 0));
                    stWriter.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Identify(GriauleFingerprintLibrary.DataTypes.FingerprintTemplate testTemplate, out int score)
        {
            return fingerPrint.Identify(testTemplate, out score) == 1 ? true : false;
        }

        delegate void delsetQuality(int quality);
        private void SetQualityBar(int quality)
        {

            if (prgbMatching.InvokeRequired == true)
            {
                this.Invoke(new delsetQuality(SetQualityBar), new object[] { quality });
            }
            else
            {

                switch (quality)
                {
                    case 0:
                        {
                            prgbMatching.ProgressBarColor = System.Drawing.Color.LightCoral;
                            prgbMatching.Value = prgbMatching.Maximum / 3;
                        } break;
                    case 1:
                        {
                            prgbMatching.ProgressBarColor = System.Drawing.Color.YellowGreen;
                            prgbMatching.Value = (prgbMatching.Maximum / 3) * 2;
                        } break;
                    case 2:
                        {
                            prgbMatching.ProgressBarColor = System.Drawing.Color.MediumSeaGreen;
                            prgbMatching.Value = prgbMatching.Maximum;
                        } break;

                    default:
                        {
                            prgbMatching.ProgressBarColor = System.Drawing.Color.Gray;
                            prgbMatching.Value = 0;
                        } break;
                }
            }
        }

       

        delegate void delsetMatch(int score, Color color);
        private void SetMatchBar(int score, Color color)
        {


            if (prgbMatching.InvokeRequired == true)
            {
                this.Invoke(new delsetMatch(SetMatchBar), new object[] { score, color });
            }
            else
            {
                prgbMatching.Value = score > 200 ? 200 : score;
                prgbMatching.ProgressBarColor = color;
                prgbMatching.ForeColor = color;
            }
        }



        private delegate void DelSetLvwFPReaders(string readerName, int op);
        private void SetLvwFPReaders(string readerName, int op)
        {
            if (lvwFPReaders.InvokeRequired == true)
            {
                this.Invoke(new DelSetLvwFPReaders(SetLvwFPReaders), new object[] { readerName, op });
            }
            else
            {
                switch (op)
                {
                    case 0:
                        {
                            lvwFPReaders.Items.Add(readerName, readerName, 1);
                        } break;
                    case 1:
                        {
                            lvwFPReaders.Items.RemoveByKey(readerName);
                        } break;
                }
            }
        }

      


        private delegate void delSetFingerStatus(string readerName, int status);
        private void SetFingerStatus(string readerName, int status)
        {
            if (lvwFPReaders.InvokeRequired == true)
            {
                this.Invoke(new delSetFingerStatus(SetFingerStatus), new object[] { readerName, status });
            }
            else
            {
                ListViewItem[] listItens = lvwFPReaders.Items.Find(readerName, false);
                System.Threading.Thread.BeginCriticalRegion();
                foreach (ListViewItem item in listItens)
                {
                    switch (status)
                    {
                        case 0:
                            {
                                item.ImageIndex = 0;

                            } break;
                        case 1:
                            {
                                item.ImageIndex = 1;
                            } break;
                        case 2:
                            {
                                item.ImageIndex = 2;
                            } break;
                    }
                }
                System.Threading.Thread.Sleep(300);
                System.Threading.Thread.EndCriticalRegion();
            }
        }

        private delegate void delSetStatusMessage(string message);
        private void SetStatusMessage(string message)
        {
            if (statusStrip1.InvokeRequired == true)
            {
                this.Invoke(new delSetStatusMessage(SetStatusMessage), new object[] { message });
            }
            else
            {
                tsslStatusMessage.Text = message;
            }
        }

        private delegate void delSetImage(Image img);
        void SetImage(Image img)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new delSetImage(SetImage), new object[] { img });
            }
            else
            {
                pictureBox1.Image = img;
            }
        }

        
        private void DisplayImage(GriauleFingerprintLibrary.DataTypes.FingerprintTemplate template, bool identify)
        {
            IntPtr hdc = FingerprintCore.GetDC();
            IntPtr image = new IntPtr();

            if (identify)
            {
                fingerPrint.GetBiometricDisplay(template, rawImage, hdc, ref image, FingerprintConstants.GR_DEFAULT_CONTEXT);
            }
            else
            {
                fingerPrint.GetBiometricDisplay(template, rawImage, hdc, ref image, FingerprintConstants.GR_NO_CONTEXT);
            }
            SetImage(Bitmap.FromHbitmap(image));
            FingerprintCore.ReleaseDC(hdc);
        }

        private delegate void delEnableOk();
        private void EnableOk()
        {
            //if (btnOk.InvokeRequired == true)
            //{
            //    this.Invoke(new delEnableOk(EnableOk));
            //}
            //else
            //{
            //    btnOk.Enabled = true;
            //}
        }


        private delegate void delPerformStep(QualityTemplate quality, Color color);
        private void PerformStep(QualityTemplate quality, Color color)
        {
            if (prgbMatching.InvokeRequired == true)
            {
                this.Invoke(new delPerformStep(PerformStep), new object[] { quality, color });
            }
            else
            {
                int step = 0;
                switch (quality)
                {
                    case QualityTemplate.INSF:
                        {
                            step = ((int)(stepCount * 5));
                        } break;
                    case QualityTemplate.SUF:
                        {
                            step = 25 + ((int)(stepCount * 3.75));
                        } break;
                    case QualityTemplate.GOOD:
                        {
                            step = 50 + ((int)(stepCount * 2.5));
                        } break;
                    case QualityTemplate.VERYGOOD:
                        {
                            step = 100;
                        } break;
                }

                prgbMatching.ProgressBarColor = color;
                prgbMatching.Value = step;
            }
        }
        #endregion

        #region //*********************************Opciones de la Barra de Menu************************//
        public void Nuevo()
        {}

        public void Buscar()
        {
            bool blnExistenDatos = false;
            ENPersonal.PEInformacionLaboral enTrabajador = new ENPersonal.PEInformacionLaboral();
            Utilidades.Personal.BuscarDatos objBuscarDatos = new Utilidades.Personal.BuscarDatos();

            try
            {
                enTrabajador = objBuscarDatos.TrabajadoresActivos(genEntorno.CodEmpresa, genEntorno.IndAlmacenarErrorBD, ref blnExistenDatos);
                if (enTrabajador != null)
                {

                    txtCodTrabajador.Text = enTrabajador.CodTrabajador;
                    txtNombTrabajador.Text = enTrabajador.Nombre;
                }
                else
                {
                    if (blnExistenDatos == false)
                        MessageBox.Show(Constantes.MsgNoHayRegistros, frmMenuPrincipal.mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objMenu.ActivarBotonesCargar(objBarra, frmMenuPrincipal.enAccesoGrupo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), frmMenuPrincipal.mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Grabar()
        {
            string strCodTrabajador = "", strNombImagen = "";
            try
            {
                strCodTrabajador = "'" + txtCodTrabajador.Text.Trim() + "'";
                strNombImagen = @"Huella_" + txtCodTrabajador.Text.Trim()+".bmp";
                strRutaImagen = strRutaImagen + strNombImagen;

                if (File.Exists(strRutaImagen))
                    File.Delete(strRutaImagen);
                pictureBox1.Image.Save(strRutaImagen);
                strRutaImagen = "'" + strRutaImagen + "'";
                ExtractTemplate();

                IGRDal dl = DalFactory.GetDal(GrConnector.AccessDal);
                dl.SaveTemplate(_template, strCodTrabajador, strRutaImagen);
                Cancelar();
                this.DialogResult = DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                
                this.DialogResult = DialogResult.Abort;
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), frmMenuPrincipal.mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return false;
            }
        }
        public bool Editar()
        {
            objForma.BloquearControles(this, true);
            pictureBox1.Enabled = true;
            SetStatusMessage("Coloque el dedo anular de la mano derecha sobre el lector");
            return true;
        }

        public void Eliminar()
        { }

        public void Cancelar()
        {
            try
            {
                blnEditando = false;
                pictureBox1.Image = null;
                SetStatusMessage("");
                txtCodTrabajador.Text = "";
                txtNombTrabajador.Text = "";
                objForma.LimpiarControles(this);
                objForma.BloquearControles(this, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), frmMenuPrincipal.mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Salir()
        {
            Close();
        }


        public void Ayuda()
        {
            try
            {
                //PRUtilidades.Formas.frmAyuda frmAyuda;
                //frmAyuda = new PRUtilidades.Formas.frmAyuda(Convert.ToInt16(this.Tag), frmINMenu.enAccesoGrupo.IndVideoTutorial,
                //                                            frmINMenu.enAccesoGrupo.IndManualSistema, frmINMenu.enAccesoGrupo.IndManualProced);
                //frmAyuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Aplicacion.Constantes.MensajeError + ex.Message.ToString(), frmMenuPrincipal.mstrNomModulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Imprimir()
        { }

        #endregion

        private void lvwFPReaders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
       
    }
}
