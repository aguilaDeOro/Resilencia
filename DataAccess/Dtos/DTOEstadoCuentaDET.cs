

namespace DataAccess.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DTOEstadoCuentaDET
    {
        public DTOEstadoCuentaDET()
        {
            DocAplicados = new List<DTODoccAplicados>();
        }

        public string RucDistribuidor { get; set; }
        public string RucClienteProgresol { get; set; }
        public string FechEstadoCuenta { get; set; }
        public string NumeroItem { get; set; }
        public string CodTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string CondPago { get; set; }
        public DateTime FechDocumento { get; set; }
        public DateTime FechVencimiento { get; set; }
        public decimal DiasVencimiento { get; set; }
        public string Moneda { get; set; }
        public string SectorProducto { get; set; }
        public decimal MontoTotalLinea { get; set; }
        public decimal PagoAcumulado { get; set; }
        public decimal Saldo { get; set; }
        public string DocReferencia { get; set; }
        public string ObjType { get; set; }
        public string DocEntry { get; set; }

        public string NroClienteSAP { get; set; }
        public string FlagTicket { get; set; }

        public List<DTODoccAplicados> DocAplicados { get; set; }
    }
}
