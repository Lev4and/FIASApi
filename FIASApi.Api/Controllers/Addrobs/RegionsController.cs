using FIASApi.Model;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIASApi.Api.Controllers.Addrobs
{
    [ApiController]
    [Route("api/addrobs/regions/")]
    [Produces("application/json")]
    public class RegionsController : ControllerBase
    {
        private DataManager _dataManager;

        public RegionsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("region")]
        public async Task<IActionResult> GetRegion(string aoguid)
        {
            try
            {
                return Ok(await Task.Run<VRegion>(() => { return _dataManager.Regions.GetRegion(aoguid); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetRegions(int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VRegion>>(() => { return _dataManager.Regions.GetRegions(limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetRegions(string offname, int? limit = null)
        {
            try
            {
                return Ok(await Task.Run<List<VRegion>>(() => { return _dataManager.Regions.GetRegions(offname, limit).ToList(); }));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
