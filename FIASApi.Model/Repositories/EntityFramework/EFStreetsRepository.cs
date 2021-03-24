using FIASApi.Model.Entities;
using FIASApi.Model.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FIASApi.Model.Repositories.EntityFramework
{
    public class EFStreetsRepository : IStreetsRepository
    {
        private FIASContext _context;

        public EFStreetsRepository(FIASContext context)
        {
            _context = context;
        }

        public VStreet GetStreet(string aoguid)
        {
            #region Проверка аргументов метода
            if (string.IsNullOrEmpty(aoguid))
            {
                throw new ArgumentNullException("aoguid", "Параметр не может быть пустым или длиной 0 символов.");
            }
            #endregion

            return _context.VStreets.SingleOrDefault(s => s.Aoguid == aoguid);
        }

        public IQueryable<VStreet> GetStreets(int? limit = null)
        {
            if(limit != null ? limit > 0 : false)
            {
                return _context.VStreets.Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VStreets.AsNoTracking();
            }
        }

        public IQueryable<VStreet> GetStreets(string offname, string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", int? limit = null)
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

            if(areaCode == null)
            {
                throw new ArgumentNullException("areaCode", "Параметр не может быть пустым.");
            }

            if(cityCode == null)
            {
                throw new ArgumentNullException("cityCode", "Параметр не может быть пустым.");
            }

            if(placeCode == null)
            {
                throw new ArgumentNullException("placeCode", "Параметр не может быть пустым.");
            }
            #endregion

            if(limit != null ? limit > 0 : false)
            {
                return _context.VStreets.Where(s =>
                EF.Functions.Like(s.Offname, $"%{offname}%") &&
                (regionCode.Length == 2 ? s.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? s.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? s.Citycode == cityCode : true) &&
                (placeCode.Length == 3 ? s.Placecode == placeCode : true)).Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VStreets.Where(s =>
                EF.Functions.Like(s.Offname, $"%{offname}%") &&
                (regionCode.Length == 2 ? s.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? s.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? s.Citycode == cityCode : true) &&
                (placeCode.Length == 3 ? s.Placecode == placeCode : true)).AsNoTracking();
            }
        }
    }
}
