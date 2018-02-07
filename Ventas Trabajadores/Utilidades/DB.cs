using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GriauleAfisXLib;
using System.Data;
using System.Data.SqlClient;
using FingerprintNetSample.DB;
using AccesoDatoGeneral;

namespace Griaule
{
    public sealed class SQLiteDataAccessLayer : IGRDal
    {
        private SqlConnection Connection;
        private SqlCommand Command;

        private SQLiteDataAccessLayer()
        {
            Connection = new SqlConnection();
            try
            {
                Connection.Open();
                Command = Connection.CreateCommand();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public void CreateTable()
        {
            Command.CommandText = "CREATE TABLE IF NOT EXISTS ENROLL(ID INTEGER PRIMARY KEY, template BLOB, quality INTEGER )";
            Command.ExecuteNonQuery();
        }

        public int SaveTemplate(TTemplate fingerPrintTemplate)
        {
            Command.CommandText = "INSERT INTO ENROLL(template,quality) VALUES (?,?)";

            Command.Parameters.Add("@template", DbType.Binary).Value = fingerPrintTemplate._tpt;
            //Command.Parameters.Add("@quality", DbType.Int32).Value = fingerPrintTemplate._quality;
            //Command.Parameters.Add("@quality", DbType.Int32).Value = 300; //temp solution
            Command.ExecuteNonQuery();

            string sql = @"select last_insert_rowid()";
            Command.CommandText = sql;
            int rowID = Convert.ToInt32(Command.ExecuteScalar());
            return rowID;


        }

        public System.Data.IDataReader GetTemplates()
        {
            Command.CommandText = "SELECT * from ENROLL";
            return Command.ExecuteReader();
        }

        ~SQLiteDataAccessLayer()
        {
            if (Connection.State == ConnectionState.Open)
            {
                try
                {
                    Connection.Dispose();
                }
                catch { }
            }
        }

        public System.Data.IDataReader GetTemplate(int idTemplate)
        {
            Command.CommandText = "SELECT * FROM ENROLL WHERE ID = ?";
            Command.Parameters.Add("@ID", DbType.Int32).Value = idTemplate;

            return Command.ExecuteReader();
        }

        public void DeleteTemplate(int idTemplate)
        {

        }

        public void DeleteTemplate()
        {
            Command.CommandText = "DELETE FROM ENROLL";
            Command.ExecuteNonQuery();
        }


    }
}//end namespace