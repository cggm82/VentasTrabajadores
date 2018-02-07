using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENventa
{
    public class VEPedido
    {
        public string CodEmpresa { get; set; }
		public string CodTipoDocumento { get; set; }
		public string NumDocumento { get; set; }
        public DateTime FecRegistro { get; set; }
        public DateTime FecMovimiento { get; set; }
		public string CodCliente { get; set; }
		public string NomCliente { get; set; }
		public string Rif { get; set; }
		public string Nit { get; set; }
		public string TipoPedido { get; set; }
		public string TipoDivisa { get; set; }
		public string CodZonaVenta { get; set; }
		public string CodZonaDespacho { get; set; }
        public DateTime FecEntregar { get; set; }
		public string TipoTransporte { get; set; }
		public string Direccion1 { get; set; }
		public string Direccion2 { get; set; }
		public string Direccion3 { get; set; }
		public string ClienteDestino { get; set; }
		public string Dir1 { get; set; }
		public string Dir2 { get; set; }
		public string Dir3 { get; set; }
		public string CodPais { get; set; }
		public string CodCiudad { get; set; }
		public string OrdenCompra { get; set; }
		public string CondPago { get; set; }
		public string Observaciones { get; set; }
		public string ObserFactura { get; set; }
		public string EstadoDocumento { get; set; }
        public string Usuario { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime FecModificacion { get; set; }
		public decimal TasaImpuesto { get; set; }
		public decimal MontoImpuesto { get; set; }
		public decimal MontoBruto { get; set; }
		public decimal MontoNeto { get; set; }
		public decimal MontoFlete { get; set; }
		public decimal PesoNeto { get; set; }
		public decimal TasaCambio { get; set; }
		public string IndConsignacion { get; set; }
		public string CodSucursal { get; set; }
		public string CodVendedor { get; set; }
        public string IndPedidoTrabajador { get; set; }
        //Campos Externos
        public string NumCarga { get; set; }
        public string NumFactura { get; set; }
        public decimal CantPedio { get; set; }
        public string CodZonaVentaNuevo { get; set; }
        public string CodZonaDespachoNuevo { get; set; }
        public string IndPagoTransferencia { get; set; }
    }

    public class VEPedidos : List<VEPedido>
    { }
}
