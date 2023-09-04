using FlightBooking.Service.DTOs.Airports;
using System.ComponentModel;

namespace FlightBooking.Service.DTOs.Flights;

public class FlightResultDto
{
    public long Id { get; set; }
    public string FlightNumber { get; set; }
    [DisplayName("Departure City")]
    public string DepartureCity { get; set; }
    [DisplayName("Arrival City")]
    public string ArrivalCity { get; set; }
    [DisplayName("Departure Time")]
    public DateTime DepartureTime { get; set; }
    [DisplayName("Arrival Time")]
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
    [DisplayName("Available Seats")]
    public int AvailableSeats { get; set; }

    public AirportResultDto DepartureAirport { get; set; }
    public AirportResultDto ArrivalAirport { get; set; }
}
