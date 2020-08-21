using Microsoft.EntityFrameworkCore;
using Nm.Reservation.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Nm.Reservation.Migrations
{
    public class ReservationMigrationsDbContext : AbpDbContext<ReservationMigrationsDbContext>
    {
        public ReservationMigrationsDbContext(
            DbContextOptions<ReservationMigrationsDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureReservation();
        }
    }
}
