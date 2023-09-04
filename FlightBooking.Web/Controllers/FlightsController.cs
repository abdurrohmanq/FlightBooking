using AutoMapper;
using FlightBooking.Domain.Entities.Flights;
using FlightBooking.Service.DTOs.Flights;
using FlightBooking.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Web.Controllers;

public class FlightsController : Controller
{
    private readonly IFlightService flightService;
    private readonly IMapper mapper;
    public FlightsController(IFlightService flightService, IMapper mapper)
    {
        this.flightService = flightService;
        this.mapper = mapper;
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(FlightCreationDto dto)
    {
        var createdFlight = await flightService.AddAsync(dto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var user = await flightService.GetAsync(id);
        var mappedUser = mapper.Map<Flight>(user);
        return View(mappedUser);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Flight model)
    {
        var mappedUser = mapper.Map<FlightUpdateDto>(model);
        var user = await flightService.UpdateAsync(mappedUser);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Detail(long id)
    {
        var flight = await flightService.GetAsync(id);
        var mappedflight = mapper.Map<Flight>(flight);
        return View(mappedflight);
    }


    public IActionResult SearchFlight()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SearchFlight(string DepartureCity, string ArrivalCity, DateTime DepartureTime, int NumberOfPassengers)
    {
        var from = DepartureCity;
        var to = ArrivalCity;
        var date = DepartureTime;
        var count = NumberOfPassengers;
        var search = await flightService.SearchFlightAsync(from, to, date, count);
        return View(search);
    }
    public async Task<IActionResult> Index()
    {
        var flights = await flightService.GetAllAsync();
        return View(flights);
    }
}
