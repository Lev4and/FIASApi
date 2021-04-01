using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IHousesRepository
    {
        VHouse GetHouse(string houseguid);

        IQueryable<VHouse> GetHouses(int? limit = null);

        IQueryable<VHouse> GetHouses(string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "",  string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", string streetCode = "", string streetName = "", int? limit = null);
    }
}
