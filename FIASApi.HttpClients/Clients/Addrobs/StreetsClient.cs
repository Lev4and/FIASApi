using FIASApi.HttpClients.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.HttpClients.Clients.Addrobs
{
    public class StreetsClient : BaseHttpClient
    {
        public StreetsClient() : base("addrobs/streets")
        {

        }

        public StreetsClient(HttpClient client) : base(client, "addrobs/streets")
        {

        }

        public async Task<HttpResponseMessage> GetStreet(string aoguid)
        {
            return await _client.GetAsync($"street/?aoguid={aoguid}");
        }

        public async Task<HttpResponseMessage> GetStreets(int? limit = null)
        {
            return await _client.GetAsync($"all/?limit={limit}");
        }

        public async Task<HttpResponseMessage> GetStreets(string offname, string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", int? limit = null)
        {
            var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>()
                {
                    { "offname", offname },
                    { "regionCode", regionCode },
                    { "regionName", regionName },
                    { "areaCode", areaCode },
                    { "areaName", areaName },
                    { "cityCode", cityCode },
                    { "cityName", cityName },
                    { "placeCode", placeCode },
                    { "placeName", placeName },
                    { "limit", $"{limit}" }
                });

            return await _client.GetAsync($"search/{parametersUrl}");
        }
    }
}
