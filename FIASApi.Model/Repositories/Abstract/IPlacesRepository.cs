using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IPlacesRepository
    {
        VPlace GetPlace(string aoguid);

        IQueryable<VPlace> GetPlaces(int? limit = null);

        IQueryable<VPlace> GetPlaces(string offname, string regionCode = "", string areaCode = "", string cityCode = "", int? limit = null);
    }
}
