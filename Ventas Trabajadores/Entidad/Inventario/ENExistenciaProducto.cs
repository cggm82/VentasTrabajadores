using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENInventario
{
    public class INExistenciasProducto
    {
        public string CodEmpresa { get; set; }
        public string CodPlanta { get; set; }
        public string CodAlmacen { get; set; }
        public string CodProducto { get; set; }
		public string DescProducto { get; set; }
		public decimal ExistenciaMesAnterior { get; set; }
		public decimal ExistenciaPorComprar { get; set; }
		public decimal ExistenciaCustodia { get; set; }
		public decimal ExistenciaFisica { get; set; }
		public decimal ExistenciaDisponible { get; set; }
		public decimal ExistenciaDisponibleExterior { get; set; }
		public decimal ExistenciaTransito { get; set; }
		public decimal ExistenciaPendEntrega { get; set; }
		public decimal ExistenciaenRequisicion { get; set; }
		public decimal ExistenciaenObservacion { get; set; }
		public decimal ExistenciaReclamo { get; set; }
		public decimal ExistenciaDañada { get; set; }
		public decimal ExistenciaConsignacion { get; set; }
		public decimal ExistenciaPrestada { get; set; }
		public decimal ExistenciadeMuestra { get; set; }
		public decimal ExistenciaporCortar { get; set; }
		public decimal ExistenciaPrecarga { get; set; }
		public decimal ExistenciaFacturada { get; set; }
		public decimal ExistenciaReservada { get; set; }
		public decimal ExistenciaRecibidaPrestamo { get; set; }
		public decimal UnidEntradasMes { get; set; }
		public decimal UnidConsumoMes { get; set; }
		public decimal UnidSalidasMes { get; set; }
		public decimal UnidCompradasMes { get; set; }
		public decimal BsConsumoMes { get; set; }
		public decimal UnidProducidasMes { get; set; }
		public decimal TonProducidasMes { get; set; }
		public decimal BsComprasMes { get; set; }
		public int ExistenciadeSeriales { get; set; }
		public decimal StockMinimo { get; set; }
		public decimal StockMaximo { get; set; }
		public decimal ExistenciaenProceso { get; set; }
		public decimal ExistenciaTransitoInt { get; set; }
    }

    public class INExistenciasProductos: List<INExistenciasProducto>
	{}
}
