using FIASApi.Model;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIASApi.Api.Controllers.Addrobs
{
    [ApiController]
    [Route("api/addrobs/places/")]
    [Produces("application/json")]
    public class PlacesController : ControllerBase
    {
        private DataManager _dataManager;

        public PlacesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("place")]
        public async Task<IActionResult> GetPlace(string aoguid)
        {
            try
            {
                return Ok(await Task.Run<VPlace>(() => { return _dataManager.Places.GetPlace(aoguid); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPlaces(int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VPlace>>(() => { return _dataManager.Places.GetPlaces(limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetPlaces(string offname, string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VPlace>>(() => { return _dataManager.Places.GetPlaces(offname, regionCode, regionName, areaCode, areaName, cityCode, cityName, limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
