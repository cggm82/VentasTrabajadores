using System;
using System.IO;
using Aplicacion;

namespace NGGeneral
{
    public class Entorno
    {
        private Utilidades.Funciones objFunciones = new Utilidades.Funciones();
        private Error enError = new Error();

        public bool GrabarEntorno(string strCodUsuario, string strContrasena, string strCodEmpresa,
                                  string strNomEmpresa, string strCodPlanta, bool blnAlmacenarError,
                                  ref Aplicacion.Error enError)
        {
            ENGeneral.Entorno enEntorno = new ENGeneral.Entorno();
            //NGGeneral.Entorno ngEntorno = new NGGeneral.Entorno();
            ENGeneral.GNUsuario enUsuario = new ENGeneral.GNUsuario();
            NGGeneral.GNUsuarios ngUsuario = new NGGeneral.GNUsuarios();
            //ENGeneral.GrupoUsuario enGrupoUsuario = new ENGeneral.GrupoUsuario();
            //NGGeneral.GrupoUsuario ngGrupoUsuario = new NGGeneral.GrupoUsuario();
            //ENPersonal.Trabajador enTrabajador = new ENPersonal.Trabajador();
            //NGPersonal.Trabajador ngTrabajador = new NGPersonal.Trabajador();            
            //string strCodCentroCosto = "";
            //int intCodTrabajador = 0;
            //short intsCodCargo = 0;
            try
            {
                if (File.Exists(Constantes.RutaEntorno))
                    File.Delete(Constantes.RutaEntorno);

                //Buscar los datos del usuario
                if ((enUsuario = ngUsuario.Consultar(strCodUsuario, blnAlmacenarError)) == null)
                {
                    enError.MensajeError = ": Usuario no Existe!!!";
                    enError.OrigenError = " Validacion Interna de Negocio";
                    enError.TipoError = Convert.ToInt32(Enumerado.TipoError.Fuente);
                    return false;
                }
                else
                {
                 

                    if (enUsuario.Contraseña.Trim().ToUpper() == strContrasena.Trim().ToUpper())
                    {
                        //Validar que pasen solo cuentas activas "A"
                        if (enUsuario.Status_Cuenta == "E")
                        {
                            enError.MensajeError = ": Acceso Denegado, Cuenta Inactiva!!!";
                            enError.OrigenError = " Validacion Interna de Negocio";
                            enError.TipoError = Convert.ToInt32(Enumerado.TipoError.Fuente);
                            return false;
                        }

                        //Verificar que la Contrasena no este vencida
                        //if (enUsuario.IndVencimientoContrasena)
                        //{
                        //    if (DateTime.Today >= enUsuario.FecVencimientoContrasena)
                        //    {
                        //        enError.MensajeError = ": Acceso Denegado, Contraseña Vencida!!!";
                        //        enError.OrigenError = " Validacion Interna de Negocio";
                        //        enError.TipoError = Convert.ToInt32(Enumerado.TipoError.Validacion);
                        //        return false;
                        //    }
                        //}

                        ////Verificar que la Cuenta no este bloqueada
                        //if (enUsuario.IndCuentaBloqueada)
                        //{
                        //    enError.MensajeError = ": Acceso Denegado, Cuenta Bloqueada!!!" + Environment.NewLine + "Comuniquese con el Administrador del Sistema.";
                        //    enError.OrigenError = " Validacion Interna de Negocio";
                        //    enError.TipoError = Convert.ToInt32(Enumerado.TipoError.Fuente);
                        //    return false;
                        //}

                        //Si la clave es Igual a la Cedula, pedir cambio de Contraseña
                        if (enUsuario.Cedula == objFunciones.Encriptar(enUsuario.Contraseña, "D", false))
                        {
                            enError.MensajeError = ": Reinicio de Contraseña";
                            enError.OrigenError = " Validacion Interna de Negocio";
                            enError.TipoError = Convert.ToInt32(Enumerado.TipoError.Validacion);
                            return false;
                        }

                        //enGrupoUsuario = ngGrupoUsuario.Consultar(strCodEmpresa, strCodPlanta, enUsuario.Cod_Grupo, blnAlmacenarError);
                        //if (enGrupoUsuario == null)
                        //{
                        //    enError.MensajeError = "El usuario no tiene un Grupo definido!!!";
                        //    enError.OrigenError = " Validacion Interna";
                        //    enError.TipoError = Convert.ToInt32(Enumerado.TipoError.Validacion);
                        //    return false;
                        //}


                        //Construir el entorno
                        enEntorno.CodEmpresa = strCodEmpresa;
                        enEntorno.CodUsuario = enUsuario.Login;
                        enEntorno.NombEmpresa = strNomEmpresa;
                        enEntorno.NombUsuario = enUsuario.Nom_Usuario;
                        enEntorno.CodGrupoUsuario = enUsuario.Cod_Grupo;
                        enEntorno.CodPlanta = strCodPlanta;
                        //enEntorno.CodCentroCosto = strCodCentroCosto;
                        enEntorno.StatusUsuario = enUsuario.Status_Cuenta;
                        //enEntorno.CodNivelGrupoUsuario = enGrupoUsuario.CodNivelGrupo;
                        //enEntorno.LookAndFeel = "";
                        //enEntorno.CodTrabajador = intCodTrabajador;
                        //enEntorno.CodCargo = intsCodCargo;
                        return ADGeneral.ADEntorno.Grabar(enEntorno);
                    }
                    else
                    {
                        enError.MensajeError = ": Acceso Denegado, Contraseña Incorrecta!!!";
                        enError.OrigenError = "Validacion Interna de Negocio";
                        enError.TipoError = Convert.ToInt32(Enumerado.TipoError.Fuente);
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ENGeneral.Entorno AsignarVariablesEntorno(bool blnAlmacenarError)
        {
            ENGeneral.Entorno enEntorno = new ENGeneral.Entorno();
            try
            {
                enEntorno = ADGeneral.ADEntorno.AsignarVariables(blnAlmacenarError, ref enError);
                if (enError.MensajeError == null)
                    return enEntorno;
                else
                    throw new ArgumentException(enError.MensajeError, enError.OrigenError);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
