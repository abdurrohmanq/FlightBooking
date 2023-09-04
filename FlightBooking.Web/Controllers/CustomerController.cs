using FlightBooking.Service.DTOs.Customers;
using FlightBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CustomerCreationDto dto)
    {
        var createdCustomer = await _customerService.AddAsync(dto);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Index()
    {
        var customers = await _customerService.GetAllAsync();
        return View(customers);
    }
}
