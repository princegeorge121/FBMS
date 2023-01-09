namespace AirsiderFlightManagement.Models.ViewModels
{
    public class FlightSearchView
    {
        [Required]
        [Display(Name ="Flight From")]
        public Location FlightFrom { get; set; }

        [Required]
        [Display(Name = "Flight To")]
        public Location FlightTo { get; set; }

       
        [Display(Name = "Flight Date")]
        public DateTime FlightDate { get; set; }

       
        [Display(Name = "Flight Type")]
        public FlightType FlightType { get; set; }
    }
}
