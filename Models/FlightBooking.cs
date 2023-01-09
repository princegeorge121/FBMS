namespace AirsiderFlightManagement.Models
{
    public class FlightBooking
    {
        [Key]
        public long FlightBookingId { get; set; }

        public string FlightTicketNumber { get; set; }

        //public string FlightBookingStatus { get; set; }

        //public DateTime BookingDate { get; set; }

        public DateTime DateOfTravel { get; set; }

        public long FlightNumber { get; set; }

        public FlightSchedule FlightSchedule { get; set; }

        public long FlightScheduleId { get; set; }

        public Passenger Passenger { get; set; }    

        public String PassengersId { get; set; }   


    }
}
