namespace DataAccess.EstadosCuenta
{
    using DataAccess.Dtos;
    using DataAccess.SemillaTrabajo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDealerAccountStateMacisa
    {
        Task<AccountStateResponse<DTOEstadoCuentaRespuesta>> GetAccountStatesList(DTOConsultaEstadoCuenta queryCreditLine);
    }
}
