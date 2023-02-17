

namespace DataAccess.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DTOEstadoCuentaCAB
    {
        public decimal CodCredito { get; set; }
        public string RucDistribuidor { get; set; }
        public string RucCliente { get; set; }
        public string NombreCliente { get; set; }
        public DateTime? FechEstadoCuenta { get; set; }
        public DateTime? FechActualizacion { get; set; }
        public double LineaCreditoMN { get; set; }
        public double LineaCreditoME { get; set; }
        public decimal? LineaDisponibleMN { get; set; }
        public decimal? LineaDisponibleME { get; set; }
        public decimal? CreditoUtilizadoMN { get; set; }
        public decimal? CreditoUtilizadoME { get; set; }
        public decimal DeudaTotalMN { get; set; }
        public decimal DeudaTotalME { get; set; }
        public decimal DocsPorVencerMN { get; set; }
        public decimal DocsPorVencerME { get; set; }
        public decimal DocsVencidosMN { get; set; }
        public decimal DocsVencidosME { get; set; }
    }
}
