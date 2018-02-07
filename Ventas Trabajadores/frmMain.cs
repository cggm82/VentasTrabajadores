using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GriauleFingerprintLibrary;
using GriauleFingerprintLibrary.Exceptions;
using FingerprintNetSample.DB;
using Ventas_Trabajadores;

namespace FingerprintNetSample
{
    public partial class frmMain : Form
    {
        private formOption fopt;
        private FingerprintCore fingerPrint;
        private GriauleFingerprintLibrary.DataTypes.FingerprintRawImage rawImage;
        GriauleFingerprintLibrary.DataTypes.FingerprintTemplate _template;
        private string strRutaImagen = "";

        public frmMain()
        {
            InitializeComponent();  
            fingerPrint = new FingerprintCore();

            fingerPrint.onStatus += new StatusEventHandler(fingerPrint_onStatus);
            fingerPrint.onFinger += new FingerEventHandler(fingerPrint_onFinger);
            fingerPrint.onImage += new ImageEventHandler(fingerPrint_onImage);
            //fingerPrint.onImage += new ImageEventHandler(on_consolidate);
            fopt = new formOption();
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGRDal dl = DalFactory.GetDal(GrConnector.AccessDal);
            dl.DeleteTemplate();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                fingerPrint.Initialize();
                fingerPrint.CaptureInitialize();
                SetLaberThreshold();
                SetStatusMessage("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        #region //*****************************PROCEDIMIENTOS Y FUNCIONES***********************************//
        private void SetLaberThreshold()
        {
            int thresholdId, rotationMaxId;
            fingerPrint.GetIdentifyParameters(out thresholdId, out rotationMaxId);

            // int relationPos = (thresholdId ) / 300;

            float percent = (float)thresholdId / (float)200;

            lblThreshold2.Left = 10;
            lblThreshold.Left = 10;
            //if (Convert.ToInt32(prgbMatching.Right) == null || prgbMatching.Left == null)
            //{
            //    lblThreshold.Left = 0;
            //    //lblThreshold2.Left = 0 - (lblThreshold2.Width / 2);
            //    lblThreshold2.Left = 0;

            //}
            //else
            //{
            //    int adj = (int)((prgbMatching.Right - prgbMatching.Left) * percent);
            //    lblThreshold.Left = adj;
            //    lblThreshold2.Left = adj - (lblThreshold2.Width / 2);
            //}
        }

        private void fingerPrint_onImage(object source, GriauleFingerprintLibrary.Events.ImageEventArgs ie)
        {
            SetFingerStatus(ie.Source, 2);
            rawImage = ie.RawImage;
            SetImage(ie.RawImage.Image);
            if (autoExtractToolStripMenuItem.Checked)
            {
                ExtractTemplate();

                if (autoIdentifyToolStripMenuItem.Checked)
                {
                    System.Threading.Thread.Sleep(100);
                    Identify();
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

        void fingerPrint_onFinger(object source, GriauleFingerprintLibrary.Events.FingerEventArgs fe)
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
                //prgbMatching.ProgressBarColor = color;
                prgbMatching.ForeColor = color;
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
                        }

                        SetMatchBar(0, Color.Gray);
                        SetStatusMessage("Template Unmatched");

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
            catch { }
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

        private bool Identify(GriauleFingerprintLibrary.DataTypes.FingerprintTemplate testTemplate, out int score)
        {
            return fingerPrint.Identify(testTemplate, out score) == 1 ? true : false;
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

        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        delegate void delControlEnable(ButtonBase button, bool value);
        private void controlEnable(ButtonBase button, bool value)
        {
            if (button.InvokeRequired == true)
            {
                this.Invoke(new delControlEnable(controlEnable), new object[] { button, value });
            }
            else
            {
                button.Enabled = value;
            }
        }

        #endregion 

           


        #region //*****************************PROGRAMACION DE OBJETOS***********************************//

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                fingerPrint.CaptureFinalize();
                fingerPrint.Finalizer();
            }
            catch
            { }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            GrCaptureImageFormat imformat = new GrCaptureImageFormat();
            switch (saveFileDialog1.FilterIndex)
            {
                case 1: { imformat = GrCaptureImageFormat.GRCAP_IMAGE_FORMAT_BMP; } break;
            }
            try
            {
                fingerPrint.SaveRawImageToFile(rawImage, saveFileDialog1.FileName, imformat);
            }
            catch { }
        }
        

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                fingerPrint.LoadImageFromFile(openFileDialog1.FileName, 500);
            }
            catch { }
        }

        private void extractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExtractTemplate();
        }

        private void identifyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Identify();
        }

        private void enrollToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_template == null)
                {
                    MessageBox.Show("Error, Null template");
                    return;
                }
                IGRDal dl = DalFactory.GetDal(GrConnector.AccessDal);
                dl.SaveTemplate(_template,"", strRutaImagen);
            }
            catch { }
        }

        private void startEnrollToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consolidation consolid = Consolidation.GetConsolidationInstance(ref fingerPrint);
            if (consolid.ShowDialog() == DialogResult.OK)
                SetStatusMessage("Template Enroled");
            else
                SetStatusMessage("Consolidation Aborted");
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
