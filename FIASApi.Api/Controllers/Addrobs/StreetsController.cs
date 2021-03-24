using FIASApi.Model;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIASApi.Api.Controllers.Addrobs
{
    [ApiController]
    [Route("api/addrobs/streets/")]
    [Produces("application/json")]
    public class StreetsController : ControllerBase
    {
        private DataManager _dataManager;

        public StreetsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("street")]
        public async Task<IActionResult> GetStreet(string aoguid)
        {
            try
            {
                return Ok(await Task.Run<VStreet>(() => { return _dataManager.Streets.GetStreet(aoguid); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetStreets(int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VStreet>>(() => { return _dataManager.Streets.GetStreets(limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetStreets(string offname, string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VStreet>>(() => { return _dataManager.Streets.GetStreets(offname, regionCode, areaCode, cityCode, placeCode, limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
