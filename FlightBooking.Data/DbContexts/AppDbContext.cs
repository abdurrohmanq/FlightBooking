using FlightBooking.Domain.Entities.Airports;
using FlightBooking.Domain.Entities.Bookings;
using FlightBooking.Domain.Entities.Customers;
using FlightBooking.Domain.Entities.Flights;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Flight> Flights { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Airport> Airports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Booking>()
            .HasOne(c=> c.Customer)
            .WithMany(b=> b.Bookings)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Booking>()
            .HasOne(f=> f.Flight)
            .WithMany(b=> b.Bookings)
            .HasForeignKey(f => f.FlightId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Flight>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Flight>()
        .HasOne(f => f.DepartureAirport)
        .WithMany()
        .HasForeignKey(f => f.DepartureAirportId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Flight>()
            .HasOne(f => f.ArrivalAirport)
            .WithMany()
            .HasForeignKey(f => f.ArrivalAirportId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Airport>().HasData(
           new Airport {Id=1, Name = "Uzbekistan International Airport", City = "New York", Country = "USA", IATA = "JFK", ICAO = "KJFK" },
                new Airport { Id = 2, Name = "Los Angeles International Airport", City = "Los Angeles", Country = "USA", IATA = "LAX", ICAO = "KLAX" },
                new Airport { Id = 3, Name = "Heathrow Airport", City = "London", Country = "UK", IATA = "LHR", ICAO = "EGLL" },
                new Airport { Id = 4, Name = "Charles de Gaulle Airport", City = "Paris", Country = "France", IATA = "CDG", ICAO = "LFPG" },
                new Airport { Id = 5, Name = "Andijan International Airport", City = "Tokyo", Country = "Japan", IATA = "NRT", ICAO = "RJAA" },
                new Airport { Id = 6, Name = "Dubai International Airport", City = "Dubai", Country = "UAE", IATA = "DXB", ICAO = "OMDB" },
                new Airport { Id = 7, Name = "Sydney Airport", City = "Sydney", Country = "Australia", IATA = "SYD", ICAO = "YSSY" },
                new Airport { Id = 8, Name = "Beijing Capital International Airport", City = "Beijing", Country = "China", IATA = "PEK", ICAO = "ZBAA" },
                new Airport { Id = 9, Name = "Jomo Kenyatta International Airport", City = "Nairobi", Country = "Kenya", IATA = "NBO", ICAO = "HKJK" },
                new Airport { Id = 10, Name = "Ben Gurion Airport", City = "Tel Aviv", Country = "Israel", IATA = "TLV", ICAO = "LLBG" });
    }
}
