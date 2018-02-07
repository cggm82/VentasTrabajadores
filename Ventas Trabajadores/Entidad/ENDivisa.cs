using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ENGeneral
{
    public class GNDivisa
    {
        public string CodDivisa { get; set; }
        public string NomDivisa { get; set; }
        public string AbreviadoDivisa { get; set; }

        //Campos Externos
        public decimal CambioDivisa { get; set; }
    }

    public class GNDivisas : List<GNDivisa>
    {
    }
}
