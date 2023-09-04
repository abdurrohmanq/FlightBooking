using FlightBooking.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Entities.Airports;

public class Airport : AudiTable
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string IATA { get; set; }
    public string ICAO { get; set; }
}
