using FIASApi.Model.Entities;
using FIASApi.Model.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FIASApi.Model.Repositories.EntityFramework
{
    public class EFCitiesRepository : ICitiesRepository
    {
        private FIASContext _context;

        public EFCitiesRepository(FIASContext context)
        {
            _context = context;
        }

        public VCity GetCity(string aoguid)
        {
            #region Проверка аргументов метода
            if (string.IsNullOrEmpty(aoguid))
            {
                throw new ArgumentNullException("aoguid", "Параметр не может быть пустым или длиной 0 символов.");
            }
            #endregion

            return _context.VCities.SingleOrDefault(c => c.Aoguid == aoguid);
        }

        public IQueryable<VCity> GetCities(int? limit = null)
        {
            if(limit != null ? limit > 0 : false)
            {
                return _context.VCities.Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VCities.AsNoTracking();
            }
        }

        public IQueryable<VCity> GetCities(string offname, string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", int? limit = null)
        {
            #region Проверка аргументов метода
            if (offname == null)
            {
                throw new ArgumentNullException("offname", "Параметр не может быть пустым.");
            }

            if(regionCode == null)
            {
                throw new ArgumentNullException("regionCode", "Параметр не может быть пустым.");
            }

            if(regionName == null)
            {
                throw new ArgumentNullException("regionName", "Параметр не может быть пустым.");
            }

            if(areaCode == null)
            {
                throw new ArgumentNullException("areaCode", "Параметр не может быть пустым.");
            }

            if(areaName == null)
            {
                throw new ArgumentNullException("areaName", "Параметр не может быть пустым.");
            }
            #endregion

            if (limit != null ? limit > 0 : false)
            {
                return _context.VCities.Where(c =>
                EF.Functions.Like(c.Offname, $"%{offname}%") &&
                (regionName.Length > 0 ? EF.Functions.Like(c.Regionname, $"%{regionName}%") : true) &&
                (areaName.Length > 0 ? EF.Functions.Like(c.Areaname, $"%{areaName}%") : true) &&
                (regionCode.Length == 2 ? c.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? c.Areacode == areaCode : true)).Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VCities.Where(c =>
                EF.Functions.Like(c.Offname, $"%{offname}%") &&
                (regionName.Length > 0 ? EF.Functions.Like(c.Regionname, $"%{regionName}%") : true) &&
                (areaName.Length > 0 ? EF.Functions.Like(c.Areaname, $"%{areaName}%") : true) &&
                (regionCode.Length == 2 ? c.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? c.Areacode == areaCode : true)).AsNoTracking();
            }
        }
    }
}
