using System.ComponentModel.DataAnnotations;

namespace Municipality_Management_System.Models
{
    //Report class with their Attributes and DataAnnotations
    public class Report
    {
        public int ReportID { get; set; }

        //this would be my Foreign Key
        public int CitizenID { get; set; }

        [Required]
        public string? ReportType { get; set; }

        [Required]
        public string? Details { get; set; }

        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Under Review";

        //referencing Citizen
        public Citizen Citizen { get; set; }
    }
}
