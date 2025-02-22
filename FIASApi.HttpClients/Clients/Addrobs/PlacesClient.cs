﻿using FIASApi.HttpClients.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.HttpClients.Clients.Addrobs
{
    public class PlacesClient : BaseHttpClient
    {
        public PlacesClient() : base("addrobs/places")
        {

        }

        public PlacesClient(HttpClient client) : base(client, "addrobs/places")
        {

        }

        public async Task<HttpResponseMessage> GetPlace(string aoguid)
        {
            return await _client.GetAsync($"place/?aoguid={aoguid}");
        }

        public async Task<HttpResponseMessage> GetPlaces(int? limit = null)
        {
            return await _client.GetAsync($"all/?limit={limit}");
        }

        public async Task<HttpResponseMessage> GetPlaces(string offname, string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", int? limit = null)
        {
            var parametersUrl = UrlBuilder.GetUrlWithParamsForHttpRequest(new Dictionary<string, string>()
                {
                    { "offname", offname },
                    { "regionCode", regionCode },
                    { "regionName", regionName },
                    { "areaCode", areaCode },
                    { "areaName", areaName },
                    { "cityCode", cityCode },
                    { "cityName", cityName },
                    { "limit", $"{limit}" }
                });

            return await _client.GetAsync($"search/{parametersUrl}");
        }
    }
}
