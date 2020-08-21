using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Nm.Reservation.EntityFrameworkCore
{
    [ConnectionStringName(ReservationDbProperties.ConnectionStringName)]
    public class ReservationDbContext : AbpDbContext<ReservationDbContext>
    {
        public DbSet<ReservationManagerInfo> ReservationManagerInfos
        {
            get;
            set;
        }
        public DbSet<ReservationCondition> ReservationConditions
        {
            get;
            set;
        }
        public DbSet<ReservationPeriod> ReservationPeriods
        {
            get;
            set;
        }
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
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
