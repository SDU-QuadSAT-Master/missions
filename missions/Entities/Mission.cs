using System.Text.Json.Serialization;

public class Mission
{
    public int MissionId { get; set; }

    public int OrganizationId { get; set; }

    public string? Title { get; set; }

    public DateTime? createdAt { get; set; } = DateTime.Now.ToUniversalTime();

    public DateTime? updatedAt { get; set; }

    public string? Location { get; set; }

    public string? Agent { get; set; }

    public string? Drone { get; set; }
    
    public string? Antenna { get; set; }

    public AntennaConfig? AntennaConfig { get; set; }

}