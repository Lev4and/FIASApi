using FIASApi.HttpClients.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.HttpClients.Clients.Houses
{
    public class HousesClient : BaseHttpClient
    {
        public HousesClient() : base("houses/houses")
        {

        }

        public HousesClient(HttpClient client) : base(client, "houses/houses")
        {

        }

        public async Task<HttpResponseMessage> GetHouse(string houseguid)
        {
            try
            {
                return await _client.GetAsync($"house/?houseguid={houseguid}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetHouses(int? limit = null)
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

        public async Task<HttpResponseMessage> GetHouses(string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", string streetCode = "", string streetName = "", int? limit = null)
        {
            try
            {
                var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>() 
                { 
                    { "housenum", housenum }, 
                    { "buildnum", buildnum }, 
                    { "strucnum", strucnum }, 
                    { "postalcode", postalcode }, 
                    { "regionCode", regionCode },
                    { "regionName", regionName },
                    { "areaCode", areaCode },
                    { "areaName", areaName },
                    { "cityCode", cityCode },
                    { "cityName", cityName },
                    { "placeCode", placeCode },
                    { "placeName", placeName },
                    { "streetCode", streetCode },
                    { "streetName", streetName },
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
