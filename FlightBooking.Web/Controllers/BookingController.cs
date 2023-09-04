using FlightBooking.Service.DTOs.Bookings;
using FlightBooking.Service.DTOs.Flights;
using FlightBooking.Service.Interfaces;
using FlightBooking.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Web.Controllers;

public class BookingController : Controller
{
    private readonly IBookingService bookingService;
    public BookingController(IBookingService bookingService)
    {
        this.bookingService = bookingService;
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(BookingCreationDto dto)
    {
        var createdFlight = await bookingService.AddAsync(dto);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Index()
    {
        var bookings = await bookingService.GetAllAsync();
        return View(bookings);
    }
    public IActionResult ThrowId(long id)
    {
        ViewData["FlightId"] = id;
        return View("Booking");
    }
}
