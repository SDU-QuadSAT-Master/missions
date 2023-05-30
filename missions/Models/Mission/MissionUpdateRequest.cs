using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace missions.Controllers
{
    public class MissionUpdateRequest
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

        [JsonIgnore]
        public DateTime? updatedAt { get; set; } = DateTime.Now.ToUniversalTime();
    }
}