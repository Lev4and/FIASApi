using FIASApi.Model.Entities;
using FIASApi.Model.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FIASApi.Model.Repositories.EntityFramework
{
    public class EFRegionsRepository : IRegionsRepository
    {
        private FIASContext _context;

        public EFRegionsRepository(FIASContext context)
        {
            _context = context;
        }

        public VRegion GetRegion(string aoguid)
        {
            #region Проверка аргументов метода
            if (string.IsNullOrEmpty(aoguid))
            {
                throw new ArgumentNullException("aoguid", "Параметр не может быть пустым или длиной 0 символов.");
            }
            #endregion

            return _context.VRegions.SingleOrDefault(r => r.Aoguid == aoguid);
        }

        public IQueryable<VRegion> GetRegions(int? limit = null)
        {
            if(limit != null ? limit > 0 : false)
            {
                return _context.VRegions.Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VRegions.AsNoTracking();
            }
        }

        public IQueryable<VRegion> GetRegions(string offname, int? limit = null)
        {
            #region Проверка аргументов метода
            if (offname == null)
            {
                throw new ArgumentNullException("offname", "Параметр не может быть пустым.");
            }
            #endregion

            if(limit != null ? limit > 0 : false)
            {
                return _context.VRegions.Where(r => EF.Functions.Like(r.Offname, $"%{offname}%")).Take((int)limit).AsNoTracking();
            }
            else
            {
                return _context.VRegions.Where(r => EF.Functions.Like(r.Offname, $"%{offname}%")).AsNoTracking();
            }
        }     
    }
}