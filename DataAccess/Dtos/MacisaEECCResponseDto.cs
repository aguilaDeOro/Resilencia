namespace DataAccess.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MacisaEECCResponseDto
    {
        public DTOHeader DTOHeader { get; set; }
        public string RUCDistribuidor { get; set; }
        public string RUCCliente { get; set; }
        public string NombreCliente { get; set; }
        public string FchEstadoCuenta { get; set; }
        public string FechaActualizacion { get; set; }
        public double LineaCreditoMN { get; set; }
        public double LineaCreditoME { get; set; }
        public decimal LineaDisponibleMN { get; set; }
        public decimal LineaDisponibleME { get; set; }
        public decimal CreditoUtilizadoMN { get; set; }
        public decimal CreditoUtilizadoME { get; set; }
        public decimal DeutaTotalMN { get; set; }
        public decimal DeutaTotalME { get; set; }
        public decimal DocsPorVencerMN { get; set; }
        public decimal DocsPorVencerME { get; set; }
        public decimal DocsVencidosMN { get; set; }
        public decimal DocsVencidosME { get; set; }
        public List<MacisaDetailEECCResponseDto> Detalle { get; set; }
    }
}
