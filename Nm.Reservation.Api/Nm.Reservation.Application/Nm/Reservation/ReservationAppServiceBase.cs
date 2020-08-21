using Volo.Abp.Application.Services;

namespace Nm.Reservation
{
    public class ReservationAppServiceBase : ApplicationService
    {
        public ReservationAppServiceBase()
        {
            ObjectMapperContext = typeof(ReservationApplicationModule);
        }
    }
}
