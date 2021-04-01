using FIASApi.Model;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIASApi.Api.Controllers.Addrobs
{
    [ApiController]
    [Route("api/addrobs/areas/")]
    [Produces("application/json")]
    public class AreasController : ControllerBase
    {
        private DataManager _dataManager;

        public AreasController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("area")]
        public async Task<IActionResult> GetArea(string aoguid)
        {
            try
            {
                return Ok(await Task.Run<VArea>(() => { return _dataManager.Areas.GetArea(aoguid); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAreas(int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VArea>>(() => { return _dataManager.Areas.GetAreas(limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAreas(string offname, string regionCode = "", string regionName = "", int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VArea>>(() => { return _dataManager.Areas.GetAreas(offname, regionCode, regionName, limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
