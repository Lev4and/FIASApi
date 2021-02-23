using System.Linq;

namespace FIASApi.Model.Repositories.Abstract
{
    public interface IAddrobRepository
    {
        IQueryable<dynamic> GetRegions();

        IQueryable<dynamic> GetAreas();

        IQueryable<dynamic> GetCities();

        IQueryable<dynamic> GetPlaces();

        IQueryable<dynamic> GetStreets();
    }
}
