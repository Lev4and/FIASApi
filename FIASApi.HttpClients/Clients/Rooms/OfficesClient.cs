using FIASApi.HttpClients.UrlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FIASApi.HttpClients.Clients.Rooms
{
    public class OfficesClient : BaseHttpClient
    {
        public OfficesClient() : base("rooms/offices")
        {

        }

        public OfficesClient(HttpClient client) : base(client, "rooms/offices")
        {

        }

        public async Task<HttpResponseMessage> GetOffice(string roomguid)
        {
            try
            {
                return await _client.GetAsync($"office/?roomguid={roomguid}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetOffices(int? limit = null)
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

        public async Task<HttpResponseMessage> GetOffices(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", string streetCode = "", string streetName = "", int? limit = null)
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
