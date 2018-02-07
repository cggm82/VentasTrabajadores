using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENGeneral
{
    public class DimCalendario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Horasdetrabajo { get; set; }
        public string Motivo { get; set; }
        public string Año { get; set; }
        public string Mes { get; set; }
        public Int16 Trimestre { get; set; }
        public Int16 Semestre { get; set; }
        public Int16 Semana { get; set; }
        public string NombredelMes { get; set; }
        public string DiadelaSemana { get; set; }
        public string DiadelMes { get; set; }
        public string DiadelAño { get; set; }
        public bool IndCierreMensual { get; set; }
    }

    public class DimCalendarios : List<DimCalendario>
    { }
}
