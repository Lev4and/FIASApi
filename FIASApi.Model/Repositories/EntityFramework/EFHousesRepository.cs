using FIASApi.Model.Entities;
using FIASApi.Model.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FIASApi.Model.Repositories.EntityFramework
{
    public class EFHousesRepository : IHousesRepository
    {
        private FIASContext _context;

        public EFHousesRepository(FIASContext context)
        {
            _context = context;
        }

        public VHouse GetHouse(string houseguid)
        {
            #region Проверка аргументов метода
            if (string.IsNullOrEmpty(houseguid))
            {
                throw new ArgumentNullException("houseguid", "Параметр не может быть пустым или длиной 0 символов.");
            }
            #endregion

            return _context.VHouses.SingleOrDefault(h => h.Houseguid == houseguid);
        }

        public IQueryable<VHouse> GetHouses(int? limit = null)
        {
            if(limit != null ? limit > 0 : false)
            {
                return _context.VHouses.Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VHouses.AsNoTracking();
            }
        }

        public IQueryable<VHouse> GetHouses(string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", string streetCode = "", string streetName = "", int? limit = null)
        {
            #region Проверка аргументов метода
            if (housenum == null)
            {
                throw new ArgumentNullException("housenum", "Параметр не может быть пустым.");
            }

            if (buildnum == null)
            {
                throw new ArgumentNullException("buildnum", "Параметр не может быть пустым.");
            }

            if (strucnum == null)
            {
                throw new ArgumentNullException("strucnum", "Параметр не может быть пустым.");
            }

            if (regionCode == null)
            {
                throw new ArgumentNullException("regionCode", "Параметр не может быть пустым.");
            }

            if (regionName == null)
            {
                throw new ArgumentNullException("regionName", "Параметр не может быть пустым.");
            }

            if (areaCode == null)
            {
                throw new ArgumentNullException("areaCode", "Параметр не может быть пустым.");
            }

            if (areaName == null)
            {
                throw new ArgumentNullException("areaName", "Параметр не может быть пустым.");
            }

            if (cityCode == null)
            {
                throw new ArgumentNullException("cityCode", "Параметр не может быть пустым.");
            }

            if (cityName == null)
            {
                throw new ArgumentNullException("cityName", "Параметр не может быть пустым.");
            }

            if (placeCode == null)
            {
                throw new ArgumentNullException("placeCode", "Параметр не может быть пустым.");
            }

            if (placeName == null)
            {
                throw new ArgumentNullException("placeName", "Параметр не может быть пустым.");
            }

            if (streetCode == null)
            {
                throw new ArgumentNullException("streetCode", "Параметр не может быть пустым.");
            }

            if (streetName == null)
            {
                throw new ArgumentNullException("streetName", "Параметр не может быть пустым.");
            }
            #endregion

            if (limit != null ? limit > 0 : false)
            {
                return _context.VHouses.Where(h =>
                (housenum.Length > 0 ? EF.Functions.Like(h.Housenum, $"%{housenum}%") : true) &&
                (buildnum.Length > 0 ? EF.Functions.Like(h.Buildnum, $"%{buildnum}%") : true) &&
                (buildnum.Length > 0 ? EF.Functions.Like(h.Strucnum, $"%{strucnum}%") : true) &&
                (regionName.Length > 0 ? EF.Functions.Like(h.Regionname, $"%{regionName}%") : true) &&
                (areaName.Length > 0 ? EF.Functions.Like(h.Areaname, $"%{areaName}%") : true) &&
                (cityName.Length > 0 ? EF.Functions.Like(h.Cityname, $"%{cityName}%") : true) &&
                (placeName.Length > 0 ? EF.Functions.Like(h.Placename, $"%{placeName}%") : true) &&
                (streetName.Length > 0 ? EF.Functions.Like(h.Streetname, $"%{streetName}%") : true) &&
                (postalcode.Length == 6 ? h.Postalcode == postalcode : true) &&
                (regionCode.Length == 2 ? h.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? h.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? h.Citycode == cityCode : true) &&
                (placeCode.Length == 3 ? h.Placecode == placeCode : true) &&
                (streetCode.Length == 4 ? h.Streetcode == streetCode : true)).Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VHouses.Where(h =>
                (housenum.Length > 0 ? EF.Functions.Like(h.Housenum, $"%{housenum}%") : true) &&
                (buildnum.Length > 0 ? EF.Functions.Like(h.Buildnum, $"%{buildnum}%") : true) &&
                (buildnum.Length > 0 ? EF.Functions.Like(h.Strucnum, $"%{strucnum}%") : true) &&
                (regionName.Length > 0 ? EF.Functions.Like(h.Regionname, $"%{regionName}%") : true) &&
                (areaName.Length > 0 ? EF.Functions.Like(h.Areaname, $"%{areaName}%") : true) &&
                (cityName.Length > 0 ? EF.Functions.Like(h.Cityname, $"%{cityName}%") : true) &&
                (placeName.Length > 0 ? EF.Functions.Like(h.Placename, $"%{placeName}%") : true) &&
                (streetName.Length > 0 ? EF.Functions.Like(h.Streetname, $"%{streetName}%") : true) &&
                (postalcode.Length == 6 ? h.Postalcode == postalcode : true) &&
                (regionCode.Length == 2 ? h.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? h.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? h.Citycode == cityCode : true) &&
                (placeCode.Length == 3 ? h.Placecode == placeCode : true) &&
                (streetCode.Length == 4 ? h.Streetcode == streetCode : true)).AsNoTracking();
            }
        }
    }
}
