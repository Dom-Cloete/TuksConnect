using Microsoft.EntityFrameworkCore;
using TuksConnectAPI.Models;

namespace TuksConnectAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, EventTitle = "AI & Tech Trends Workshop", Location = "Merensky II Library", TicketPrice = 50 },
                new Event { Id = 2, EventTitle = "Tuks Music Festival", Location = "Amphitheatre", TicketPrice = 250 },
                new Event { Id = 3, EventTitle = "Cultural Day Celebration", Location = "Piazza", TicketPrice = 20 },
                new Event { Id = 4, EventTitle = "Career Expo 2026", Location = "Rautenbach Hall", TicketPrice = 0 },
                new Event { Id = 5, EventTitle = "Intervarsity Rugby Match", Location = "TuksStadium", TicketPrice = 180 }
            );
        }
    }
}
