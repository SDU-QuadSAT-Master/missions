using System.ComponentModel.DataAnnotations;

namespace missions.Controllers
{
    public class AntennaConfigCreateRequest
    {
        [Required]
        public int MissionID { get; set; }
        [Required]
        public float Altitude { get; set; }
        [Required]
        public float Azimuth { get; set; }
        [Required]
        public float Elevation { get; set; }
        [Required]
        public float Frequency { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public string? Polarization { get; set; }
        [Required]
        public string? Radome { get; set; }
    }
}