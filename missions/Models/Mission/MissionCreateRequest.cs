using System.ComponentModel.DataAnnotations;

namespace missions.Controllers
{
    public class MissionCreateRequest
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public int OrganizationID { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? Agent { get; set; }
        [Required]
        public string? Drone { get; set; }
        [Required]
        public string? Antenna { get; set; }
    }
}