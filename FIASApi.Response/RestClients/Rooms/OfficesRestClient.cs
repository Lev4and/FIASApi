using FIASApi.Model.Entities;
using FIASApi.Response.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.Response.RestClients.Rooms
{
    public class OfficesRestClient : BaseRestClient
    {
        public OfficesRestClient() : base("rooms/offices")
        {

        }

        public OfficesRestClient(HttpClient client) : base(client, "rooms/offices")
        {

        }

        public async Task<VOffice> GetOffice(string roomguid)
        {
            try
            {
                return await _client.GetAsync($"office/?roomguid={roomguid}").Result.Content.ReadAsAsync<VOffice>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VOffice>> GetOffices(int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"all/?limit={limit}").Result.Content.ReadAsAsync<List<VOffice>>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VOffice>> GetOffices(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", string streetCode = "", int? limit = null)
        {
            try
            {
                var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>() { { "housenum", housenum }, { "buildnum", buildnum }, { "strucnum", strucnum }, { "postalcode", postalcode }, { "regionCode", regionCode }, { "areaCode", areaCode }, { "cityCode", cityCode }, { "placeCode", placeCode }, { "streetCode", streetCode }, { "limit", $"{limit}" } });

                return await _client.GetAsync($"search/{parametersUrl}").Result.Content.ReadAsAsync<List<VOffice>>();
            }
            catch
            {
                return null;
            }
        }
    }
}
