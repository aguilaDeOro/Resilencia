namespace DataAccess.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DTODoccAplicados
    {
        public string NroDocumentoRef { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechDocumento { get; set; }
        public string Moneda { get; set; }
        public double Monto { get; set; }
    }
}
