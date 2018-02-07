using System;

namespace ENGeneral
{

    public class Entorno
    {
        public string CodEmpresa { get; set; }
        public string CodUsuario { get; set; }
        public string NombEmpresa { get; set; }
        public string NombUsuario { get; set; }
        public string CodGrupoUsuario { get; set; }
        //public short CodNivelGrupoUsuario { get; set; }
        public string CodPlanta { get; set; }
        //public short CodDepUsuario { get; set; }
        //public string CodCentroCosto { get; set; }
        public string StatusUsuario { get; set; }
        public string Servidor { get; set; }
        public bool IndAlmacenarErrorBD { get; set; }
        //public string LookAndFeel { get; set; }
        //public bool IndDemo { get; set; }
        //public int CodTrabajador { get; set; }
        //public short CodCargo { get; set; }
    }
}
