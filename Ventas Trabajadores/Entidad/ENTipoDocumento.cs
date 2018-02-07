using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENGeneral
{
    public class GNTiposDocumento
    {
        public string CodEmpresa { get; set; }
        public string CodTipoDocumento { get; set; }
        public string NomTipoDocumento { get; set; }
        public string NomAbreviado { get; set; }
        public string ModuloActivo { get; set; }
        public string Naturaleza { get; set; }
		public decimal Correlativo { get; set; }
        public string Visible { get; set; }
		public string NomTablaDocAsociado { get; set; }
		public string IndAplicaITF { get; set; }
    }
    public class GNTiposDocumentos: List<GNTiposDocumento>
	{}
}
