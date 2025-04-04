using System.ComponentModel.DataAnnotations;

namespace Municipality_Management_System.Models
{
    //Citizen class with their Attributes and DataAnnotations
    public class Citizen
    {
        
        public int CitizenID { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
