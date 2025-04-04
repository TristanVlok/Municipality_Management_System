using System.ComponentModel.DataAnnotations;

namespace Municipality_Management_System.Models
{
    //ServiceRequest class with their Attributes and DataAnnotations
    public class ServiceRequest
    {
        
        public int ServiceRequestID { get; set; }

        //this would be my Foreign Key
        public int CitizenID { get; set; }

        [Required]
        public string? ServiceType { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";

        //referencing Citizen
        public Citizen Citizen { get; set; }

    }
}
