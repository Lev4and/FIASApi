using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IStreetsRepository
    {
        VStreet GetStreet(string aoguid);

        IQueryable<VStreet> GetStreets(int? limit = null);

        IQueryable<VStreet> GetStreets(string offname, string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", int? limit = null);
    }
}
