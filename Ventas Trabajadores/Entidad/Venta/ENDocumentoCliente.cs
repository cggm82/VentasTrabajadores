using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENventa
{
    public class VEDocumentoCliente
    {
        public string CodEmpresa { get; set; }
        public string CodPlanta { get; set; }
        public string CodTipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public DateTime FecEmision { get; set; }
        public DateTime FecVencimiento { get; set; }
        public DateTime FecVencimientoDiferida { get; set; }
        public string CodCliente { get; set; }
        public string NomCliente { get; set; }
        public string TipoPersona { get; set; }
        public string Rif { get; set; }
        public string Nit { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Direccion3 { get; set; }
        public string CodPais { get; set; }
        public string CodCiudad { get; set; }
        public string ClienteDestino { get; set; }
        public string Dir1 { get; set; }
        public string Dir2 { get; set; }
        public string Dir3 { get; set; }
        public string CodZonaVenta { get; set; }
        public string CodCondPago { get; set; }
        public decimal MontoBruto { get; set; }
        public decimal MontoFlete { get; set; }
        public decimal MontoImpuesto { get; set; }
        public decimal ImpuestoAplicado { get; set; }
        public decimal MontoBaseImp { get; set; }
        public decimal MontoNeto { get; set; }
        public decimal SaldoActual { get; set; }
        public int DiasPlazo { get; set; }
        public string ModuloOrigen { get; set; }
        public string SituacionDocumento { get; set; }
        public string Observacion1 { get; set; }
        public string Observacion2 { get; set; }
        public string TipoDivisa { get; set; }
        public string CondDocumento { get; set; }
        public string StatusImpresion { get; set; }
        public DateTime FecRecepcion { get; set; }
        public DateTime FecVctoRecepcion { get; set; }
        public string TipoTransporte { get; set; }
        public string OrdenCarga { get; set; }
        public string CodTipoReferencia { get; set; }
        public string NumReferencia { get; set; }
        public DateTime RegistradoPor { get; set; }
        public string FecRegistro { get; set; }
    }
    public class VEDocumentoClientes : List<VEDocumentoCliente>
    { }
}
