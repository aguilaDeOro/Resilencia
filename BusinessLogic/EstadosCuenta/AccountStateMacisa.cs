namespace BusinessLogic.EstadosCuenta
{
    using BusinessLogic.SemillaTrabajo;
    using DataAccess.Dtos;
    using DataAccess.EstadosCuenta;
    using DataAccess.SemillaTrabajo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using UNACEM.Common.Services;

    public class AccountStateMacisa
                : BaseAccountState, IAccountStateMacisa
    {
        private readonly ILog _logger;

        public AccountStateMacisa(IDealerAccountStateMacisa dealerAccountStateStrategySelector,
                                ILog logger)
            : base(dealerAccountStateStrategySelector)
        {
            _logger = logger;
        }

        public async Task<AccountStateResponse<DTOEstadoCuentaRespuesta>>
                GetAccountState(DTOConsultaEstadoCuenta queryCreditLine)
        {
            try
            {
                var threadAlls = new List<Task<DTOEstadoCuentaRespuesta>>();
                var accountStateResponse = base.CreateCustomResponse(message:
                        string.Format(Constantes.SUCCESS_QUERING_EECC, "Macisa"));

                if (!string.IsNullOrEmpty(queryCreditLine.RucCliente))
                {
                    threadAlls.Add(base.GetAccountStatesList(queryCreditLine));
                    await Task.WhenAll(threadAlls);

                    if (threadAlls.FirstOrDefault().Result.DTOHeader.CodigoRetorno == "0")
                        accountStateResponse.Data.oEstadoCuenta = threadAlls.FirstOrDefault().Result.oEstadoCuenta;

                    base.UpdateCustomResponse(accountStateResponse,
                        threadAlls.FirstOrDefault().Result.DTOHeader.CodigoRetorno == "0" ? true : false,
                        threadAlls.FirstOrDefault().Result.DTOHeader.CodigoRetorno,
                        threadAlls.FirstOrDefault().Result.DTOHeader.DescRetorno);
                }
                else if (!string.IsNullOrEmpty(queryCreditLine.RucClientes))
                {
                    var rucs = queryCreditLine.RucClientes.Split(',');
                    foreach (var ruc in rucs)
                    {
                        queryCreditLine.RucCliente = ruc;
                        threadAlls.Add(base.GetAccountStatesList(queryCreditLine));
                    }

                    await Task.WhenAll(threadAlls);

                    if (threadAlls.Select(r => r.Result).Where(w => w.oEstadoCuenta != null).Any())
                    {
                        if (threadAlls.Select(r => r.Result).Where(w => w.DTOHeader.CodigoRetorno == "-1").Any())
                            base.UpdateCustomResponse(accountStateResponse, true,
                                message: string.Format(Constantes.SUCESSS_WITH_ERROR_QUERING_EECC, "Macisa"));

                        accountStateResponse.Data.EstadosCuenta.AddRange(threadAlls.Select(r => r.Result)
                                                .Where(w => w.oEstadoCuenta != null).Select(ec => ec.oEstadoCuenta));
                    }
                    else
                        base.UpdateCustomResponse(accountStateResponse, false, ((int)HeaderEnum.Incorrecto).ToString(),
                                                    string.Format(Constantes.ERROR_QUERING_EECC, "Macisa"));
                }

                return accountStateResponse;
            }
            catch (Exception ex)
            {
                _logger.EscribeLog(Log.CONST_APP_ERRLOG,
                    typeof(AccountStateMacisa).Name + "." + MethodBase.GetCurrentMethod().Name,
                    $"{string.Format(Constantes.ERROR_QUERING_EECC, "Macisa")} : {ex}");

                return base.CreateCustomResponse(false, ((int)HeaderEnum.Incorrecto).ToString(),
                                                    string.Format(Constantes.ERROR_QUERING_EECC, "Macisa"));
            }
        }
    }
}
