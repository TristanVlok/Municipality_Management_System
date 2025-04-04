using Microsoft.EntityFrameworkCore;
using Municipality_Management_System.Models;

namespace Municipality_Management_System.Data
{
    //Setting up the Appilcation's Models to the DbContext 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Report> Reports { get; set; }

    }
}
