using System.Text.Json.Serialization;

public class FlightEntry
{
    public int FlightEntryId { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Pilot { get; set; }
    public int Hours { get; set; }
    public int DroneId { get; set; }

}