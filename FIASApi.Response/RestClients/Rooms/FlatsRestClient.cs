using FIASApi.Model.Entities;
using FIASApi.Response.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.Response.RestClients.Rooms
{
    public class FlatsRestClient : BaseRestClient
    {
        public FlatsRestClient() : base("rooms/flats")
        {

        }

        public FlatsRestClient(HttpClient client) : base(client, "rooms/flats")
        {

        }

        public async Task<VFlat> GetFlat(string roomguid)
        {
            try
            {
                return await _client.GetAsync($"flat/?roomguid={roomguid}").Result.Content.ReadAsAsync<VFlat>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VFlat>> GetFlats(int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"all/?limit={limit}").Result.Content.ReadAsAsync<List<VFlat>>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VFlat>> GetFlats(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", string streetCode = "", int? limit = null)
        {
            try
            {
                var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>() { { "housenum", housenum }, { "buildnum", buildnum }, { "strucnum", strucnum }, { "postalcode", postalcode }, { "regionCode", regionCode }, { "areaCode", areaCode }, { "cityCode", cityCode }, { "placeCode", placeCode }, { "streetCode", streetCode }, { "limit", $"{limit}" } });

                return await _client.GetAsync($"search/{parametersUrl}").Result.Content.ReadAsAsync<List<VFlat>>();
            }
            catch
            {
                return null;
            }
        }
    }
}
