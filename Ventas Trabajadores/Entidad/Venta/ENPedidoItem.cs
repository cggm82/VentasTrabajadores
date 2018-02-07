using System;
using System.Linq;
using System.Text;
using System.ComponentModel; 
namespace ENventa
{
    public class VEPedidoItem
    {
        public string CodEmpresa { get; set; }
        public string CodTipoDocumento { get; set; }
		public string NumDocumento { get; set; }
        public string CodProducto { get; set; }
		public string DescProducto { get; set; }
		public string SerialProducto { get; set; }
		public string NumItem { get; set; }
		public decimal CantidadPedida { get; set; }
		public decimal CantidadDespachada { get; set; }
		public decimal PrecioVentas { get; set; }
		public decimal Descuento { get; set; }
        public DateTime FecDespacho { get; set; }
        public DateTime FecUltimoDespacho { get; set; }
        public DateTime FecRegistro { get; set; }
		public string IndReserva { get; set; }
		public decimal DesctoEspecial { get; set; }
		public decimal PesoUnidad { get; set; }
		public decimal Impuesto { get; set; }
		public decimal TasaImpuesto { get; set; }
        public decimal MontoNeto { get; set; }
		public string CondPago { get; set; }
		public decimal TasaCambio { get; set; }
		public decimal CantidadReservada { get; set; }
		public string CodLinea { get; set; }
        //Campos Externos
        public string CodProductoTrab { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioUnitarioTrab { get; set; }
        public decimal MontoBruto { get; set; }
        public string CodAlmacen { get; set; }
        public string CodPlanta { get; set; }
        public decimal PesoToneladas { get; set; }
        public decimal ExistenciaDisponible { get; set; }
    }

    public class VEPedidoItems :BindingList<VEPedidoItem>
    {}
}
