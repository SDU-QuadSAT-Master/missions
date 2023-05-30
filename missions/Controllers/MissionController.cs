using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace missions.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors("AllowSpecificOrigin")]
	public class MissionController : ControllerBase
	{
        private IMissionService _missionService;
        public MissionController(IMissionService missionService)
		{
			_missionService = missionService;

		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_missionService.GetAll()); ;
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_missionService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] MissionCreateRequest model)
		{
			var drone = _missionService.Create(model);

			return Ok(drone);
		}
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] MissionUpdateRequest model)
		{
			var drone = _missionService.Update(id, model);
			return Ok(drone);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_missionService.Delete(id);
			return Ok(new { message = $"Mission {id} deleted" });
		}
	}
}

