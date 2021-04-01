using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.HttpClients.Clients.Addrobs
{
    public class RegionsClients : BaseHttpClient
    {
        public RegionsClients() : base("addrobs/regions")
        {

        }

        public RegionsClients(HttpClient client) : base(client, "addrobs/regions")
        {

        }

        public async Task<HttpResponseMessage> GetRegion(string aoguid)
        {
            try
            {
                return await _client.GetAsync($"region/?aoguid={aoguid}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetRegions(int? limit = null)
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

        public async Task<HttpResponseMessage> GetRegions(string offname, int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"search/?offname={offname}&limit={limit}");
            }
            catch
            {
                return null;
            }
        }
    }
}
