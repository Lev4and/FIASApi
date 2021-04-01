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
            try
            {
                return await _client.GetAsync($"street/?aoguid={aoguid}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetStreets(int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"all/?limit={limit}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetStreets(string offname, string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", int? limit = null)
        {
            try
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
            catch
            {
                return null;
            }
        }
    }
}
