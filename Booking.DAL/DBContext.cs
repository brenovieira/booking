using System.Data.Entity;
using Booking.DAL.Entities;

namespace Booking.DAL
{
    public class DBContext : DbContext
    {
        public DBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbSet<Availability> Availabilities { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<HealthIssue> HealthIssues { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
