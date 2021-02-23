using FIASApi.Model.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FIASApi.Model.Repositories.EntityFramework
{
    public class EFAddrobRepository : IAddrobRepository
    {
        private FIASContext _context;

        public EFAddrobRepository(FIASContext context)
        {
            _context = context;
        }

        public IQueryable<dynamic> GetRegions()
        {
            return _context.VRegions.AsNoTracking();
        }

        public IQueryable<dynamic> GetAreas()
        {
            return _context.VAreas.AsNoTracking();
        }

        public IQueryable<dynamic> GetCities()
        {
            return _context.VCities.AsNoTracking();
        }

        public IQueryable<dynamic> GetPlaces()
        {
            return _context.VPlaces.AsNoTracking();
        }

        public IQueryable<dynamic> GetStreets()
        {
            return _context.VStreets.AsNoTracking();
        }
    }
}
