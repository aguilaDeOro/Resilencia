namespace DataAccess.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DTOEstadoCuentaRespuesta
    {
        public DTOEstadoCuentaRespuesta()
        {
            EstadosCuenta = new List<DTOEstadoCuenta>();
        }

        public DTOHeader DTOHeader { get; set; }
        public DTOEstadoCuenta oEstadoCuenta { get; set; }
        public List<DTOEstadoCuenta> EstadosCuenta { get; set; }
    }
}
