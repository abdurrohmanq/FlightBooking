using AutoMapper;
using FlightBooking.Data.IRepositories;
using FlightBooking.Domain.Entities.Customers;
using FlightBooking.Service.DTOs.Customers;
using FlightBooking.Service.Exceptions;
using FlightBooking.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Service.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> repository;
    private readonly IMapper mapper;
    public CustomerService(IRepository<Customer> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<CustomerResultDto> AddAsync(CustomerCreationDto dto)
    {
        var existCustomer = await repository.GetAsync(c => c.Email == dto.Email);
        if (existCustomer is not null)
            throw new AlreadyExistException("This customer is already exist");

        var mappedCustomer = mapper.Map<Customer>(dto);
        await repository.CreateAsync(mappedCustomer);
        await repository.SaveChanges();

        return mapper.Map<CustomerResultDto>(mappedCustomer);
    }

    public async Task<bool> Delete(long id)
    {
        var existCustomer = await repository.GetAsync(c => c.Id == id);
        if (existCustomer is null)
            throw new NotFoundException("This customer is not found");

        repository.Delete(existCustomer);
        await repository.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<CustomerResultDto>> GetAllAsync()
    {
        var allCustomers = await repository.GetAll().ToListAsync();
        return mapper.Map<IEnumerable<CustomerResultDto>>(allCustomers);
    }

    public async Task<CustomerResultDto> GetAsync(long id)
    {
        var existCustomer = await repository.GetAsync(c => c.Id == id);
        if (existCustomer is null)
            throw new NotFoundException("This customer is not found");

        return mapper.Map<CustomerResultDto>(existCustomer);
    }

    public async Task<CustomerResultDto> UpdateAsync(CustomerUpdateDto dto)
    {
        var existCustomer = await repository.GetAsync(c => c.Id == dto.Id);
        if (existCustomer is null)
            throw new NotFoundException("This customer is not found");

        mapper.Map(dto, existCustomer);
        repository.Update(existCustomer);
        await repository.SaveChanges();

        return mapper.Map<CustomerResultDto>(existCustomer);
    }
}
