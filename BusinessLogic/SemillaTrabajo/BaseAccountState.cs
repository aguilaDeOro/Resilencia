

namespace BusinessLogic.SemillaTrabajo
{
    using DataAccess.Dtos;
    using DataAccess.EstadosCuenta;
    using DataAccess.SemillaTrabajo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BaseAccountState
    {
        private readonly IDealerAccountStateMacisa _dealerAccountStateStrategySelector;

        protected BaseAccountState(IDealerAccountStateMacisa dealerAccountStateStrategySelector)
        {
            this._dealerAccountStateStrategySelector = dealerAccountStateStrategySelector;
        }


        protected async Task<DTOEstadoCuentaRespuesta> GetAccountStatesList(DTOConsultaEstadoCuenta queryCreditLine)
        {
            var dealerAccountStatesList = await this._dealerAccountStateStrategySelector
                                                .GetAccountStatesList(queryCreditLine);

            return new DTOEstadoCuentaRespuesta
            {
                DTOHeader = dealerAccountStatesList.Data.DTOHeader,
                oEstadoCuenta = dealerAccountStatesList.Data.oEstadoCuenta,
                EstadosCuenta = dealerAccountStatesList.Data.EstadosCuenta
            };
        }

        protected AccountStateResponse<DTOEstadoCuentaRespuesta> CreateCustomResponse(bool success = true, string returnType = "", string message = "")
        {
            var accountStateResponse = new AccountStateResponse<DTOEstadoCuentaRespuesta>(success,
                                new DTOEstadoCuentaRespuesta()
                                {
                                    DTOHeader = new DTOHeader
                                    {
                                        CodigoRetorno = string.IsNullOrEmpty(returnType) ? ((int)HeaderEnum.Correcto).ToString() : returnType,
                                        DescRetorno = message,
                                    }
                                }, message);

            return accountStateResponse;
        }

        protected void UpdateCustomResponse(AccountStateResponse<DTOEstadoCuentaRespuesta> accountStateResponse, bool success, string returnType = "", string message = "")
        {
            accountStateResponse.Success = success;
            accountStateResponse.Message = string.IsNullOrEmpty(message) ? accountStateResponse.Message : message;
            accountStateResponse.Data.DTOHeader.CodigoRetorno = string.IsNullOrEmpty(returnType) ? accountStateResponse.Data.DTOHeader.CodigoRetorno : returnType;
            accountStateResponse.Data.DTOHeader.DescRetorno = string.IsNullOrEmpty(message) ? accountStateResponse.Data.DTOHeader.DescRetorno : message;
        }
    }
}
