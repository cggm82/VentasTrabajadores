using System;
using System.Globalization;

namespace Utilidades
{
    public class FormatoPropio : CultureInfo
    {
        public FormatoPropio()
            : base("es-ES")
        {
            setFormatoNumerico();
        }

        private void setFormatoNumerico()
        {
            NumberFormatInfo n = this.NumberFormat;
            n.NumberNegativePattern = 0;
            n.NumberGroupSeparator = ",";
            n.NumberDecimalSeparator = ".";
        }
    }
}
