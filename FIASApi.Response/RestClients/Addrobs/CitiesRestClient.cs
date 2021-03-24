using FIASApi.Model.Entities;
using FIASApi.Response.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.Response.RestClients.Addrobs
{
    public class CitiesRestClient : BaseRestClient
    {
        public CitiesRestClient() : base("addrobs/cities")
        {

        }

        public CitiesRestClient(HttpClient client) : base(client, "addrobs/cities")
        {

        }

        public async Task<VCity> GetCity(string aoguid)
        {
            try
            {
                return await _client.GetAsync($"city/?aoguid={aoguid}").Result.Content.ReadAsAsync<VCity>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VCity>> GetCities(int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"all/?limit={limit}").Result.Content.ReadAsAsync<List<VCity>>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VCity>> GetCities(string offname, string regionCode = "", string areaCode = "", int? limit = null)
        {
            try
            {
                var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>() { { "offname", offname }, { "regionCode", regionCode }, { "areaCode", areaCode }, { "limit", $"{limit}" } });

                return await _client.GetAsync($"search/{parametersUrl}").Result.Content.ReadAsAsync<List<VCity>>();
            }
            catch
            {
                return null;
            }
        }
    }
}
