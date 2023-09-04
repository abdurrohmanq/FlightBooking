using AutoMapper;
using FlightBooking.Data.IRepositories;
using FlightBooking.Domain.Entities.Bookings;
using FlightBooking.Domain.Entities.Customers;
using FlightBooking.Domain.Entities.Flights;
using FlightBooking.Service.DTOs.Bookings;
using FlightBooking.Service.Exceptions;
using FlightBooking.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingBooking.Service.Services;

public class BookingService : IBookingService
{
    private readonly IRepository<Booking> repository;
    private readonly IRepository<Customer> customerRepository;
    private readonly IRepository<Flight> flightRepository;
    private readonly IMapper mapper;
    public BookingService(IMapper mapper, IRepository<Booking> repository, IRepository<Customer> customerRepository, IRepository<Flight> flightRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.customerRepository = customerRepository;
        this.flightRepository = flightRepository;
    }
    public async Task<BookingResultDto> AddAsync(BookingCreationDto dto)
    {
        var existCustomer = await customerRepository.GetAsync(a => a.Id == dto.CustomerId)
            ?? throw new NotFoundException("This Customer is not found");
        var existFlight = await flightRepository.GetAsync(a => a.Id == dto.FlightId)
            ?? throw new NotFoundException("This Flight is not found");

        var mappedBooking = mapper.Map<Booking>(dto);
        mappedBooking.Customer = existCustomer;
        mappedBooking.Flight = existFlight;
        existFlight.AvailableSeats -= dto.NumberOfPassengers;
        flightRepository.Update(existFlight);
        await repository.CreateAsync(mappedBooking);
        await repository.SaveChanges();

        return mapper.Map<BookingResultDto>(mappedBooking);
    }

    public async Task<bool> Delete(long id)
    {
        var existBooking = await repository.GetAsync(a => a.Id == id, includes: new[] { "Flight", "Customer" })
            ?? throw new NotFoundException("This Booking is not found");

        repository.Delete(existBooking);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<BookingResultDto>> GetAllAsync()
    {
        var allBookings = await repository.GetAll(includes: new[] { "Flight" , "Customer" }).ToListAsync();
        return mapper.Map<IEnumerable<BookingResultDto>>(allBookings);
    }

    public async Task<BookingResultDto> GetAsync(long id)
    {
        var existBooking = await repository.GetAsync(c => c.Id == id);
        if (existBooking is null)
            throw new NotFoundException("This Booking is not found");

        return mapper.Map<BookingResultDto>(existBooking);
    }

    public async Task<BookingResultDto> UpdateAsync(BookingUpdateDto dto)
    {
        var existBooking = await repository.GetAsync(c => c.Id == dto.Id);
        if (existBooking is null)
            throw new NotFoundException("This Booking is not found");

        mapper.Map(dto, existBooking);
        repository.Update(existBooking);
        await repository.SaveChanges();

        return mapper.Map<BookingResultDto>(existBooking);
    }


}
