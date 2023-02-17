using BusinessLogic.EstadosCuenta;
using DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.Http;

namespace API.PruebasPolly.NF452.Controllers
{
    public class EstadoCuentaController : ApiController
    {
        private readonly IAccountStateBusinessLogic _accountStateBusinessLogic;

        //private readonly IAppCache cache;


        public EstadoCuentaController(IAccountStateBusinessLogic accountStateBusinessLogic)
        {
            this._accountStateBusinessLogic = accountStateBusinessLogic;

            //cache = new CachingService() { DefaultCacheDuration = this.EECCMaxCacheDuration() };
        }

        [Route("v1/accountStates")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAccountStates([FromUri] DTOConsultaEstadoCuenta parametersQueryAccountState)
        {
            var accountStatesCachedResponse = await this._accountStateBusinessLogic.GetAsync(parametersQueryAccountState);

            //Func<Task<AccountStateResponse<DTOEstadoCuentaRespuesta>>> cacheableAsyncFunc
            //    = () => this._accountStateBusinessLogic.GetAsync(parametersQueryAccountState);

            //var accountStatesCachedResponse = await cache
            //    .GetOrAddAsync($"GetAccountStateDashboard-Post-{parametersQueryAccountState.RucDistribuidor}-" +
            //                                $"{parametersQueryAccountState.RucCliente}",
            //                                    cacheableAsyncFunc);

            if (accountStatesCachedResponse.Success)
            {
                return Ok(accountStatesCachedResponse);
            }

            return Content((HttpStatusCode)500, accountStatesCachedResponse);
        }
    }
}
