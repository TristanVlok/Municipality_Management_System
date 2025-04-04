using System.ComponentModel.DataAnnotations;

namespace Municipality_Management_System.Models
{
    //Staff class with their Attributes and DataAnnotations
    public class Staff
    {
        public int StaffID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Department { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime HireDate { get; set; }


    }
}
