using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENGeneral
{
    public class GNPlanta
    {
        public string CodPlanta { get; set; }
        public string CodEmpresa { get; set; }
        public string NombPlanta { get; set; }
    }
    public class GNPlantas : List<GNPlanta>
    { }
}
