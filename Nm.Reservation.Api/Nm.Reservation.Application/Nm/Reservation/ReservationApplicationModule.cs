using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Nm.Reservation
{
    [DependsOn(typeof(ReservationApplicationContractsModule))]
    [DependsOn(typeof(ReservationDomainModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class ReservationApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ReservationApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ReservationMapperProfile>(validate: true);
            });
        }
    }
}
