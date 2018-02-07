using System;
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


 
namespace Ventas_Trabajadores
{
    public partial class frmCaptaHuella : Form
    {
        #region //*****VAR: BIOMETRIA**********//
        private enum QualityTemplate
        {
            INSF = 1,
            SUF,
            GOOD,
            VERYGOOD
        }

        private formOption fopt;
        private FingerprintCore fingerPrint;
        private FingerprintRawImage rawImage;
        private FingerprintTemplate _template;
        private int stepCount;
        #endregion

        //Otras Variables
        private bool blnAutoExtraer = true;
        private string strRutaImagen = "";
        public string strCodTrabajador = "";
        public string strNombTrabajador = "";
        public bool blnCargarPantalla;
        public bool blnHuellaVal = false;

       
        public frmCaptaHuella()
        {
            InitializeComponent();
            fingerPrint = new FingerprintCore();
            fingerPrint.onStatus += new StatusEventHandler(fingerPrint_onStatus);
            fingerPrint.onImage += new ImageEventHandler(fingerPrint_onImage);
            fingerPrint.onFinger += new FingerEventHandler(fingerPrint_onFinger);
            fopt = new formOption();
            axGrFingerXCtrl1.SetLicenseFolder(@"C:\Program Files\Griaule\Fingerprint SDK 2009\bin\");
            axGrFingerXCtrl1.InstallLicense("KVFAI-WKXYO-FCGFF-TVBJF");
            
                

        }

        private void frmCaptaHuella_Activated(object sender, EventArgs e)
        {
            lblNombTrabajador.Text = strNombTrabajador;
        }

        private void frmCaptaHuella_Load(object sender, EventArgs e)
        {
            try
            {
                fingerPrint.Initialize();
                System.Threading.Thread.Sleep(100);
                fingerPrint.CaptureInitialize();
                //SetLaberThreshold();

                //SetStatusMessage("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        private void frmCaptaHuella_FormClosing(object sender, FormClosingEventArgs e)
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

       

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            ExtractTemplate();
        }

        
        #region //****************************************PROCEDIMIENTOS Y FUNCIONES*****************************************//
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
            int intCalidad = 0;
            try
            {
                
                rawImage = ie.RawImage;
                fingerPrint.Extract(rawImage, ref _template); // we extract fingerprint's information and store that information in templateHuella 

                switch (_template.Quality)
                {
                    case 0:     // in case fingerprint has a bad quality
                        tsslStatusMessage.Text = "bad quality, try again";
                        return;

                    case 1:     // in case fingerprint has a medium quality
                        tsslStatusMessage.Text = "Medium Quality";
                        ExtractTemplate();
                        //if (MessageBox.Show("Fingerprint has a medium quality, proceed anyway?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            //break;
                        return;

                    case 2:     // good quality
                        ExtractTemplate();
                        tsslStatusMessage.Text = "fingeprint has good quality";
                        break;
                }
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            ////////_template = new GriauleFingerprintLibrary.DataTypes.FingerprintTemplate();
            //////SetFingerStatus(ie.Source, 2);
            //////rawImage = ie.RawImage;
            //////SetImage(ie.RawImage.Image);
            //////stepCount++;

            //////ExtractTemplate();
            //////System.Threading.Thread.Sleep(100);
            ////////Identify();
            //////EnableOk();

            //////    //if (blnAutoExtraer == true)
            //////    //{
            //////    //    ExtractTemplate();
            //////    //    System.Threading.Thread.Sleep(100);
            //////    //    Identify();
            //////    //    EnableOk();
            //////    //}
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


        //private void Identify()
        //{
        //    GriauleFingerprintLibrary.DataTypes.FingerprintTemplate testTemplate = null;
        //    DataTable dt = new DataTable();
        //    ENGeneral.ENEnroll enEnroll = new ENGeneral.ENEnroll();
        //    NGGeneral.NGEnroll ngEnroll = new NGGeneral.NGEnroll();
        //    try
        //    {
        //        if ((_template != null) && (_template.Size > 0))
        //        {
        //            fingerPrint.IdentifyPrepare(_template);

        //            //IGRDal dl = DalFactory.GetDal(GrConnector.AccessDal);

        //            //dt = dl.GetTemplate();
        //            enEnroll = ngEnroll.HuellaPorTrabajador(strCodTrabajador, true);
        //            //if (dt.Rows.Count > 0)
        //            if (enEnroll != null)
        //            {
        //                int tempId = enEnroll.ID;
        //                byte[] buff = enEnroll.Template;
        //                int quality = enEnroll.quality;

        //                testTemplate = new GriauleFingerprintLibrary.DataTypes.FingerprintTemplate();

        //                testTemplate.Size = buff.Length;
        //                testTemplate.Buffer = buff;
        //                testTemplate.Quality = quality;

        //                int score;
                        
        //                //if (fingerPrint.Verify(testTemplate, _template, out score) == 0)

        //                if (fingerPrint.Identify (testTemplate, out score)==1)
        //                {
        //                    SetMatchBar(score, Color.SeaGreen);
        //                    SetStatusMessage("Template Matched");
        //                    DisplayImage(_template, true);
        //                    return;
        //                }
        //                else
        //                {
        //                    SetMatchBar(score, Color.LightCoral);
        //                    SetStatusMessage("Template Unmatched");
        //                }

        //                SetMatchBar(0, Color.Gray);
        //                SetStatusMessage("Template Unmatched");

        //                //foreach (DataRow dr in dt.Rows)
        //                //{
        //                //    int tempId = Convert.ToInt32(dr["ID"]);
        //                //    byte[] buff = (byte[])dr["template"];
        //                //    int quality = Convert.ToInt32(dr["quality"]);

        //                //    testTemplate = new GriauleFingerprintLibrary.DataTypes.FingerprintTemplate();

        //                //    testTemplate.Size = buff.Length;
        //                //    testTemplate.Buffer = buff;
        //                //    testTemplate.Quality = quality;

        //                //    int score;
        //                //    if (Identify(testTemplate, out score))
        //                //    {

        //                //        SetMatchBar(score, Color.SeaGreen);
        //                //        SetStatusMessage("Template Matched");
        //                //        DisplayImage(_template, true);

        //                //        return;
        //                //    }
        //                //    else
        //                //    {
        //                //        SetMatchBar(score, Color.LightCoral);
        //                //        SetStatusMessage("Template Unmatched");
        //                //    }

        //                //    SetMatchBar(0, Color.Gray);
        //                //    SetStatusMessage("Template Unmatched");
        //                //}
        //            }
        //        }
        //    }
        //    catch (FingerprintException ge)
        //    {
        //        if (ge.ErrorCode == -8)
        //        {
        //            System.IO.FileStream dumpTemplate = System.IO.File.Create(@".\Dumptemplate.gt");
        //            System.IO.StreamWriter stWriter = new System.IO.StreamWriter(dumpTemplate);

        //            stWriter.WriteLine(BitConverter.ToString(testTemplate.Buffer, 0));
        //            stWriter.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private bool Identify(GriauleFingerprintLibrary.DataTypes.FingerprintTemplate testTemplate, out int score)
        {
            return fingerPrint.Identify(testTemplate, out score) == 1 ? true : false;
        }

        delegate void delsetQuality(int quality);
        private void SetQualityBar(int quality)
        {

            if (prgbQuality.InvokeRequired == true)
            {
                this.Invoke(new delsetQuality(SetQualityBar), new object[] { quality });
            }
            else
            {

                switch (quality)
                {
                    case 0:
                        {
                            prgbQuality.ProgressBarColor = System.Drawing.Color.LightCoral;
                            prgbQuality.Value = prgbQuality.Maximum / 3;
                        } break;
                    case 1:
                        {
                            prgbQuality.ProgressBarColor = System.Drawing.Color.YellowGreen;
                            prgbQuality.Value = (prgbQuality.Maximum / 3) * 2;
                        } break;
                    case 2:
                        {
                            prgbQuality.ProgressBarColor = System.Drawing.Color.MediumSeaGreen;
                            prgbQuality.Value = prgbQuality.Maximum;
                        } break;

                    default:
                        {
                            prgbQuality.ProgressBarColor = System.Drawing.Color.Gray;
                            prgbQuality.Value = 0;
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
            if (btnOk.InvokeRequired == true)
            {
                this.Invoke(new delEnableOk(EnableOk));
            }
            else
            {
                btnOk.Enabled = true;
                blnHuellaVal = true;
            }
        }


     

        private delegate void delPerformStep(QualityTemplate quality, Color color);
        private void PerformStep(QualityTemplate quality, Color color)
        {
            if (prgbConsolidation.InvokeRequired == true)
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

                prgbConsolidation.ProgressBarColor = color;
                prgbConsolidation.Value = step;
            }
        }

     

       

        #endregion


        #region //**********************************PROGRAMACION DE OBJETOS**********************************************//
        private void btnOk_Click(object sender, EventArgs e)
        {
            int intCalidad = 0, result = 0;
            ENGeneral.ENEnroll enEnroll = new ENGeneral.ENEnroll();
            NGGeneral.NGEnroll ngEnroll = new NGGeneral.NGEnroll();
            FingerprintTemplate templateBD;

            Array tmpTpt = Array.CreateInstance(typeof(byte), _template.Size);
            Array.Copy(_template.Buffer, tmpTpt, _template.Size);

            fingerPrint.IdentifyPrepare(_template, result);
            //if (axGrFingerXCtrl1.IdentifyPrepare(ref tmpTpt, result) < 0) return;
            
            enEnroll = ngEnroll.HuellaPorTrabajador("0244", true);
            if (enEnroll != null)
            {
                int tempId = enEnroll.ID;
                byte[] buff = enEnroll.Template;
                int quality = enEnroll.quality;

                templateBD = new GriauleFingerprintLibrary.DataTypes.FingerprintTemplate();

                templateBD.Size = buff.Length;
                templateBD.Buffer = buff;
                templateBD.Quality = quality;

                Array tmpBD = Array.CreateInstance(typeof(byte), templateBD.Size);
                Array.Copy(templateBD.Buffer, tmpBD, templateBD.Size);
                intCalidad = 3;
                result = fingerPrint.Identify(templateBD, out intCalidad);
                //result = axGrFingerXCtrl1.Identify(ref tmpBD, ref intCalidad, (int)GRConstants.GR_DEFAULT_CONTEXT);

                if (result == (int)GRConstants.GR_MATCH)
                {
                    MessageBox.Show("Las Huellas coinciden");
                }

            }

            //if ((fingerPrint.Identify(_template, out intCalidad)) == 1) //Only if template has all our precition expectations
            //{
            //    MessageBox.Show("Las Huellas coinciden");
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
           
        }
        #endregion

       




    }
}