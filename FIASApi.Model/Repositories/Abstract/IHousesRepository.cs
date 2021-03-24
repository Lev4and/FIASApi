using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IHousesRepository
    {
        VHouse GetHouse(string houseguid);

        IQueryable<VHouse> GetHouses(int? limit = null);

        IQueryable<VHouse> GetHouses(string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", string streetCode = "", int? limit = null);
    }
}
