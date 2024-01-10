using System.ComponentModel.DataAnnotations;

namespace TripsLog.Models
{
    public class TripLog
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        [Required (ErrorMessage = "Accommodations is required")]
        public string Accommodations { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Int32 PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<TripLog> TripLogs { get; set; }
        public string Todo1 { get; set; }
        public string Todo2 { get; set; }
        public string Todo3 { get; set; }
        public string Todo4 { get; set; }
        public string todo { get; set; }
    }

     
    }
