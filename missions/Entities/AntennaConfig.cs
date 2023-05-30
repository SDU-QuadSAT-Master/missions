using System.Reflection.Metadata;
using System.Text.Json.Serialization;

public class AntennaConfig
{
    public int AntennaConfigID {  get; set; }
    public float Altitude { get; set; }
    public float Azimuth { get; set; }
    public float Elevation { get; set; }
    public float Frequency { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string? Polarization { get; set; }
    public string? Radome { get; set; }

    [JsonIgnore]
    public int MissionId { get; set; }
    public Mission Mission { get; set; }
}