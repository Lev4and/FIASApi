using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IStreetsRepository
    {
        VStreet GetStreet(string aoguid);

        IQueryable<VStreet> GetStreets(int? limit = null);

        IQueryable<VStreet> GetStreets(string offname, string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", int? limit = null);
    }
}
