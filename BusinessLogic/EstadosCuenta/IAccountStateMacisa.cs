namespace BusinessLogic.EstadosCuenta
{
    using DataAccess.Dtos;
    using DataAccess.SemillaTrabajo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAccountStateMacisa
    {
        Task<AccountStateResponse<DTOEstadoCuentaRespuesta>> GetAccountState(DTOConsultaEstadoCuenta queryCreditLine);
    }
}
