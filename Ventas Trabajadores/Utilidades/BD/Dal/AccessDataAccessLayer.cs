using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using GriauleFingerprintLibrary.DataTypes;
using System.Data.SqlClient;
using AccesoDatoGeneral;
using Aplicacion;

namespace FingerprintNetSample.DB.Dal
{
    public sealed class AccessDataAccessLayer : IGRDal
    {
        public SqlConnection cnnConexion = new SqlConnection();
        public AccesoDato objAD = new AccesoDato();
        
        private AccessDataAccessLayer()
        {
            cnnConexion = objAD.AbrirConexion();
        }

        public void SaveTemplate(FingerprintTemplate fingerprintTemplate, string strCodTrabajador, string strRutaImagen)
        {
            SqlCommand Cmd = new SqlCommand();
            int intRegistros;
            string strTira = "";
            try
            {
                using (cnnConexion)
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.Connection = cnnConexion;                    
                    strTira = "INSERT INTO ENROLL ([CodTrabajador],[quality],[Template]) SELECT " + strCodTrabajador + "," + fingerprintTemplate.Quality + "," + 
                               "BulkColumn  FROM Openrowset(Bulk " + strRutaImagen + ", Single_Blob) as Imagen";

                    Cmd.CommandText = strTira;
                    intRegistros = Convert.ToInt32(Cmd.ExecuteNonQuery());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }

        public DataTable GetTemplates()
        {
            AccesoDato objAD = new AccesoDato();
            DataTable dt = new DataTable();
            bool blnAlmacenarError = false;
            Hashtable htParametros = new Hashtable();
            Aplicacion.Error enError = new Error();
            try
            {
                using (cnnConexion)
                {
                    htParametros.Add("@ID", 0);
                    dt = objAD.EjecutarConsulta("[dbo].SqlEnroll", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ~AccessDataAccessLayer()
        {
            if (cnnConexion.State == ConnectionState.Open)
            {
                try
                {
                    cnnConexion.Dispose();
                }
                catch { }
            }
        }

        public DataTable GetTemplate(int idTemplate)
        {
            AccesoDato objAD = new AccesoDato();
            DataTable dt = new DataTable();
            Hashtable htParametros = new Hashtable();
            bool blnAlmacenarError = false;
            Aplicacion.Error enError = new Error();
            try
            {
                using (cnnConexion)
                {
                    htParametros.Add("@ID", idTemplate);
                    dt = objAD.EjecutarConsulta("[dbo].SqlEnroll", cnnConexion, null,
                                            Enumerado.TipoComando.SP, htParametros, blnAlmacenarError, ref enError);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTemplate(int idTemplate) { }
        public void DeleteTemplate()
        {
            AccesoDato objAD = new AccesoDato();
            SqlTransaction ObjTran = null;
            bool blnAlmacenarError = false, blnValor;
            Aplicacion.Error enError = new Error();
            using (cnnConexion)
            {
                ObjTran = cnnConexion.BeginTransaction();
                if (objAD.EjecutarProcedimiento("DELETE FROM ENROLL", cnnConexion, ObjTran, Enumerado.TipoComando.Texto,
                                                    null, blnAlmacenarError, ref enError) >= 0)
                    blnValor = (enError.MensajeError.Trim().Length > 0 ? false : true);
                else
                    blnValor = false;
            }
        }

    }
}
