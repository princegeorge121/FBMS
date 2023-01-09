using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsiderFlightManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingFlightBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "FlightBookingStatus",
                table: "FlightBookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "FlightBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FlightBookingStatus",
                table: "FlightBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
