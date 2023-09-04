namespace FlightBooking.Service.DTOs.Airports;

public class AirportResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string IATA { get; set; }
    public string ICAO { get; set; }
}
