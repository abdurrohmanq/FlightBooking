using AutoMapper;
using FlightBooking.Domain.Entities.Airports;
using FlightBooking.Domain.Entities.Bookings;
using FlightBooking.Domain.Entities.Customers;
using FlightBooking.Domain.Entities.Flights;
using FlightBooking.Service.DTOs.Airports;
using FlightBooking.Service.DTOs.Bookings;
using FlightBooking.Service.DTOs.Customers;
using FlightBooking.Service.DTOs.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer,CustomerResultDto>().ReverseMap();
        CreateMap<Customer,CustomerUpdateDto>().ReverseMap();
        CreateMap<Customer,CustomerCreationDto>().ReverseMap();

        CreateMap<Flight, FlightResultDto>().ReverseMap();
        CreateMap<Flight, FlightUpdateDto>().ReverseMap();
        CreateMap<Flight, FlightCreationDto>().ReverseMap();

        CreateMap<Booking, BookingResultDto>().ReverseMap();
        CreateMap<Booking, BookingUpdateDto>().ReverseMap();
        CreateMap<Booking, BookingCreationDto>().ReverseMap();

        CreateMap<Airport, AirportResultDto>().ReverseMap();
        CreateMap<Airport, AirportUpdateDto>().ReverseMap();
        CreateMap<Airport, AirportCreationDto>().ReverseMap();
    }
}
