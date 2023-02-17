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

        public DealerAccountStateMacisa(ILog logger, HttpClient httpClient, string urlPrefix)
            : base(httpClient, urlPrefix) => _log = logger;


        public async Task<AccountStateResponse<DTOEstadoCuentaRespuesta>> GetAccountStatesList(DTOConsultaEstadoCuenta queryCreditLine)
        {
            try
            {
                MacisaEECCResponseDto resultGetAccountStatesList = new MacisaEECCResponseDto();
                var retries = 1;

                var policyResult = await Policy.Handle<Exception>()
                    .WaitAndRetryAsync(
                        retryCount: 3,
                        sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        onRetry: (exception, timeSpan, context) =>
                        {
                            Console.WriteLine($"Exception: {exception.Message}");
                            Console.WriteLine($"Retry: {retries}");
                            retries++;
                        }
                    ).ExecuteAndCaptureAsync(async () =>
                    {
                        resultGetAccountStatesList = await base.GetAsync<MacisaEECCResponseDto>(
                            API.Macisa.GetAccountStates(base._urlPrefix, queryCreditLine.RucCliente));
                    });

                Console.WriteLine($"Result: {policyResult.Outcome.ToString()}");



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
                _log.EscribeLog(Log.CONST_APP_ERRLOG, MethodBase.GetCurrentMethod().Name,
                    $"{string.Format(Constantes.ERROR_QUERING_EECC, "Macisa")} : {ex.Message}");

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
