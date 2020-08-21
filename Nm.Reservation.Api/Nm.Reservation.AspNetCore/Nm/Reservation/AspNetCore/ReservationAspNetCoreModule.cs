using Volo.Abp.Modularity;

namespace Nm.Reservation.AspNetCore
{
    [DependsOn(typeof(ReservationDomainModule))]
    public class ReservationAspNetCoreModule : AbpModule
    {
    }
}