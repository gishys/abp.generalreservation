using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Nm.Reservation.AspNetCore;
using Nm.Reservation.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Nm.Reservation.Api
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(ReservationApplicationContractsModule))]
    [DependsOn(typeof(ReservationAspNetCoreModule))]
    [DependsOn(typeof(ReservationApplicationModule))]
    [DependsOn(typeof(ReservationEntityFrameworkCoreModule))]
    public class AppModule : AbpModule
    {
        public override void OnApplicationInitialization(
            ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}
