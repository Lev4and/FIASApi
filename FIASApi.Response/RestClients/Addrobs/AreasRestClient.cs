using FIASApi.Model.Entities;
using FIASApi.Response.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.Response.RestClients.Addrobs
{
    public class AreasRestClient : BaseRestClient
    {
        public AreasRestClient() : base("addrobs/areas")
        {

        }

        public AreasRestClient(HttpClient client) : base (client, "addrobs/areas")
        {

        }

        public async Task<VArea> GetArea(string aoguid)
        {
            try
            {
                return await _client.GetAsync($"area/?aoguid={aoguid}").Result.Content.ReadAsAsync<VArea>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VArea>> GetAreas(int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"all/?limit={limit}").Result.Content.ReadAsAsync<List<VArea>>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VArea>> GetAreas(string offname, string regionCode = "", int? limit = null)
        {
            try
            {
                var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>() { { "offname", offname }, { "regionCode", regionCode }, { "limit", $"{limit}" } });

                return await _client.GetAsync($"search/{parametersUrl}").Result.Content.ReadAsAsync<List<VArea>>();
            }
            catch
            {
                return null;
            }
        }
    }
}
