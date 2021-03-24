using FIASApi.Model;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIASApi.Api.Controllers.Houses
{
    [ApiController]
    [Route("api/houses/houses/")]
    [Produces("application/json")]
    public class HousesController : ControllerBase
    {
        private DataManager _dataManager;

        public HousesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("house")]
        public async Task<IActionResult> GetHouse(string houseguid)
        {
            try
            {
                return Ok(await Task.Run<VHouse>(() => { return _dataManager.Houses.GetHouse(houseguid); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetHouses(int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VHouse>>(() => { return _dataManager.Houses.GetHouses(limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetHouses(string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", string streetCode = "", int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VHouse>>(() => { return _dataManager.Houses.GetHouses(housenum, buildnum, strucnum, postalcode, regionCode, areaCode, cityCode, placeCode, streetCode, limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
