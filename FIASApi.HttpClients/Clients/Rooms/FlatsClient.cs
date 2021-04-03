using FIASApi.HttpClients.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.HttpClients.Clients.Rooms
{
    public class FlatsClient : BaseHttpClient
    {
        public FlatsClient() : base("rooms/flats")
        {

        }

        public FlatsClient(HttpClient client) : base(client, "rooms/flats")
        {

        }

        public async Task<HttpResponseMessage> GetFlat(string roomguid)
        {
            return await _client.GetAsync($"flat/?roomguid={roomguid}");
        }

        public async Task<HttpResponseMessage> GetFlats(int? limit = null)
        {
            return await _client.GetAsync($"all/?limit={limit}");
        }

        public async Task<HttpResponseMessage> GetFlats(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", string streetCode = "", string streetName = "", int? limit = null)
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
    }
}
