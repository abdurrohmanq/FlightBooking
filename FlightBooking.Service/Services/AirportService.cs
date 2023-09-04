using AutoMapper;
using FlightBooking.Data.IRepositories;
using FlightBooking.Domain.Entities.Airports;
using FlightBooking.Service.DTOs.Airports;
using FlightBooking.Service.Exceptions;
using FlightBooking.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Service.Services;

public class AirportService : IAirportService
{
    private readonly IRepository<Airport> repository;
    private readonly IMapper mapper;
    public AirportService(IRepository<Airport> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<AirportResultDto> AddAsync(AirportCreationDto dto)
    {
        var existAirport = await repository.GetAsync(c => c.Name == dto.Name);
        if (existAirport is not null)
            throw new AlreadyExistException("This Airport is already exist");

        var mappedAirport = mapper.Map<Airport>(dto);
        await repository.CreateAsync(mappedAirport);
        await repository.SaveChanges();

        return mapper.Map<AirportResultDto>(mappedAirport);
    }

    public async Task<bool> Delete(long id)
    {
        var existAirport = await repository.GetAsync(c => c.Id == id);
        if (existAirport is null)
            throw new NotFoundException("This Airport is not found");

        repository.Delete(existAirport);
        await repository.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<AirportResultDto>> GetAllAsync()
    {
        var allAirports = await repository.GetAll().ToListAsync();
        return mapper.Map<IEnumerable<AirportResultDto>>(allAirports);
    }

    public async Task<AirportResultDto> GetAsync(long id)
    {
        var existAirport = await repository.GetAsync(c => c.Id == id);
        if (existAirport is null)
            throw new NotFoundException("This Airport is not found");

        return mapper.Map<AirportResultDto>(existAirport);
    }

    public async Task<AirportResultDto> UpdateAsync(AirportUpdateDto dto)
    {
        var existAirport = await repository.GetAsync(c => c.Id == dto.Id);
        if (existAirport is null)
            throw new NotFoundException("This Airport is not found");

        mapper.Map(dto, existAirport);
        repository.Update(existAirport);
        await repository.SaveChanges();

        return mapper.Map<AirportResultDto>(existAirport);
    }
}
