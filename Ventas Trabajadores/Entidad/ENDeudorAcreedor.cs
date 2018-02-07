using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENGeneral
{
    public class GNDeudoresAcreedor
    {
        public string CliProveedor { get; set; }
        public string NomCliProveedor { get; set; }
		public string NomComercial { get; set; }
		public string NomBeneficiario { get; set; }
        public string TipoPersona { get; set; }
        public string Nacionalidad { get; set; }
        public string Dir1 { get; set; }
        public string Dir2 { get; set; }
        public string Dir3 { get; set; }
		public string Rif { get; set; }
		public string Nit { get; set; }
		public string Telefono1 { get; set; }
		public string Telefono2 { get; set; }
		public string Telefono3 { get; set; }
		public string Fax { get; set; }
		public string Celular { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string PagWeb { get; set; }
        public string CondPagoAcreedor { get; set; }
        public string CondPagoDeudor { get; set; }
        public string CodCiudad { get; set; } 
        public string CodZonaVenta { get; set; }
        public string CodZonaDespacho { get; set; }
        public string TipoCamion { get; set; }
        public string UnificaPedido { get; set; }
        public string Contribuyente { get; set; }
        public string ResidentePais { get; set; }
        public string ModoEnvio { get; set; }
        public string IndConsignacion { get; set; }
        public string NombreConsignacion { get; set; }
        public string Dir1Consignacion { get; set; }
        public string Dir2Consignacion { get; set; }
        public string Dir3Consignacion { get; set; }
        public string IndInscritoRif { get; set; }
		public string IndDomiciliado { get; set; }
        public string ContribuyenteEspecial { get; set; }
        public string Grupo { get; set; }
        public string DesenbolsoIva { get; set; }
        public string IndAplicaITF { get; set; }
        public string CodVendedor { get; set; }
        public string CodGrupoCliente { get; set; }
        public string CodZonaVentaNuevo { get; set; }
        public string CodZonaDespachoNuevo { get; set; }

        //Campos Externos
        public string CodPais { get; set; }
    }

     public class GNDeudoresAcreedores :List<GNDeudoresAcreedor>
     {}
}
