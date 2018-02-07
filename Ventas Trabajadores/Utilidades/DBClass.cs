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
// Database routines
// -----------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.OleDb;
using GriauleAfisXLib;
using System.Runtime.InteropServices;

// Template class
public class TTemplate
{
	// Template data.
	public object _tpt;
	// Template size
	public int _size;

	public TTemplate(){
		// Create a byte buffer for the template
	   _tpt = new byte[(int)GrAfisConstants.GRAFIS_MAX_SIZE_TEMPLATE];
	   _size = 0;
	}
}

// Database class
public class DBClass{
	
	// Connection object
	private OleDbConnection _connection;

	// Temporary template for retrieving data from DB
	private TTemplate tptBlob;
	
	// Database we'll be connecting to
	public readonly string CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\\GriauleAfisSample.mdb";
	
	// Default constructor
	public DBClass() {
		// Does nothing
	}

	// Open a connection to fingerprint database
	public bool openDB() {
		// Set connection parameters
		_connection = new OleDbConnection();
		_connection.ConnectionString = CONNECTION_STRING;
		try {
			// Try opening connection
			_connection.Open();
		} catch {
			// Error
			return false;
		}
		// Create a new template object
		tptBlob = new TTemplate();
		// Success
		return true;
	}

	// Close the conection to the fingerprint database
	public bool closeDB() {
		// Ensure we'are connected before disconnecting
		if (_connection.State != ConnectionState.Closed) _connection.Close();
		// Success
		return true;
	}

	// Clear database
	public bool clearDB() {
		// Create "clear" query
		OleDbCommand cmdClear = null;
		cmdClear = new OleDbCommand("DELETE FROM enroll", _connection);
		// Run "clear" query
		if (_connection.State == ConnectionState.Open) cmdClear.ExecuteNonQuery();
		// Success
		return true;
	}

	// Add a template to the database and returns added template ID
	public bool addTemplate(TTemplate tpt,ref int id) {
		OleDbCommand cmdInsert = null;
		OleDbParameter dbParamInsert = null; 
		OleDbCommand cmdSelect =  null;

		try{
			// Create a SQL command containing ? parameter for BLOB
			cmdInsert = new OleDbCommand("INSERT INTO enroll(template) values(?) ", _connection);
			// Create parameter for ? contained in the SQL statement
			System.Byte [] temp = new System.Byte[tpt._size + 1];
			System.Array.Copy((Array)tpt._tpt, 0, temp, 0, tpt._size);
			dbParamInsert = new OleDbParameter("@template", OleDbType.VarBinary, tpt._size, 
							ParameterDirection.Input, false, 0, 0,"ID", 
							DataRowVersion.Current, temp);
			cmdInsert.Parameters.Add(dbParamInsert);
			// Execute query
			if (_connection.State == ConnectionState.Open) cmdInsert.ExecuteNonQuery();
		} catch {
			// Error
			return false;
		}
		try {
			// Create SQL command containing ? parameter for BLOB
			cmdSelect = new OleDbCommand("SELECT top 1 ID FROM enroll ORDER BY ID DESC", _connection);
		    // Retrieve the ID of the added template
			id = System.Convert.ToInt32(cmdSelect.ExecuteScalar());
		} catch {
			// Error
			return false;  
		}
		// Success
		return true;
	}

	// Returns an OleDbDataReader with all enrolled templates in database
	public OleDbDataReader  getTemplates() {
		OleDbCommand cmdGetTemplates;
		OleDbDataReader  rs;
		// Create SQL command retrieving all templates in database
		cmdGetTemplates =  new OleDbCommand("SELECT * FROM enroll", _connection);
		// Return the result
		rs = cmdGetTemplates.ExecuteReader();
		return rs;
	}
	
	// Return the template with the given ID from database
	public TTemplate getTemplate(int id) {
		OleDbCommand cmd = null;
		OleDbDataReader dr = null;
		// Default result is null (meaning error)
		tptBlob._size = 0;
		try {
			// Create SQL command retrieving the desired template in database
			cmd = new OleDbCommand(System.String.Concat("SELECT * FROM enroll WHERE ID = ", System.Convert.ToString((int)id)), _connection);
			dr = cmd.ExecuteReader();
			// Get query response
			dr.Read();
			// Get template itself
			tptBlob = getTemplate(dr);
			// Close query
			dr.Close();
		} catch {
			// Error: close query
			dr.Close();
		}
		// Return result
		return tptBlob;
	}

	// Return template data from an OleDbDataReader
	public TTemplate getTemplate(OleDbDataReader rs) {
		long readedBytes; 
		tptBlob._size = 0;
		// Alloc space for template
		System.Byte[] temp = new System.Byte[(int)GrAfisConstants.GRAFIS_MAX_SIZE_TEMPLATE];
		// Get template raw data from OleDbDataReader
		readedBytes = rs.GetBytes(1, 0, temp, 0,temp.Length);
		// Marshall template raw data to template array
		System.Array.Copy(temp, 0, (Array)tptBlob._tpt,0,(int)readedBytes);
		// Set template data real size
		tptBlob._size = (int)readedBytes;
		// Return template
		return tptBlob;
	}

	// Return enrollment ID from an OleDbDataReader
	public int getId(OleDbDataReader rs) {
		return rs.GetInt32(0);
	}
}
