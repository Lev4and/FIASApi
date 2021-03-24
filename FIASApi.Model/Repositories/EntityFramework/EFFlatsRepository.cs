using FIASApi.Model.Entities;
using FIASApi.Model.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FIASApi.Model.Repositories.EntityFramework
{
    public class EFFlatsRepository : IFlatsRepository
    {
        private FIASContext _context;

        public EFFlatsRepository(FIASContext context)
        {
            _context = context;
        }

        public VFlat GetFlat(string roomguid)
        {
            #region Проверка аргументов метода
            if (string.IsNullOrEmpty(roomguid))
            {
                throw new ArgumentNullException("roomguid", "Параметр не может быть пустым или длиной 0 символов.");
            }
            #endregion

            return _context.VFlats.SingleOrDefault(r => r.Roomguid == roomguid);
        }

        public IQueryable<VFlat> GetFlats(int? limit = null)
        {
            if (limit != null ? limit > 0 : false)
            {
                return _context.VFlats.Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VFlats.AsNoTracking();
            }
        }

        public IQueryable<VFlat> GetFlats(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", string streetCode = "", int? limit = null)
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

            if (areaCode == null)
            {
                throw new ArgumentNullException("areaCode", "Параметр не может быть пустым.");
            }

            if (cityCode == null)
            {
                throw new ArgumentNullException("cityCode", "Параметр не может быть пустым.");
            }

            if (placeCode == null)
            {
                throw new ArgumentNullException("placeCode", "Параметр не может быть пустым.");
            }

            if (streetCode == null)
            {
                throw new ArgumentNullException("streetCode", "Параметр не может быть пустым.");
            }
            #endregion

            if(limit != null ? limit > 0 : false)
            {
                return _context.VFlats.Where(r =>
                (flatnumber.Length > 0 ? EF.Functions.Like(r.Flatnumber, $"%{flatnumber}%") : true) &&
                (housenum.Length > 0 ? r.Housenum == housenum : true) &&
                (buildnum.Length > 0 ? r.Buildnum == buildnum : true) &&
                (strucnum.Length > 0 ? r.Strucnum == strucnum : true) &&
                (postalcode.Length == 6 ? r.Postalcode == postalcode : true) &&
                (regionCode.Length == 2 ? r.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? r.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? r.Citycode == cityCode : true) &&
                (placeCode.Length == 3 ? r.Placecode == placeCode : true) &&
                (streetCode.Length == 4 ? r.Streetcode == streetCode : true)).Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VFlats.Where(r =>
                (flatnumber.Length > 0 ? EF.Functions.Like(r.Flatnumber, $"%{flatnumber}%") : true) &&
                (housenum.Length > 0 ? r.Housenum == housenum : true) &&
                (buildnum.Length > 0 ? r.Buildnum == buildnum : true) &&
                (strucnum.Length > 0 ? r.Strucnum == strucnum : true) &&
                (postalcode.Length == 6 ? r.Postalcode == postalcode : true) &&
                (regionCode.Length == 2 ? r.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? r.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? r.Citycode == cityCode : true) &&
                (placeCode.Length == 3 ? r.Placecode == placeCode : true) &&
                (streetCode.Length == 4 ? r.Streetcode == streetCode : true)).AsNoTracking();
            }
        }
    }
}
