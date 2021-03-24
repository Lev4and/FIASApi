using FIASApi.Response.Service;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FIASApi.Response.RestClients
{
    public class BaseRestClient
    {
        protected private string _baseUrl;

        protected private HttpClient _client;
        protected private HttpContent _content;
        protected private HttpClientHandler _clientHandler;

        public BaseRestClient(string urlToController)
        {
            _baseUrl = ConfigRestClients.GetAddressServer(urlToController);

            _clientHandler = new HttpClientHandler();
            _clientHandler.AllowAutoRedirect = false;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            _client = new HttpClient(_clientHandler);

            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public BaseRestClient(HttpClient client, string urlToController)
        {
            ConfigRestClients.Protocol = client.BaseAddress.Scheme;
            ConfigRestClients.Port = $"{client.BaseAddress.Port}";
            ConfigRestClients.Domain = client.BaseAddress.Host;

            _baseUrl = ConfigRestClients.GetAddressServer(urlToController);

            _client = client;
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
