using FIASApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FIASApi.Api.Controllers
{
    [ApiController]
    [Route("api/addrob/")]
    [Produces("application/json")]
    public class AddrobController : ControllerBase
    {
        private DataManager _dataManager;

        public AddrobController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet("regions")]
        public async Task<IActionResult> GetRegions()
        {
            try
            {
                var regions = _dataManager.Addrobs.GetRegions().ToList();

                return Ok(regions);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("areas")]
        public async Task<IActionResult> GetAreas()
        {
            try
            {
                var areas = _dataManager.Addrobs.GetAreas().ToList();

                return Ok(areas);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                var cities = _dataManager.Addrobs.GetCities().ToList();

                return Ok(cities);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("places")]
        public async Task<IActionResult> GetPlaces()
        {
            try
            {
                var places = _dataManager.Addrobs.GetPlaces().ToList();

                return Ok(places);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("streets")]
        public async Task<IActionResult> GetStreets()
        {
            try
            {
                var streets = _dataManager.Addrobs.GetStreets().ToList();

                return Ok(streets);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
