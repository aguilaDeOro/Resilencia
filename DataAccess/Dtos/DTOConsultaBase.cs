namespace DataAccess.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DTOConsultaBase
    {
        public virtual string IdConsulta { get; set; }
        public virtual string RucDistribuidor { get; set; }
        public virtual string RucCliente { get; set; }
        public virtual string RucClientes { get; set; }
        public bool Todos { get; set; }
    }
}
