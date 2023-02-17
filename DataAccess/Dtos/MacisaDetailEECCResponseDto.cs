namespace DataAccess.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MacisaDetailEECCResponseDto
    {
        public string CodTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string CondPago { get; set; }
        public string FchDocumento { get; set; }
        public string FchVencimiento { get; set; }
        public decimal DiasVencimiento { get; set; }
        public string Moneda { get; set; }
        public string SectorProducto { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal PagoAcumulado { get; set; }
        public decimal Saldo { get; set; }
        public string DocReferencia { get; set; }
        public string FchEstadoCuenta { get; set; }
        public string DocEntry { get; set; }
        public string ObjType { get; set; }
    }
}
