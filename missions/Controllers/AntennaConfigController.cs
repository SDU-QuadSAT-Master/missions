using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace missions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class AntennaConfigController : ControllerBase
    {
        private IAntennaConfigService _antennaConfigService;
        public AntennaConfigController(IAntennaConfigService antennaConfigService)
        {
            _antennaConfigService = antennaConfigService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_antennaConfigService.GetAll()); ;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_antennaConfigService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] AntennaConfigCreateRequest model)
        {
            var drone = _antennaConfigService.Create(model);

            return Ok(drone);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AntennaConfigUpdateRequest model)
        {
            var drone = _antennaConfigService.Update(id, model);
            return Ok(drone);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _antennaConfigService.Delete(id);
            return Ok(new { message = $"AntennaConfig {id} deleted" });
        }
    }
}

