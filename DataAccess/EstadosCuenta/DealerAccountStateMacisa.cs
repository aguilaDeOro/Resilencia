﻿namespace DataAccess.EstadosCuenta
{
    using AutoMapper;
    using DataAccess.Dtos;
    using DataAccess.SemillaTrabajo;
    using Polly;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using UNACEM.Common.Services;


    public class DealerAccountStateMacisa
          : BaserRequest, IDealerAccountStateMacisa
    {
        private readonly ILog _log;


        public DealerAccountStateMacisa(ILog logger, HttpClient httpClient, string urlPrefix, 
                                        int retryCount, int sleepDurationBasePow)
            : base(logger, httpClient, urlPrefix, retryCount, sleepDurationBasePow) => this._log = logger;


        public async Task<AccountStateResponse<DTOEstadoCuentaRespuesta>> GetAccountStatesList(DTOConsultaEstadoCuenta queryCreditLine)
        {
            try
            {
                var resultGetAccountStatesList = await base.GetAsync<MacisaEECCResponseDto>(
                    API.Macisa.GetAccountStates(base._urlPrefix, queryCreditLine.RucCliente),
                    string.Format(Constantes.DETAIL_METHOD_GET_ACCOUNT_STATES, Constantes.DEALER_MACISA));
                var accountStates = Mapper.Map<DTOEstadoCuenta>(resultGetAccountStatesList);

                return new AccountStateResponse<DTOEstadoCuentaRespuesta>(true,
                    new DTOEstadoCuentaRespuesta
                    {
                        DTOHeader = new DTOHeader
                        {
                            CodigoRetorno = ((int)HeaderEnum.Correcto).ToString(),
                            DescRetorno = string.Format(Constantes.SUCCESS_QUERING_EECC, "Macisa")
                        },
                        oEstadoCuenta = accountStates
                    },
                    "Consulta de estados de cuenta del distribuidor Macisa, finalizada con éxito.");
            }
            catch (Exception ex)
            {
                _log.EscribeLog(Log.CONST_APP_ERRLOG, typeof(DealerAccountStateMacisa).Name + "." + MethodBase.GetCurrentMethod().Name,
                    $"{string.Format(Constantes.ERROR_QUERING_EECC, "Macisa")} : {ex}");

                return new AccountStateResponse<DTOEstadoCuentaRespuesta>(false,
                    new DTOEstadoCuentaRespuesta()
                    {
                        DTOHeader = new DTOHeader
                        {
                            CodigoRetorno = ((int)HeaderEnum.Incorrecto).ToString(),
                            DescRetorno = string.Format(Constantes.ERROR_QUERING_EECC, "Macisa")
                        },
                        //oEstadoCuenta = new DTOEstadoCuenta()
                    },
                    "Fallo la consulta de estados de cuenta del distribuidor Macisa.");
            }
        }
    }
}
