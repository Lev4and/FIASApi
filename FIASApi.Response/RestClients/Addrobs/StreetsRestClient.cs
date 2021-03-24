using FIASApi.Model.Entities;
using FIASApi.Response.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.Response.RestClients.Addrobs
{
    public class StreetsRestClient : BaseRestClient
    {
        public StreetsRestClient() : base("addrobs/streets")
        {

        }

        public StreetsRestClient(HttpClient client) : base(client, "addrobs/streets")
        {

        }

        public async Task<VStreet> GetStreet(string aoguid)
        {
            try
            {
                return await _client.GetAsync($"street/?aoguid={aoguid}").Result.Content.ReadAsAsync<VStreet>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VStreet>> GetStreets(int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"all/?limit={limit}").Result.Content.ReadAsAsync<List<VStreet>>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VStreet>> GetStreets(string offname, string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", int? limit = null)
        {
            try
            {
                var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>() { { "offname", offname }, { "regionCode", regionCode }, { "areaCode", areaCode }, { "cityCode", cityCode }, { "placeCode", placeCode }, { "limit", $"{limit}" } });

                return await _client.GetAsync($"search/{parametersUrl}").Result.Content.ReadAsAsync<List<VStreet>>();
            }
            catch
            {
                return null;
            }
        }
    }
}
