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
    }

}
