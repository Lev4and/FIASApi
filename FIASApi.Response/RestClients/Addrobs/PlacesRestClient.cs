using FIASApi.Model.Entities;
using FIASApi.Response.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.Response.RestClients.Addrobs
{
    public class PlacesRestClient : BaseRestClient
    {
        public PlacesRestClient() : base("addrobs/places")
        {

        }

        public PlacesRestClient(HttpClient client) : base(client, "addrobs/places")
        {

        }

        public async Task<VPlace> GetPlace(string aoguid)
        {
            try
            {
                return await _client.GetAsync($"place/?aoguid={aoguid}").Result.Content.ReadAsAsync<VPlace>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VPlace>> GetPlaces(int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"all/?limit={limit}").Result.Content.ReadAsAsync<List<VPlace>>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VPlace>> GetPlaces(string offname, string regionCode = "", string areaCode = "", string cityCode = "", int? limit = null)
        {
            try
            {
                var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>() { { "offname", offname }, { "regionCode", regionCode }, { "areaCode", areaCode }, { "cityCode", cityCode }, { "limit", $"{limit}" } });

                return await _client.GetAsync($"search/{parametersUrl}").Result.Content.ReadAsAsync<List<VPlace>>();
            }
            catch
            {
                return null;
            }
        }
    }
}
