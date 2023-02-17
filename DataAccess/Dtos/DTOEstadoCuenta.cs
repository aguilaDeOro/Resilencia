

namespace DataAccess.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DTOEstadoCuenta
    {
        public DTOEstadoCuentaCAB Cabecera { get; set; }
        public List<DTOEstadoCuentaDET> Detalle { get; set; }
        public DTOEstadoCuenta()
        {
            Cabecera = new DTOEstadoCuentaCAB();
            Detalle = new List<DTOEstadoCuentaDET>();
        }
    }
}
