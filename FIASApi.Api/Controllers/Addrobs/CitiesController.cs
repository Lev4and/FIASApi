using FIASApi.Model;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIASApi.Api.Controllers.Addrobs
{
    [ApiController]
    [Route("api/addrobs/cities/")]
    [Produces("application/json")]
    public class CitiesController : ControllerBase
    {
        private DataManager _dataManager;

        public CitiesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("city")]
        public async Task<IActionResult> GetCity(string aoguid)
        {
            try
            {
                return Ok(await Task.Run<VCity>(() => { return _dataManager.Cities.GetCity(aoguid); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCities(int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VCity>>(() => { return _dataManager.Cities.GetCities(limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCities(string offname, string regionCode = "", string areaCode = "", int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VCity>>(() => { return _dataManager.Cities.GetCities(offname, regionCode, areaCode, limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
