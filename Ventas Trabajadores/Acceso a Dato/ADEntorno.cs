using System;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Aplicacion;
using AccesoDatoGeneral;
using System.Text;


namespace ADGeneral
{
    public class ADEntorno
    {
        
        public static bool Grabar(ENGeneral.Entorno enEntorno)
        {
            string strRutaEntorno = @"C:\Program Files\Techo Duro S.A\Venta de Trabajadores\Config.inf";
            try
            {
                if (!File.Exists(strRutaEntorno))
                    File.Create(strRutaEntorno);

                using (StreamWriter sw = new StreamWriter(strRutaEntorno))
                {
                    sw.WriteLine(enEntorno.CodEmpresa.ToString());
                    sw.WriteLine(enEntorno.CodUsuario.ToString());
                    sw.WriteLine(enEntorno.NombEmpresa.ToString());
                    sw.WriteLine(enEntorno.NombUsuario.ToString());
                    sw.WriteLine(enEntorno.CodGrupoUsuario.ToString());
                    //sw.WriteLine(enEntorno.CodNivelGrupoUsuario.ToString());
                    sw.WriteLine(enEntorno.CodPlanta.ToString());
                    //sw.WriteLine(enEntorno.CodCentroCosto.ToString());
                    sw.WriteLine(enEntorno.StatusUsuario.ToString());
                    sw.WriteLine(enEntorno.IndAlmacenarErrorBD);
                    //sw.WriteLine(enEntorno.LookAndFeel);
                    //sw.WriteLine(enEntorno.CodTrabajador);
                    //sw.WriteLine(enEntorno.CodCargo);
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public static ENGeneral.Entorno AsignarVariables(bool blnAlmacenarError, ref Aplicacion.Error enError)
        {
            ENGeneral.Entorno enEntorno = new ENGeneral.Entorno();
            //ENGeneral.ConfiguracionEmpresa enConfiguracionEmpresa = new ENGeneral.ConfiguracionEmpresa();
            string strRutaEntorno = @"C:\Program Files\Techo Duro S.A\Venta de Trabajadores\Config.inf";
            try
            {
                if (File.Exists(strRutaEntorno))
                {
                    using (StreamReader sr = new StreamReader(strRutaEntorno))
                    {
                        enEntorno.CodEmpresa = sr.ReadLine();
                        enEntorno.CodUsuario = sr.ReadLine();
                        enEntorno.NombEmpresa = sr.ReadLine();
                        enEntorno.NombUsuario = sr.ReadLine();
                        enEntorno.CodGrupoUsuario = sr.ReadLine();
                        //enEntorno.CodNivelGrupoUsuario = Convert.ToInt16(sr.ReadLine());
                        enEntorno.CodPlanta = sr.ReadLine();
                        //enEntorno.CodCentroCosto = sr.ReadLine();
                        enEntorno.StatusUsuario = sr.ReadLine();
                        enEntorno.Servidor = BuscarNombreServidor();

                        //enConfiguracionEmpresa = ADGeneral.Empresa.ConsultarConfEmpresa(enEntorno.CodEmpresa, blnAlmacenarError, ref enError);
                        enEntorno.IndAlmacenarErrorBD = Convert.ToBoolean(sr.ReadLine());
                        //enEntorno.LookAndFeel = sr.ReadLine().ToString();
                        //enEntorno.IndDemo = (enConfiguracionEmpresa != null ? enConfiguracionEmpresa.IndDemo : false);
                        //enEntorno.CodTrabajador = Convert.ToInt16(sr.ReadLine());
                        //enEntorno.CodCargo = Convert.ToInt16(sr.ReadLine());
                    }
                }
                return enEntorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string BuscarNombreServidor()
        {
            string strTira;
            string strNombreServidor;
            int intPosInicial;
            int intPosFinal;
            int intCantidad;
            try
            {
                strTira = ConfigurationManager.ConnectionStrings["strConexion"].ToString();

                intPosInicial = strTira.IndexOf("r=", 1) + 2;
                intPosFinal = strTira.IndexOf("DataBase", 1) - 1;
                intCantidad = intPosFinal - intPosInicial;
                strNombreServidor = strTira.Substring(intPosInicial, intCantidad);

                return strNombreServidor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
