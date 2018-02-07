using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENGeneral
{
    public class GNEmpresa
    {
        public string CodEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public int CantLaminas { get; set; }
        public decimal TasaImpuesto { get; set; }
        public DateTime FechaTopeMov { get; set; }
        public char IndValDiasPedido { get; set; }
        public char IndValPedidoCierre { get; set; }
        public string IndValHoraPedido { get; set; }
        public decimal DescTasaImpTransfA { get; set; }
        public decimal DescTasaImpTransfB { get; set; }
        public decimal IndTopeDescImpuestoTransf { get; set; }
        public DateTime FechaFinDescTopeTransf { get; set; }

    }

    public class GNEmpresas : List<GNEmpresa>
    {}
}
