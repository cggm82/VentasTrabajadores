using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENGeneral
{
    public class GNUsuario
    {
        public string Login { get; set; }
        public string Contraseña { get; set; }
        public string Cedula { get; set; }
        public string Nom_Usuario { get; set; }
        public string Cod_Empresa { get; set; }
        public string Cod_Planta { get; set; }
        public string Cod_Grupo { get; set; }
        public string Status_Cuenta { get; set; }
    }

    public class GnUsuarios : List<GNUsuario>
    { }
}
