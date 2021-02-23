using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.Response.RestClients
{
    public class AddrobRestClient : BaseRestClient
    {
        public AddrobRestClient() : base("https://localhost:5001/api/addrob/")
        {

        }

        public Task<HttpResponseMessage> GetRegions()
        {
            try
            {
                return _client.GetAsync("regions");
            }
            catch
            {
                return null;
            }
        }

        public Task<HttpResponseMessage> GetAreas()
        {
            try
            {
                return _client.GetAsync("areas");
            }
            catch
            {
                return null;
            }
        }

        public Task<HttpResponseMessage> GetCities()
        {
            try
            {
                return _client.GetAsync("cities");
            }
            catch
            {
                return null;
            }
        }

        public Task<HttpResponseMessage> GetPlaces()
        {
            try
            {
                return _client.GetAsync("places");
            }
            catch
            {
                return null;
            }
        }

        public Task<HttpResponseMessage> GetStreets()
        {
            try
            {
                return _client.GetAsync("streets");
            }
            catch
            {
                return null;
            }
        }
    }
}
