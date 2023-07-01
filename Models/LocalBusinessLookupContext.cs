using Microsoft.EntityFrameworkCore;

namespace LocalBusinessLookup.Models
{
    public class LocalBusinessLookupContext : DbContext
    {
        public LocalBusinessLookupContext(DbContextOptions<LocalBusinessLookupContext> options)
            : base(options)
        {
        }

        public DbSet<Business> Businesses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Business>()
                .HasData(
                    new Business { BusinessId = 1, Name = "Dave's Music", Address = "123 N Street St", PhoneNumber = "7", Website = "Example.com" },
                    new Business { BusinessId = 2, Name = "John's Sounds", Address = "456 N Way Rd", PhoneNumber = "867-5309", Website = "Example.com" }
                );
        }
    }
}