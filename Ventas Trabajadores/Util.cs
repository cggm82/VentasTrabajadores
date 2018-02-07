/*
-------------------------------------------------------------------------------
Griaule AFIS Sample
(c) 2005 Griaule Tecnologia Ltda.
http://www.griaule.com
-------------------------------------------------------------------------------

This sample is provided with "Griaule AFIS Library" and can't run without it. It's
provided just as an example of using Griaule AFIS Library and should not be used as
basis for any commercial product.

Griaule Tecnologia makes no representations concerning either the merchantability
of this software or the suitability of this sample for any particular purpose.

THIS SAMPLE IS PROVIDED BY THE AUTHOR "AS IS" AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
IN NO EVENT SHALL GRIAULE BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

These notices must be retained in any copies of any part of this
documentation and/or sample.

-------------------------------------------------------------------------------
*/

// -----------------------------------------------------------------------------------
// Support and fingerprint management routines
// -----------------------------------------------------------------------------------

using GriauleAfisXLib;
using System;
using System.Drawing;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using stdole;
using GriauleAfisXSampleCS;

// Raw image data type.
public struct TRawImage 
{
	// Image data.
	public object img;
	// Image width.
	public int width;
	// Image height.
	public int height;
	// Image resolution.
	public float xRes, yRes;
};

public struct Sensor
{

    public string idSensor;
    public string name;

};

public class Util
{
    private FormSegment myFormSegment;
    private int contextId;

	// Some constants to make our code cleaner
	public const int ERR_CANT_OPEN_BD = -999;
	public const int ERR_INVALID_ID = -998;
	public const int ERR_INVALID_TEMPLATE = -997;

    public List<Sensor> sensorsList = new List<Sensor>();
    public Sensor capturingSensor;
    

	// Database class
	public DBClass _DB;

	// The last acquired image
	public TRawImage _raw;
    public TRawImage _raws1;
    public TRawImage _raws2;
	
	// Reference to main form image object
	public PictureBox _pbPic;

	// The template extracted from last acquired image
	private TTemplate _tpt;
    private TTemplate _tpt2;
	
	// Reference to main form log box
	private ListBox _lbLog;

    private RadioButton _rbTwoFingers;
	
	// Reference to Griaule AFIS ActiveX component
	AxGriauleAfisXLib.AxGriauleAfis _GriauleAfisX;

	// Imports needed kernel HDC functions
	[DllImport("user32.dll",EntryPoint="GetDC")]
	public static extern IntPtr GetDC(IntPtr ptr);

	[DllImport("user32.dll",EntryPoint="ReleaseDC")]
	public static extern IntPtr ReleaseDC(IntPtr hWnd,IntPtr hDc);

    

	// -----------------------------------------------------------------------------------
	// Support functions
	// -----------------------------------------------------------------------------------

	// Default constructor
	public Util(ListBox lbLog, PictureBox pbPic, RadioButton rbTwoFingers)
	{
		// Gets references to needed GUI objects
		_lbLog = lbLog;
		_pbPic = pbPic;
        _rbTwoFingers = rbTwoFingers;
		// Clear database and template objects
		_DB = null;
		_tpt = null;
        _tpt2 = null;

    }

	// Write a message into log box
	public void WriteLog(String msg) 
	{
		// Add message
		_lbLog.Items.Add(msg);
		// Scroll down log box to last message
		_lbLog.SelectedIndex = _lbLog.Items.Count - 1;
		_lbLog.ClearSelected();

        
	}

    public void WriteSegmentLog1(String msg)
    {
        myFormSegment.lbSgLog1.Items.Add(msg);
        myFormSegment.lbSgLog1.SelectedIndex = myFormSegment.lbSgLog1.Items.Count - 1;
        myFormSegment.lbSgLog1.ClearSelected();
    
    }

    public void WriteSegmentLog2(String msg)
    {
        myFormSegment.lbSgLog2.Items.Add(msg);
        myFormSegment.lbSgLog2.SelectedIndex = myFormSegment.lbSgLog2.Items.Count - 1;
        myFormSegment.lbSgLog2.ClearSelected();

    }

   

