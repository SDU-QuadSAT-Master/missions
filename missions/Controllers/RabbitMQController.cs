using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace missions
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class RabbitMQController : ControllerBase

    {
        [HttpPost]
        [Route("/flightentry/publish")]
        public IActionResult PublishFlight(int droneId, int hours, string location, string pilot)
        {
            FlightEntry flightEntry = new FlightEntry() { DroneId = droneId, Hours = hours, Location = location, Pilot = pilot, Date = DateTime.Now.ToUniversalTime() };
            MessagePublisher publisher = new MessagePublisher("flights");
            publisher.PublishMessage(JsonConvert.SerializeObject(flightEntry));
            publisher.Dispose();

            return Ok();

        }

    }
}
