using AutoMapper;
using FlightBooking.Data.IRepositories;
using FlightBooking.Domain.Entities.Airports;
using FlightBooking.Domain.Entities.Customers;
using FlightBooking.Domain.Entities.Flights;
using FlightBooking.Service.DTOs.Flights;
using FlightBooking.Service.Exceptions;
using FlightBooking.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Service.Services;

public class FlightService : IFlightService
{
    private readonly IRepository<Flight> repository;
    private readonly IRepository<Customer> customerRepository;
    private readonly IRepository<Airport> airportRepository;
    private readonly IMapper mapper;
    public FlightService(IMapper mapper, IRepository<Flight> repository, IRepository<Airport> airportRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.airportRepository = airportRepository;
    }

    private string GenerateUniqueAccountNumber()
    {
        string guid = Guid.NewGuid().ToString("N");
        return "ACC" + guid;
    }
    public async Task<FlightResultDto> AddAsync(FlightCreationDto dto)
    {
        dto.FlightNumber = GenerateUniqueAccountNumber();
        var existDepAirport = await airportRepository.GetAsync(a => a.Id == dto.DepartureAirportId)
            ?? throw new NotFoundException("This DepartureAirport is not found");
        var existArrAirport = await airportRepository.GetAsync(a => a.Id == dto.ArrivalAirportId)
            ?? throw new NotFoundException("This ArrivalAirport is not found");

        var mappedFlight = mapper.Map<Flight>(dto);
        mappedFlight.DepartureAirport = existDepAirport;
        mappedFlight.ArrivalAirport = existArrAirport;
        await repository.CreateAsync(mappedFlight);
        await repository.SaveChanges();

        return mapper.Map<FlightResultDto>(mappedFlight);
    }

    public async Task<bool> Delete(long id)
    {
        var existFlight = await repository.GetAsync(a => a.Id == id)
            ?? throw new NotFoundException("This Flight is not found");

        repository.Delete(existFlight);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<FlightResultDto>> GetAllAsync()
    {
        var allFlights = await repository.GetAll(includes: new[] { "DepartureAirport", "ArrivalAirport" }).ToListAsync();
        return mapper.Map<IEnumerable<FlightResultDto>>(allFlights);
    }

    public async Task<FlightResultDto> GetAsync(long id)
    {
        var existFlight = await repository.GetAsync(c => c.Id == id, includes: new[] { "DepartureAirport", "ArrivalAirport" });
        if (existFlight is null)
            throw new NotFoundException("This flight is not found");

        return mapper.Map<FlightResultDto>(existFlight);
    }

    public async Task<FlightResultDto> UpdateAsync(FlightUpdateDto dto)
    {
        var existFlight = await repository.GetAsync(c => c.Id == dto.Id);
        if (existFlight is null)
            throw new NotFoundException("This flight is not found");

        mapper.Map(dto, existFlight);
        repository.Update(existFlight);
        await repository.SaveChanges();

        return mapper.Map<FlightResultDto>(existFlight);
    }

    public async Task<IEnumerable<FlightResultDto>> SearchFlightAsync(string DepartureCity, string ArrivalCity, DateTime DepartureTime, int NumberOfPassengers)
    {
        var flights = await repository.GetAll(includes: new[] { "DepartureAirport", "ArrivalAirport" }).Where(d => (d.DepartureCity == DepartureCity) && (d.ArrivalCity == ArrivalCity) && (d.DepartureTime == DepartureTime) && (d.AvailableSeats >= NumberOfPassengers)).ToListAsync();
        if (flights.Any())
        {
            return mapper.Map<IEnumerable<FlightResultDto>>(flights);
        }
        return null;
    }
}