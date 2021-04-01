using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IFlatsRepository
    {
        VFlat GetFlat(string roomguid);

        IQueryable<VFlat> GetFlats(int? limit = null);

        IQueryable<VFlat> GetFlats(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", string streetCode = "", string streetName = "", int? limit = null);
    }
}
