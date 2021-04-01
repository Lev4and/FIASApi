using FIASApi.Model.Entities;
using FIASApi.Model.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FIASApi.Model.Repositories.EntityFramework
{
    public class EFAreasRepository : IAreasRepository
    {
        private FIASContext _context;

        public EFAreasRepository(FIASContext context)
        {
            _context = context;
        }

        public VArea GetArea(string aoguid)
        {
            #region Проверка аргументов метода
            if (string.IsNullOrEmpty(aoguid))
            {
                throw new ArgumentNullException("aoguid", "Параметр не может быть пустым или длиной 0 символов.");
            }
            #endregion

            return _context.VAreas.SingleOrDefault(a => a.Aoguid == aoguid);
        }

        public IQueryable<VArea> GetAreas(int? limit = null)
        {
            if(limit != null ? limit > 0 : false)
            {
                return _context.VAreas.Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VAreas.AsNoTracking();
            }
        }

        public IQueryable<VArea> GetAreas(string offname, string regionCode = "", string regionName = "", int? limit = null)
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
            #endregion

            if(limit != null ? limit > 0 : false)
            {
                return _context.VAreas.Where(a =>
                EF.Functions.Like(a.Offname, $"%{offname}%") &&
                (regionName.Length > 0 ? EF.Functions.Like(a.Regionname, $"%{regionName}%") : true) &&
                (regionCode.Length == 2 ? a.Regioncode == regionCode : true)).Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VAreas.Where(a =>
                EF.Functions.Like(a.Offname, $"%{offname}%") &&
                (regionName.Length > 0 ? EF.Functions.Like(a.Regionname, $"%{regionName}%") : true) &&
                (regionCode.Length == 2 ? a.Regioncode == regionCode : true)).AsNoTracking();
            }
        }
    }
}
