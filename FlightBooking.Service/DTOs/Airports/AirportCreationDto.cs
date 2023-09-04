using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Service.DTOs.Airports;

public class AirportCreationDto
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string IATA { get; set; }
    public string ICAO { get; set; }
}