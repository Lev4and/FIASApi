using FIASApi.HttpClients.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.HttpClients.Clients.Addrobs
{
    public class AreasClient : BaseHttpClient
    {
        public AreasClient() : base("addrobs/areas")
        {

        }

        public AreasClient(HttpClient client) : base(client, "addrobs/areas")
        {

        }

        public async Task<HttpResponseMessage> GetArea(string aoguid)
        {
            return await _client.GetAsync($"area/?aoguid={aoguid}");
        }

        public async Task<HttpResponseMessage> GetAreas(int? limit = null)
        {
            return await _client.GetAsync($"all/?limit={limit}");
        }

        public async Task<HttpResponseMessage> GetAreas(string offname, string regionCode = "", string regionName = "", int? limit = null)
        {
            var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>()
                {
                    { "offname", offname },
                    { "regionCode", regionCode },
                    { "regionName", regionName },
                    { "limit", $"{limit}" }
                });

            return await _client.GetAsync($"search/{parametersUrl}");
        }
    }
}
