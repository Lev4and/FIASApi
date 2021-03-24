using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IOfficesRepository
    {
        VOffice GetOffice(string roomguid);

        IQueryable<VOffice> GetOffices(int? limit = null);

        IQueryable<VOffice> GetOffices(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", string streetCode = "", int? limit = null);
    }
}
