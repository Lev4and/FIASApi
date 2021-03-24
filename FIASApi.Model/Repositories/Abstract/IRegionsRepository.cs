using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IRegionsRepository
    {
        VRegion GetRegion(string aoguid);

        IQueryable<VRegion> GetRegions(int? limit = null);

        IQueryable<VRegion> GetRegions(string offname, int? limit = null);
    }
}
