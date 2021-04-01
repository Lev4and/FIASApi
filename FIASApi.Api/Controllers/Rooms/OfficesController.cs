using FIASApi.Model;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIASApi.Api.Controllers.Rooms
{
    [ApiController]
    [Route("api/rooms/offices/")]
    [Produces("application/json")]
    public class OfficesController : ControllerBase
    {
        private DataManager _dataManager;

        public OfficesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("office")]
        public async Task<IActionResult> GetOffice(string roomguid)
        {
            try
            {
                return Ok(await Task.Run<VOffice>(() => { return _dataManager.Offices.GetOffice(roomguid); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetOffices(int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VOffice>>(() => { return _dataManager.Offices.GetOffices(limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetOffices(string flatnumber = "", string housenum = "", string buildnum = "", string strucnum = "", string postalcode = "", string regionCode = "", string regionName = "", string areaCode = "", string areaName = "", string cityCode = "", string cityName = "", string placeCode = "", string placeName = "", string streetCode = "", string streetName = "", int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VOffice>>(() => { return _dataManager.Offices.GetOffices(flatnumber, housenum, buildnum, strucnum, postalcode, regionCode, regionName, areaCode, areaName, cityCode, cityName, placeCode, placeName, streetCode, streetName, limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
