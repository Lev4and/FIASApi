using FIASApi.HttpClients.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.HttpClients.Clients.Addrobs
{
    public class CitiesClient : BaseHttpClient
    {
        public CitiesClient() : base("addrobs/cities")
        {

        }

        public CitiesClient(HttpClient client) : base(client, "addrobs/cities")
        {

        }

        public async Task<HttpResponseMessage> GetCity(string aoguid)
        {
            return await _client.GetAsync($"city/?aoguid={aoguid}");
        }

        public async Task<HttpResponseMessage> GetCities(int? limit = null)
        {
            return await _client.GetAsync($"all/?limit={limit}");
        }

        public async Task<HttpResponseMessage> GetCities(string offname, string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", int? limit = null)
        {
            var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>()
                {
                    { "offname", offname },
                    { "regionCode", regionCode },
                    { "regionName", regionName },
                    { "areaCode", areaCode },
                    { "areaName", areaName },
                    { "limit", $"{limit}" }
                });

            return await _client.GetAsync($"search/{parametersUrl}");
        }
    }
}
