using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Nm.Reservation
{
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(ReservationDomainSharedModule))]
    public class ReservationApplicationContractsModule : AbpModule
    {
    }
}
