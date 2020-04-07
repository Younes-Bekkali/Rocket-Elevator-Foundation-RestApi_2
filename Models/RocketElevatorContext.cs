using Microsoft.EntityFrameworkCore;
namespace RocketElevatorApi.Models
{
    public class RocketElevatorContext : DbContext
    {
        public RocketElevatorContext(DbContextOptions<RocketElevatorContext> options) : base(options) { }
        public DbSet<Elevator> Elevators { get; set; }
        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Column> Columns {get; set;}
        public DbSet<Lead> Leads {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Building> Buildings {get; set;}
        public DbSet<Intervention> Interventions { get; set; }

    

    }
}