using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENPersonal
{
    public class PEInformacionLaboral
    {
        public string CodEmpresa { get; set; }
		public string Cedula { get; set; }
		public string CodPlanta { get; set; }
		public string CodTrabajador { get; set; }
		public string Nombre { get; set; }
		public string Carnet { get; set; }
		public string TipoCarnet { get; set; }
		public string TipoTrabajador { get; set; }
		public string TipoNomina { get; set; }
		public string FormadePago { get; set; }
		public string FrecuenciaPago { get; set; }
		public string NumCuenta { get; set; }
		public DateTime FecIngresoGrupo { get; set; }
		public DateTime FecIngresoEmp { get; set; }
		public DateTime FecIngresoSSO { get; set; }
		public DateTime FecProximaVac { get; set; }
		public DateTime FecRetiro { get; set; }
		public DateTime FecUltimoSalario { get; set; }
		public decimal  SueldoA { get; set; }
		public decimal  SueldoB { get; set; }
		public decimal SueldoVacaciones { get; set; }
		public string Sindicalizado { get; set; }
		public string CodDependencia { get; set; }
		public string CodCargo { get; set; }
		public string CodCentroCosto { get; set; }
		public string TurnoNomina { get; set; }
		public string TurnoActual { get; set; }
		public string Rotacion { get; set; }
		public string CondTrabajador { get; set; }
		public string CodSupervisor { get; set; }
		public string GrupoSabado { get; set; }
		public string CodMovimiento { get; set; }
		public decimal PorcImpuesto { get; set; }
		public string IndPromedio { get; set; }
		public DateTime FecDotacion { get; set; }
		public string ComidaDecreto { get; set; }
		public string EstatusDotacion { get; set; }
		public string DocumentoDotacion { get; set; }
		public DateTime UltimaDotacion { get; set; }
		public string AccesoalGrupo { get; set; }
		public string PagosxTurnos { get; set; }
		public int SemanasdelMes { get; set; }
		public int SemanasdelMesVacaciones { get; set; }
		public decimal DiasFideicomiso { get; set; }
		public DateTime FecUltimaVac { get; set; }
		public string EnviadoCentral { get; set; }
		public string NivelTrab { get; set; }
		public DateTime FecRegistro { get; set; }
		public string CodDependenciaDefecto { get; set; }
		public string IndDiscapacidad { get; set; }
		public string TipoDiscapacidad { get; set; }
		public string Observacion { get; set; }
		public string NumCuentaFideicomiso { get; set; }
		public string Rif { get; set; }
		public string NumCuentaFideResp { get; set; }
		public string IndTarjetaTodoTicket { get; set; }
		public string EmailEmpresa { get; set; }
		public string IndContrato { get; set; }
		public DateTime FecCulminacionContrato { get; set; }
		public string JornadaLaboral { get; set; }
		public string IndPatio { get; set; }
        
	}

	public class PEInformacionLaborals: List<PEInformacionLaboral>
	{}

}
