﻿using FIASApi.Model.Entities;
using FIASApi.Model.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FIASApi.Model.Repositories.EntityFramework
{
    public class EFPlacesRepository : IPlacesRepository
    {
        private FIASContext _context;

        public EFPlacesRepository(FIASContext context)
        {
            _context = context;
        }

        public VPlace GetPlace(string aoguid)
        {
            #region Проверка аргументов метода
            if (string.IsNullOrEmpty(aoguid))
            {
                throw new ArgumentNullException("aoguid", "Параметр не может быть пустым или длиной 0 символов."); 
            }
            #endregion

            return _context.VPlaces.SingleOrDefault(p => p.Aoguid == aoguid);
        }

        public IQueryable<VPlace> GetPlaces(int? limit = null)
        {
            if(limit != null ? limit > 0 : false)
            {
                return _context.VPlaces.Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VPlaces.AsNoTracking();
            }
        }

        public IQueryable<VPlace> GetPlaces(string offname, string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", int? limit = null)
        {
            #region Проверка аргументов метода
            if (offname == null)
            {
                throw new ArgumentNullException("offname", "Параметр не может быть пустым.");
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
            #endregion

            if (limit != null ? limit > 0 : false)
            {
                return _context.VPlaces.Where(p =>
                EF.Functions.Like(p.Offname, $"%{offname}%") &&
                (regionName.Length > 0 ? EF.Functions.Like(p.Regionname, $"%{regionName}%") : true) &&
                (areaName.Length > 0 ? EF.Functions.Like(p.Areaname, $"%{areaName}%") : true) &&
                (cityCode.Length > 0 ? EF.Functions.Like(p.Cityname, $"%{cityCode}%") : true) &&
                (regionCode.Length == 2 ? p.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? p.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? p.Citycode == cityCode : true)).Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VPlaces.Where(p =>
                EF.Functions.Like(p.Offname, $"%{offname}%") &&
                (regionName.Length > 0 ? EF.Functions.Like(p.Regionname, $"%{regionName}%") : true) &&
                (areaName.Length > 0 ? EF.Functions.Like(p.Areaname, $"%{areaName}%") : true) &&
                (cityCode.Length > 0 ? EF.Functions.Like(p.Cityname, $"%{cityCode}%") : true) &&
                (regionCode.Length == 2 ? p.Regioncode == regionCode : true) &&
                (areaCode.Length == 3 ? p.Areacode == areaCode : true) &&
                (cityCode.Length == 3 ? p.Citycode == cityCode : true)).AsNoTracking();
            }
        }
    }
}
