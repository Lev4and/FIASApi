using FIASApi.Model.Entities;
using FIASApi.Model.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FIASApi.Model.Repositories.EntityFramework
{
    public class EFOfficesRepository : IOfficesRepository
    {
        private FIASContext _context;

        public EFOfficesRepository(FIASContext context)
        {
            _context = context;
        }

        public VOffice GetOffice(string roomguid)
        {
            #region Проверка аргументов метода
            if (string.IsNullOrEmpty(roomguid))
            {
                throw new ArgumentNullException("roomguid", "Параметр не может быть пустым или длиной 0 символов.");
            }
            #endregion

            return _context.VOffices.SingleOrDefault(o => o.Roomguid == roomguid);
        }

        public IQueryable<VOffice> GetOffices(int? limit = null)
        {
            if (limit != null ? limit > 0 : false)
            {
                return _context.VOffices.Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VOffices.AsNoTracking();
            }
        }

        public IQueryable<VOffice> GetOffices(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", string streetCode = "", string streetName = "", int? limit = null)
        {
            #region Проверка аргументов метода
            if (flatnumber == null)
            {
                throw new ArgumentNullException("flatnumber", "Параметр не может быть пустым.");
            }

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
                return _context.VOffices.Where(o =>
                (flatnumber.Length > 0 ? EF.Functions.Like(o.Flatnumber, $"%{flatnumber}%") : true) &&
                (regionName.Length > 0 ? EF.Functions.Like(o.Regionname, $"%{regionName}%") : true) &&
                (areaName.Length > 0 ? EF.Functions.Like(o.Areaname, $"%{areaName}%") : true) &&
                (cityName.Length > 0 ? EF.Functions.Like(o.Cityname, $"%{cityName}%") : true) &&
                (placeName.Length > 0 ? EF.Functions.Like(o.Placename, $"%{placeName}%") : true) &&
                (streetName.Length > 0 ? EF.Functions.Like(o.Streetname, $"%{streetName}%") : true) &&
                (housenum.Length > 0 ? o.Housenum == housenum : true) &&
                (buildnum.Length > 0 ? o.Buildnum == buildnum : true) &&
                (strucnum.Length > 0 ? o.Strucnum == strucnum : true) &&
                (postalcode.Length == 6 ? o.Postalcode == postalcode : true) &&
                (regionCode.Length == 2 ? o.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? o.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? o.Citycode == cityCode : true) &&
                (placeCode.Length == 3 ? o.Placecode == placeCode : true) &&
                (streetCode.Length == 4 ? o.Streetcode == streetCode : true)).Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VOffices.Where(o =>
                (flatnumber.Length > 0 ? EF.Functions.Like(o.Flatnumber, $"%{flatnumber}%") : true) &&
                (regionName.Length > 0 ? EF.Functions.Like(o.Regionname, $"%{regionName}%") : true) &&
                (areaName.Length > 0 ? EF.Functions.Like(o.Areaname, $"%{areaName}%") : true) &&
                (cityName.Length > 0 ? EF.Functions.Like(o.Cityname, $"%{cityName}%") : true) &&
                (placeName.Length > 0 ? EF.Functions.Like(o.Placename, $"%{placeName}%") : true) &&
                (streetName.Length > 0 ? EF.Functions.Like(o.Streetname, $"%{streetName}%") : true) &&
                (housenum.Length > 0 ? o.Housenum == housenum : true) &&
                (buildnum.Length > 0 ? o.Buildnum == buildnum : true) &&
                (strucnum.Length > 0 ? o.Strucnum == strucnum : true) &&
                (postalcode.Length == 6 ? o.Postalcode == postalcode : true) &&
                (regionCode.Length == 2 ? o.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? o.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? o.Citycode == cityCode : true) &&
                (placeCode.Length == 3 ? o.Placecode == placeCode : true) &&
                (streetCode.Length == 4 ? o.Streetcode == streetCode : true)).AsNoTracking();
            }
        }
    }
}
