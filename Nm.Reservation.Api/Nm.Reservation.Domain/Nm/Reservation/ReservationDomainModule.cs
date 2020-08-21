using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Nm.Reservation
{
    [DependsOn(typeof(AbpDddDomainModule))]
    [DependsOn(typeof(ReservationDomainSharedModule))]
    public class ReservationDomainModule : AbpModule
    {

    }
}