	// Write and describe an error
	public void WriteError(GrAfisConstants _errorCode)
	{
		int errorCode = (int)_errorCode;
		switch (errorCode) 
		{

			// General error codes

			case (int)GrAfisConstants.GRAFIS_ERROR_INITIALIZE_FAIL:
				WriteLog("ERROR: Failed to initialize Griaule AFIS ActiveX. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_NOT_INITIALIZED:
				WriteLog("ERROR: The Griaule AFIS library is not initialized. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_FAIL_LICENSE_READ:
				WriteLog("ERROR: License not found. Check manual for troubleshooting. (error code " + errorCode + ")");
				MessageBox.Show("License not found. Check manual for troubleshooting.", "Griaule AFIS sample");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_NO_VALID_LICENSE:
				WriteLog("ERROR: The current license isn't valid. Check manual for troubleshooting. (error code " + errorCode + ")");
				MessageBox.Show("The current license isn't valid. Check manual for troubleshooting.", "Griaule AFIS sample");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_NULL_ARGUMENT:
				WriteLog("ERROR: A parameter have null value. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_FAIL:
				WriteLog("ERROR: Failed to create GDI object. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_ALLOC:
				WriteLog("ERROR: Failed to create context. Cannot allocate memory. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_PARAMETERS:
				WriteLog("ERROR: One or more parameters are out of bounds. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_WRONG_USE:
				WriteLog("ERROR: This function cannot be called at this time. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_EXTRACT:
				WriteLog("ERROR: Template extraction failed. (error code "+ errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_SIZE_OFF_RANGE:
				WriteLog("ERROR: Image is too big or too small. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_RES_OFF_RANGE:
				WriteLog("ERROR: Image resolution is too low or too high. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_CONTEXT_NOT_CREATED:
				WriteLog("ERROR: Context could not be created. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_INVALID_CONTEXT:
				WriteLog("ERROR: Context does not exist. (error code " + errorCode + ")");
				return;

				// Capture error codes

			case (int)GrAfisConstants.GRAFIS_ERROR_CONNECT_SENSOR:
				WriteLog("ERROR: Error connecting to sensor. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_CAPTURING:
				WriteLog("ERROR: Error capturing image from sensor. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_CANCEL_CAPTURING:
				WriteLog("ERROR: Error stopping capturing from sensor. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_INVALID_ID_SENSOR:
				WriteLog("ERROR: Invalid sensor ID. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_SENSOR_NOT_CAPTURING:
				WriteLog("ERROR: Sensor is not capturing images. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_INVALID_EXT:
				WriteLog("ERROR: Unknown filename extension. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_INVALID_FILENAME:
				WriteLog("ERROR: Invalid filename. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_INVALID_FILETYPE:
				WriteLog("ERROR: Invalid file type. (error code " + errorCode + ")");
				return;
			case (int)GrAfisConstants.GRAFIS_ERROR_SENSOR:
				WriteLog("ERROR: Sensor raised an unexpected error. (error code " + errorCode + ")");
				return;

				// Our error codes

			case ERR_INVALID_TEMPLATE:
				WriteLog("ERROR: Invalid template. (error code "+errorCode+")");
				return;
			case ERR_INVALID_ID:
				WriteLog("ERROR: Invalid ID. (error code "+errorCode+")");
				return;
			case ERR_CANT_OPEN_BD:
				WriteLog("ERROR: Unable to connect to database. (error code "+errorCode+")");
				return;

				// Unhandled errors

			default:
				WriteLog("ERROR: Unknown error (code " + errorCode + ")");
				return;
		}
	}

	// Check if we have a valid template
	private bool TemplateIsValid(TTemplate tpt) {
		// Check the template size and data
		return ((tpt._size > 0) && (tpt._tpt != null));
	}

    private void Display(TRawImage raw, GrAfisConstants context,PictureBox pb)
    {
        // Handle to fingerprint image
        System.Drawing.Image handle = null;
        //System.Drawing.Image handle2 = null;
        // Screen HDC
		IntPtr hdc = GetDC(System.IntPtr.Zero);

        _GriauleAfisX.Display(ref raw.img, raw.width, raw.height, raw.xRes, raw.yRes, hdc.ToInt32(),
                       ref handle, (int)context, GrTemplateType.ttQuery, (int)context);

        // Draw the fingerprint image
        if (handle != null)
        {
            pb.Image = handle;
             pb.Update();
        }
    }

	// -----------------------------------------------------------------------------------
	// Main functions for fingerprint recognition management
	// -----------------------------------------------------------------------------------

	// Initializes Griaule AFIS ActiveX and all necessary objects
	public int InitializeGriauleAfis(AxGriauleAfisXLib.AxGriauleAfis GriauleAfisX) 
	{
		GrAfisConstants result;

		// Get reference to the ActiveX object
		_GriauleAfisX = GriauleAfisX;

        // Create database class
		if (_DB == null) _DB = new DBClass();
		
        // Open database
		if(_DB.openDB()==false) return ERR_CANT_OPEN_BD;
		
        // Create new templates
		if (_tpt == null) _tpt = new TTemplate();
        if (_tpt2 == null) _tpt2 = new TTemplate();
		
        // Create three raw images
		_raw = new TRawImage();
        _raws1 = new TRawImage();
        _raws2 = new TRawImage();
		
        // Initialize Griaule AFIS library
		result = (GrAfisConstants)_GriauleAfisX.Initialize();
		
        if (result < 0) return (int)result;

        result = (GrAfisConstants) _GriauleAfisX.CreateContext(out contextId);
        if (result < 0) return (int)result;

		return (int)GrAfisConstants.GRAFIS_OK;
	}

	// Finalize library and close database
	public void FinalizeUtil() {

        int ret;

        _GriauleAfisX.DestroyContext(contextId);
		// Stop capturing from all sensors
		ret = _GriauleAfisX.CapFinalize();
        
        if (ret != (int)GrAfisConstants.GRAFIS_OK)
            WriteError((GrAfisConstants)ret);

		// Finalize library
		ret = _GriauleAfisX.Finalize();
        if (ret != (int)GrAfisConstants.GRAFIS_OK)
            WriteError((GrAfisConstants)ret);

		// Close database
		_DB.closeDB();
		
        // Free objects
	    _raw.img = null;
        _raws1.img = null;
        _raws2.img = null;
        _tpt = null;
        _tpt2 = null;
		_DB = null;
	}


	// Display fingerprint image on screen
	public void PrintBiometricDisplay(bool isBiometric, GrAfisConstants context, int finger) 
	{

        // Handle to fingerprint image
        System.Drawing.Image handle = null;
        // Screen HDC
        IntPtr hdc = GetDC(System.IntPtr.Zero);
       

		if (isBiometric) 
        {
            if (!_rbTwoFingers.Checked)
            {
                Display(_raw, context, _pbPic);
            }
            else
            {
                if (finger == 0)
                {
                    Display(_raws1, context, myFormSegment.pbImage1);
                    Display(_raws2, (GrAfisConstants) contextId, myFormSegment.pbImage2);
                    myFormSegment.Show();
                 }
                else if (finger == 1)
                {
                    Display(_raws1, context, myFormSegment.pbImage1);
                  
                }
                else if (finger == 2)
                {
                    Display(_raws1, context, myFormSegment.pbImage1);
                    Display(_raws2, (GrAfisConstants)contextId, myFormSegment.pbImage2);
                    myFormSegment.Show();
                 }
            }
		} 
        else 
        {
			// Get handle to the raw fingerprint image
			_GriauleAfisX.RawImageToHandle(ref _raw.img,_raw.width,_raw.height, hdc.ToInt32(), ref handle);
            if (handle != null)
            {
                _pbPic.Image = handle;
                _pbPic.Update();
            }
        }
		
        // Release screen HDC
		ReleaseDC(System.IntPtr.Zero,hdc);
	}

	// Add a fingerprint template to database
	public int Enroll() 
	{
		int id = 0;
		
        // Check if template is valid
        if(_rbTwoFingers.Checked)
		    if (!TemplateIsValid(_tpt) || !TemplateIsValid(_tpt2)) return ERR_INVALID_TEMPLATE;
        else
            if (!TemplateIsValid(_tpt)) return ERR_INVALID_TEMPLATE;
        
        // Add template to database
        if (!_DB.addTemplate(_tpt, ref id))
            return -1;
        else
            WriteLog("Fingerprint enrolled with ID " + id + ".");
		
        //If we have another template, then adds it too
        if(_rbTwoFingers.Checked)
            if (!_DB.addTemplate(_tpt2, ref id)) 
                return -1;
            else
                WriteLog("Fingerprint enrolled with ID " + id + ".");
        
        return 0;
	}

	// Extract a fingerprint template from current image
	public int ExtractTemplate() 
	{
		int quality, result;

        myFormSegment = new FormSegment();

        if (!_rbTwoFingers.Checked)
        {
            // Extract template and get its quality
            quality = _GriauleAfisX.Extract(
                ref _raw.img, _raw.width, _raw.height, _raw.xRes, _raw.yRes,
                (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
            
            if (quality < 0)
            {
                _tpt._size = 0;

                return quality;
            }
            
            _tpt._size = (int)GrAfisConstants.GRAFIS_MAX_SIZE_TEMPLATE;
           
            result = _GriauleAfisX.GetTemplate(ref _tpt._tpt, ref _tpt._size, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
           
            if (result < 0) return result;
            
            return quality;
        }
        else
        {
            quality = _GriauleAfisX.Extract(ref _raws1.img, _raws1.width, _raws1.height, _raws1.xRes, _raws1.yRes,(int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
            
            
            if (quality < 0)
            {
                _tpt._size = 0;

                return quality;
            }

            
            _tpt._size = (int)GrAfisConstants.GRAFIS_MAX_SIZE_TEMPLATE;
            result = _GriauleAfisX.GetTemplate(ref _tpt._tpt, ref _tpt._size, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
            if (result < 0) return result;


            
            quality = _GriauleAfisX.Extract(ref _raws2.img, _raws2.width, _raws2.height, _raws2.xRes, _raws2.yRes, contextId);

           
            if (quality < 0)
            {
                _tpt2._size = 0;

                return quality;
            }


            _tpt2._size = (int)GrAfisConstants.GRAFIS_MAX_SIZE_TEMPLATE;
            result = _GriauleAfisX.GetTemplate(ref _tpt2._tpt, ref _tpt2._size, contextId);
            if (result < 0) return result;

            
            return quality;
        }
	}

	// Identify fingerprint (match current fingerprint against all in database). 
    // Note that we return the first fingerprint in database that matches.
	public int Identify(ref int score, ref int finger) {
		GrAfisConstants result;
		int id,_score;
		OleDbDataReader rs;
		TTemplate tptRef;
        
        myFormSegment = new FormSegment();
		
		if(!TemplateIsValid(_tpt)) return ERR_INVALID_TEMPLATE;
		
        // Start identification process by supplying query template (current fungerprint)
		result = (GrAfisConstants) _GriauleAfisX.IdentifyPrepare(ref _tpt._tpt,
			(int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
		
		if (result < 0) return (int)result;
        
        if (_rbTwoFingers.Checked)
        {
            if (!TemplateIsValid(_tpt2)) return ERR_INVALID_TEMPLATE;
            
            result = (GrAfisConstants)_GriauleAfisX.IdentifyPrepare(ref _tpt2._tpt,
            contextId);
            
            if (result < 0) return (int)result;
        
        }
		
		rs = _DB.getTemplates();
		

		while(rs.Read())
		{
			
			tptRef = _DB.getTemplate(rs);
			
			if ((tptRef._tpt==null) || (tptRef._size == 0)) continue;
			
            // Match query template against retrieved template
			result = (GrAfisConstants) _GriauleAfisX.Identify(ref tptRef._tpt, out _score,(int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
			
            // If the templates match
			if(result == GrAfisConstants.GRAFIS_MATCH)
			{
				id = _DB.getId(rs);
				rs.Close();
                score = _score;
                finger = 1;
				return id;
			}
            else if (_rbTwoFingers.Checked)
            {

                result = (GrAfisConstants)_GriauleAfisX.Identify(ref tptRef._tpt, out _score, contextId);
                
                // If the templates match
                if (result == GrAfisConstants.GRAFIS_MATCH)
                {
                    id = _DB.getId(rs);
                    rs.Close();
                    score = _score;
                    finger = 2;
                    return id;
                }
            
            }
          
            else if (result < 0)
            {
                rs.Close();
                return (int)result;
            }
		}
		
		rs.Close();
        return 0;
       
	}

	// Verify fingerprint (match current fingerprint against another one in database)
	public int Verify(int id, ref int score, ref int finger) {
		TTemplate tptRef;
        int ret;
        int _score1;
        myFormSegment = new FormSegment();
        tptRef = _DB.getTemplate(id);
        
      
        if ((tptRef._tpt == null) || (tptRef._size == 0)) return ERR_INVALID_ID;
        

        if (!_rbTwoFingers.Checked)
        {
           
            if (!TemplateIsValid(_tpt)) return ERR_INVALID_TEMPLATE;
           
            
            // Match the templates and return matching result
            return (int)_GriauleAfisX.Verify(ref _tpt._tpt, ref tptRef._tpt,
                out score, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
        }
        else
        {
            
            if (!TemplateIsValid(_tpt)) return ERR_INVALID_TEMPLATE;
           

            // Match the templates and return matching result
           ret =  (int)_GriauleAfisX.Verify(ref _tpt._tpt, ref tptRef._tpt,
                out _score1, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);

           if (ret == (int)GrAfisConstants.GRAFIS_MATCH)
           {
               score = _score1;
               finger = 1;
               return ret;
           }

           else
           {
               
               if (!TemplateIsValid(_tpt2)) return ERR_INVALID_TEMPLATE;
               

               // Match the templates and return matching result
               ret =  (int)_GriauleAfisX.Verify(ref _tpt2._tpt, ref tptRef._tpt,
                   out _score1, contextId);
              
               score = _score1;
               finger = 2;
               return ret;
            }
            
        
        }
       
	}

	// Display matching information
	public void LogMatchInformation(int finger) 
	{
		int ret;
		int numMinutiaeMatched, numSegmentMatched, rotation, xTranslation, yTranslation;


        if (!_rbTwoFingers.Checked)
        {
            // Retrieve matching information
            ret = _GriauleAfisX.GetMatchInfo(out numMinutiaeMatched,
                out numSegmentMatched, out rotation, out xTranslation,
                out yTranslation, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);


            WriteLog(String.Concat("Matching: ",
                numMinutiaeMatched.ToString(), " minutiae, ",
                numSegmentMatched.ToString(), " segments."));


            WriteLog(String.Concat("Rotation: ", rotation.ToString(),
                "°. Translation: (", xTranslation.ToString(),
                ",", yTranslation.ToString(), ")."));
        }
        else
        {

            if (finger == 1)
            {
                ret = _GriauleAfisX.GetMatchInfo(out numMinutiaeMatched,
                    out numSegmentMatched, out rotation, out xTranslation,
                    out yTranslation, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);

                if (ret < 0)
                    WriteError((GrAfisConstants)ret);
                else
                {
                    WriteSegmentLog1(String.Concat("Matching: ",
                   numMinutiaeMatched.ToString(), " minutiae, ",
                   numSegmentMatched.ToString(), " segments."));


                    WriteSegmentLog1(String.Concat("Rotation: ", rotation.ToString(),
                        "°. Translation: (", xTranslation.ToString(),
                        ",", yTranslation.ToString(), ")."));

                    WriteSegmentLog2("Fingerprint not found");
                }
            }
            else if (finger == 2)
            {

                ret = _GriauleAfisX.GetMatchInfo(out numMinutiaeMatched,
                    out numSegmentMatched, out rotation, out xTranslation,
                    out yTranslation, contextId);

                if (ret < 0)
                    WriteError((GrAfisConstants)ret);
                else
                {
                    WriteSegmentLog2(String.Concat("Matching: ",
                                    numMinutiaeMatched.ToString(), " minutiae, ",
                                    numSegmentMatched.ToString(), " segments."));


                    WriteSegmentLog2(String.Concat("Rotation: ", rotation.ToString(),
                        "°. Translation: (", xTranslation.ToString(),
                        ",", yTranslation.ToString(), ")."));

                    WriteSegmentLog1("Fingerprint not found");
                }
            }
        }


		
   }

	// Display fingerprint pattern classification
	public void LogPatternClassification()
	{
		int ret;
		GrPatternClassification pattern;
        if (!_rbTwoFingers.Checked)
        {
            // Retrieve fingerprint pattern classification
            ret = _GriauleAfisX.GetPatternClassification(out pattern, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
            // Display fingerprint pattern classification
            WriteLog(String.Concat("Pattern classification: ", GetPatternClassificationStr(pattern)));
        }
        else
        {
           

            ret = _GriauleAfisX.GetPatternClassification(out pattern, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
            if (ret < 0)
                WriteError((GrAfisConstants)ret);
            else
                WriteSegmentLog1(String.Concat("Pattern classification: ", GetPatternClassificationStr(pattern)));

            ret = _GriauleAfisX.GetPatternClassification(out pattern, contextId);
            if (ret < 0)
                WriteError((GrAfisConstants)ret);
            else
                WriteSegmentLog2(String.Concat("Pattern classification: ", GetPatternClassificationStr(pattern)));
        
        }

	}

	// Translate a pattern classification code into a pattern classification descriptive name
	private string GetPatternClassificationStr(GrPatternClassification pattern)
	{
		switch(pattern) 
		{
			case GrPatternClassification.pcPlainArch:
				return "Plain arch";
			case GrPatternClassification.pcRightLoop:
				return "Right loop";
			case GrPatternClassification.pcLeftLoop:
				return "Left loop";
			case GrPatternClassification.pcScar:
				return "Scar";
			case GrPatternClassification.pcTentedArch:
				return "Tented arch";
			case GrPatternClassification.pcWhorl:
				return "Whorl";
		}
		return "Unknown";
	}

	// Display template information
	public void LogTemplateInfo()
	{
		int ret;
		int numMinutiae, numSegments, quality;

        if (!_rbTwoFingers.Checked)
        {
            // Retrieve template information
            ret = _GriauleAfisX.GetTemplateInfo(out numMinutiae,
                out numSegments, out quality, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
            // Display template information
            WriteLog(String.Concat(numMinutiae.ToString(), " minutiae, ",
                numSegments.ToString(), " segments, ",
                quality.ToString(), "% quality."));
        }
        else
        {
           ret = _GriauleAfisX.GetTemplateInfo(out numMinutiae,out numSegments, out quality, (int)GrAfisConstants.GRAFIS_DEFAULT_CONTEXT);
            
            if (ret < 0)
                WriteError((GrAfisConstants)ret);
            else
            {
                WriteSegmentLog1(String.Concat(numMinutiae.ToString(), " minutiae, ",
                numSegments.ToString(), " segments, ",
                quality.ToString(), "% quality."));
            }

            ret = _GriauleAfisX.GetTemplateInfo(out numMinutiae,out numSegments, out quality, contextId);
            
            if (ret < 0)
                WriteError((GrAfisConstants)ret);
            else
            {
                WriteSegmentLog2(String.Concat(numMinutiae.ToString(), " minutiae, ",
                numSegments.ToString(), " segments, ",
                quality.ToString(), "% quality."));

            }
        }
	}

	// Display Griaule AFIS version and type
	public void MessageVersion() 
	{
		int majorVersion=0,minorVersion=0;
		GrAfisConstants result;
		string vStr = "";

		// Retrieve Griaule AFIS version and type
		result = (GrAfisConstants)_GriauleAfisX.GetVersion(out majorVersion,out minorVersion);
		
        // Translate Griaule AFIS type to a descriptive name
		if(result == GrAfisConstants.GRAFIS_VERSION_COUNTRY) vStr = "COUNTRY";
		else if(result == GrAfisConstants.GRAFIS_VERSION_STATE) vStr = "STATE";
		
        // Display Griaule AFIS version and type
		MessageBox.Show("The Griaule AFIS version is " +
			majorVersion + "." + minorVersion + ". \n" +
			"The license type is '" + vStr + "'.","Griaule AFIS version");
	}

};
