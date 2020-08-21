using Microsoft.Extensions.DependencyInjection;
using Nm.Reservation.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Nm.Reservation.Migrations
{
    [DependsOn(typeof(ReservationEntityFrameworkCoreModule))]
    public class ReservationMigrationsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ReservationMigrationsDbContext>();
        }
    }
}
