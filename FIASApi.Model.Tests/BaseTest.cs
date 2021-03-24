using FIASApi.Model.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FIASApi.Model.Tests
{
    public class BaseTest
    {
        private readonly FIASContext _context;
        private protected readonly DataManager _dataManager;

        public BaseTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FIASContext>();
            var options = optionsBuilder.UseSqlServer(@"Data Source=fiasapi.u1321851.plsk.regruhosting.ru;Initial Catalog=u1321851_FIAS;User ID=u1321851_Lev4and;Password=Andrey06032001!1973268450*;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options;

            _context = new FIASContext(options);
            _dataManager = new DataManager(new EFAreasRepository(_context), new EFCitiesRepository(_context), new EFFlatsRepository(_context), new EFHousesRepository(_context), new EFOfficesRepository(_context), new EFPlacesRepository(_context), new EFRegionsRepository(_context), new EFStreetsRepository(_context));
        }
    }
}
