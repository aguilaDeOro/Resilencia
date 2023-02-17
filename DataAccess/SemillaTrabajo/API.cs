namespace DataAccess.SemillaTrabajo
{
    public static class API
    {
        public static class Berio
        {
            public static string GetAccountStates(string serviceUrl, string dealerRuc, string clientRuc)
            {
                string url = serviceUrl;
                if (!string.IsNullOrEmpty(dealerRuc))
                    url = string.Concat(url, url.IndexOf("?") > 0 ? "&" : "?", "RucDistribuidor=", dealerRuc);

                if (!string.IsNullOrEmpty(clientRuc))
                    url = string.Concat(url, url.IndexOf("?") > 0 ? "&" : "?", "RucCliente=", clientRuc);

                return url;
            }
        }
        public static class Cemensa
        {
            public static string GetAccountStates(string baseUri, string clientRuc) =>
                $"{baseUri}?RucCliente={clientRuc}";
        }
        public static class LaViga
        {
            public static string GetLineCredit(string baseUri, string clientRuc) => 
                $"{baseUri}?rucCliente={clientRuc}";
            public static string GetAccountStatement(string baseUri, string clientRuc) =>
                $"{baseUri}?rucCliente={clientRuc}";
        }
        public static class Macisa
        {
            public static string GetAccountStates(string serviceUrl, string clientRuc)
            {
                string url = serviceUrl;
                if (!string.IsNullOrEmpty(clientRuc))
                    url = string.Concat(url, clientRuc);

                return url;
            }
        }

    }
}
