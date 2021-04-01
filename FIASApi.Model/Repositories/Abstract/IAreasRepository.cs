using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IAreasRepository
    {
        VArea GetArea(string aoguid);

        IQueryable<VArea> GetAreas(int? limit = null);

        IQueryable<VArea> GetAreas(string offname, string regionCode = "", string regionName = "", int? limit = null);
    }
}
