using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENInventario
{
    public class INProducto
    {
        public string CodEmpresa { get; set; }
        public string CodProducto { get; set; }
        public string CodInventario { get; set; }
        public string CodTipo { get; set; }
        public string CodCategoria { get; set; }
        public string DescProducto { get; set; }
		public DateTime FecRegistro { get; set; }
		public string CodUnidadMedida { get; set; }
		public decimal PrecioUnitario { get; set; }
		public decimal PrecioDivisa { get; set; }
		public decimal PesoUnidad { get; set; }
		public decimal MesesReposicion { get; set; }
		public decimal MesSeguridad { get; set; }
		public string Valorizado { get; set; }
		public string CondProducto { get; set; }
		public DateTime FecModificaPrecio { get; set; }
		public string UsuarioModificaPrecio { get; set; }
		public decimal PrecioDolarPropuesto { get; set; }
		public decimal PrecioBsPropuesto { get; set; }
		public string CodLinea { get; set; }
		public decimal ExistenciaReservada { get; set; }
		public decimal ExistenciaPedidos { get; set; }
		public decimal ExistenciaxReclasificar { get; set; }
        public string CodEquipo { get; set; }
        public string IndDotacion { get; set; }
        public string IndEspecial { get; set; }
        public string IndCesta { get; set; }
        public string IndFabricado { get; set; }
		public string Familia { get; set; }
		public decimal PesoNegro { get; set; }
		public string SubFamilia { get; set; }
        public string CodFamilia { get; set; }
        public string CodSubFamilia { get; set; }
		public int Id_Producto { get; set; }
		public decimal CantMaxSolicitar { get; set; }
		public int CodProductoTrab { get; set; }
        public decimal PrecioUnitarioTrab { get; set; }
        //Campos Externos
        public decimal ExistenciaFisica { get; set; }
        public decimal ExistenciaDisponible { get; set; }
        public string CodPlanta { get; set; }
        public string CodAlmacen { get; set; }
    }

    public class INProductos : List<INProducto>
    {}
}

