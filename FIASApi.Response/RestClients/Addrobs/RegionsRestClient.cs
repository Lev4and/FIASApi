using FIASApi.Model.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FIASApi.Response.RestClients.Addrobs
{
    public class RegionsRestClient : BaseRestClient
    {
        public RegionsRestClient() : base("addrobs/regions")
        {

        }

        public RegionsRestClient(HttpClient client) : base(client, "addrobs/regions")
        {

        }

        public async Task<VRegion> GetRegion(string aoguid)
        {
            try
            {
                return await _client.GetAsync($"region/?aoguid={aoguid}").Result.Content.ReadAsAsync<VRegion>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VRegion>> GetRegions(int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"all/?limit={limit}").Result.Content.ReadAsAsync<List<VRegion>>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<VRegion>> GetRegions(string offname, int? limit = null)
        {
            try
            {
                return await _client.GetAsync($"search/?offname={offname}&limit={limit}").Result.Content.ReadAsAsync<List<VRegion>>();
            }
            catch
            {
                return null;
            }
        }
    }
}
