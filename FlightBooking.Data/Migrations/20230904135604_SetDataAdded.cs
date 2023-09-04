using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "City", "Country", "CreatedAt", "IATA", "ICAO", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "New York", "USA", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5601), "JFK", "KJFK", false, "Uzbekistan International Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Los Angeles", "USA", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5607), "LAX", "KLAX", false, "Los Angeles International Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "London", "UK", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5609), "LHR", "EGLL", false, "Heathrow Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "Paris", "France", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5610), "CDG", "LFPG", false, "Charles de Gaulle Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, "Tokyo", "Japan", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5612), "NRT", "RJAA", false, "Andijan International Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, "Dubai", "UAE", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5613), "DXB", "OMDB", false, "Dubai International Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, "Sydney", "Australia", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5614), "SYD", "YSSY", false, "Sydney Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, "Beijing", "China", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5616), "PEK", "ZBAA", false, "Beijing Capital International Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, "Nairobi", "Kenya", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5617), "NBO", "HKJK", false, "Jomo Kenyatta International Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, "Tel Aviv", "Israel", new DateTime(2023, 9, 4, 13, 56, 4, 131, DateTimeKind.Utc).AddTicks(5618), "TLV", "LLBG", false, "Ben Gurion Airport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 10L);
        }
    }
}
