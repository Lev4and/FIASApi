using FIASApi.Model;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIASApi.Api.Controllers.Rooms
{
    [ApiController]
    [Route("api/rooms/flats/")]
    [Produces("application/json")]
    public class FlatsController : ControllerBase
    {
        private DataManager _dataManager;

        public FlatsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("flat")]
        public async Task<IActionResult> GetFlat(string roomguid)
        {
            try
            {
                return Ok(await Task.Run<VFlat>(() => { return _dataManager.Flats.GetFlat(roomguid); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetFlats(int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VFlat>>(() => { return _dataManager.Flats.GetFlats(limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetFlats(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string areaCode = "", string cityCode = "", string placeCode = "", string streetCode = "", int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VFlat>>(() => { return _dataManager.Flats.GetFlats(flatnumber, housenum, buildnum, strucnum, postalcode, regionCode, areaCode, cityCode, placeCode, streetCode, limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
