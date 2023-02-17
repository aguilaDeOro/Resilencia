namespace BusinessLogic.EstadosCuenta
{
    using DataAccess.Dtos;
    using DataAccess.SemillaTrabajo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountStateBusinessLogic
        : IAccountStateBusinessLogic
    {
        private readonly IAccountStateMacisa _accountStateStrategySelector;

        public AccountStateBusinessLogic(IAccountStateMacisa accountStateStrategySelector)
        {
            this._accountStateStrategySelector = accountStateStrategySelector;
        }

        public async Task<AccountStateResponse<DTOEstadoCuentaRespuesta>> GetAsync(DTOConsultaEstadoCuenta criteria)
        {
            var consolidatedAccountState = await this._accountStateStrategySelector
                                                                .GetAccountState(criteria);

            return consolidatedAccountState;
        }
    }
}
