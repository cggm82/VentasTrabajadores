using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENGeneral
{
    public class GNAccesosGrupo
    {
        public string CodEmpresa { get; set; }
        public string CodGrupo { get; set; }
        public string DescripcionOpcion { get; set; }
        public string IdentificadorOpcion { get; set; }
        public string IdentificadorAsociado { get; set; }
        public string TipoOpcion { get; set; }
        public string ModuloOrigen { get; set; }
        public string PosicionOpcion { get; set; }
        public string IndAtributos { get; set; }
        public bool IndIncluir { get; set; }
        public bool IndModificar { get; set; }
        public bool IndEliminar { get; set; }
        public bool IndConsultar { get; set; }
        public bool IndImprimir { get; set; }
        public bool IndAutorizar { get; set; }
        public bool IndManualSistema { get; set; }
    }

    public class GNAccesosGrupos : List<GNAccesosGrupo>
    { }
}
