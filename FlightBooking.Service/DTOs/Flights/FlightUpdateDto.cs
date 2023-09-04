﻿namespace FlightBooking.Service.DTOs.Flights;

public class FlightUpdateDto
{
    public long Id { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
    public int AvailableSeats { get; set; }

    public long DepartureAirportId { get; set; }
    public long ArrivalAirportId { get; set; }
}
