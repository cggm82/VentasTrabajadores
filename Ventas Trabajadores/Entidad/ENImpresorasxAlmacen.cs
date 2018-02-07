using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENGeneral
{
    public class GNImpresorasxAlmacen
    {
        public string CodEmpresa { get; set; }
        public string CodPlanta { get; set; }
        public string CodAlmacen { get; set; }
        public string CodImpresora { get; set; }
        public string NomImpresora { get; set; }
        public string NomEquipo { get; set; }
        public string CondImpresora { get; set; }
    }
    public class GNImpresorasxAlmacens: List<GNImpresorasxAlmacen>
    {}
}
