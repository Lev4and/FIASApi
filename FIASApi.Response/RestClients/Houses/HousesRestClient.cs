using FIASApi.Model.Entities;
using FIASApi.Response.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.Response.RestClients.Houses
{
    public class HousesRestClient : BaseRestClient
    {
        public HousesRestClient() : base("houses/houses")
        {

        }

        public HousesRestClient(HttpClient client) : base(client, "houses/houses")
        {

        }

        public async Task<VHouse> GetHouse(string houseguid)
        {
            try
            {
                return await _client.GetAsync($"house/?houseguid={houseguid}").Result.Content.ReadAsAsync<VHouse>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VHouse>> GetHouses(int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"all/?limit={limit}").Result.Content.ReadAsAsync<List<VHouse>>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VHouse>> GetHouses(string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", string streetCode = "", int? limit = null)
        {
            try
            {
                var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>() { { "housenum", housenum }, { "buildnum", buildnum }, { "strucnum", strucnum }, { "postalcode", postalcode }, { "regionCode", regionCode }, { "areaCode", areaCode }, { "cityCode", cityCode }, { "placeCode", placeCode }, { "streetCode", streetCode }, { "limit", $"{limit}" } });

                return await _client.GetAsync($"search/{parametersUrl}").Result.Content.ReadAsAsync<List<VHouse>>();
            }
            catch
            {
                return null;
            }
        }
    }
}
