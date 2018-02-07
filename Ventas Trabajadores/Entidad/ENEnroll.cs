using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENGeneral
{
    public class ENEnroll
    {
        public int ID { get; set; }
        public string CodTrabajador { get; set; }
        public int quality { get; set; }
        public byte[] Template { get; set; }
    }

    public class ENEnrolls : List<ENEnroll>
    { }
}
