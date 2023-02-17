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

    public abstract class BaserRequest
    {
        protected string _securityToken = string.Empty;
        protected string _urlPrefix = string.Empty;

        private readonly HttpClient _httpClient;

        public BaserRequest(HttpClient httpClient, string urlPrefix)
        {
            if (String.IsNullOrEmpty(urlPrefix))
                throw new ArgumentNullException("urlPrefix");

            if (!urlPrefix.EndsWith("/"))
                urlPrefix = string.Concat(urlPrefix, "/");

            this._httpClient = httpClient;
            this._urlPrefix = urlPrefix;
        }


        protected async Task<T> GetAsync<T>(string url)
        {
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await this._httpClient.GetByteArrayAsync(url);
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
