using Microsoft.EntityFrameworkCore;


namespace Agentie.Models
{
    public class ReservationsDbContext : DbContext
    {
        public ReservationsDbContext(DbContextOptions<ReservationsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Remarks> Remarks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasMany(c => c.Remarks)
                .WithOne(e => e.Reservation)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
