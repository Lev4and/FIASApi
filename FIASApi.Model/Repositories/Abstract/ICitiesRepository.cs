using FIASApi.Model.Entities;
using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface ICitiesRepository
    {
        VCity GetCity(string aoguid);

        IQueryable<VCity> GetCities(int? limit = null);

        IQueryable<VCity> GetCities(string offname, string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", int? limit = null);
    }
}
