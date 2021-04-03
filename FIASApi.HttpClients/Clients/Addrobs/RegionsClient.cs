using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.HttpClients.Clients.Addrobs
{
    public class RegionsClient : BaseHttpClient
    {
        public RegionsClient() : base("addrobs/regions")
        {

        }

        public RegionsClient(HttpClient client) : base(client, "addrobs/regions")
        {

        }

        public async Task<HttpResponseMessage> GetRegion(string aoguid)
        {
            return await _client.GetAsync($"region/?aoguid={aoguid}");
        }

        public async Task<HttpResponseMessage> GetRegions(int? limit = null)
        {
            return await _client.GetAsync($"all/?limit={limit}");
        }

        public async Task<HttpResponseMessage> GetRegions(string offname, int? limit = null)
        {
            return await _client.GetAsync($"search/?offname={offname}&limit={limit}");
        }
    }
}
