namespace DataAccess.SemillaTrabajo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Polly;
    using System.Reflection;
    using UNACEM.Common.Services;

    public abstract class BaserRequest
    {
        private readonly HttpClient _httpClient;
        private readonly ILog _log;

        protected string _securityToken = string.Empty;
        protected string _urlPrefix = string.Empty;

        private int retryCount;
        private int sleepDurationBasePow;

        public BaserRequest(ILog logger, HttpClient httpClient, string urlPrefix,
                            int retryCount, int sleepDurationBasePow)
        {
            if (String.IsNullOrEmpty(urlPrefix))
                throw new ArgumentNullException("urlPrefix");

            if (!urlPrefix.EndsWith("/"))
                urlPrefix = string.Concat(urlPrefix, "/");

            this._httpClient = httpClient;
            this._log = logger;

            this._urlPrefix = urlPrefix;

            this.retryCount = retryCount;
            this.sleepDurationBasePow = sleepDurationBasePow;
        }


        protected async Task<T> GetAsync<T>(string url, string getMethodActionDetail)
        {
            string executionScope = typeof(BaserRequest).Name + "." + MethodBase.GetCurrentMethod().Name;
            byte[] response = null; 
            var retries = 1;
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var policyResult = await Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(
                    retryCount: this.retryCount,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(this.sleepDurationBasePow, retryAttempt)),
                    onRetry: (exception, timeSpan, context) =>
                    {
                        _log.EscribeLog(Log.CONST_APP_ERRLOG, executionScope, string.Format("Excepción de intento {0} : {1}", getMethodActionDetail, exception.Message));
                        _log.EscribeLog(Log.CONST_APP_ERRLOG, executionScope, string.Format("Reintento {0} : {1}", getMethodActionDetail, retries));

                        retries++;
                    }
                ).ExecuteAndCaptureAsync(async () =>
                {
                    response = await this._httpClient.GetByteArrayAsync(url);
                });


            if (policyResult.Outcome == OutcomeType.Failure)
                throw new Exception(policyResult.FinalException.ToString(), policyResult.FinalException);

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(response)));
        }


        protected async Task GetAsync(string url)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            await httpClient.GetStringAsync(url);
        }

        public void RefreshSecurityToken(string securityToken)
        {
            this._securityToken = securityToken;
        }
    }
}
