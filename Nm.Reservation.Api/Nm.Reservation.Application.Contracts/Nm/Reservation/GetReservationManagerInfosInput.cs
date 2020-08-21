using Volo.Abp.Application.Dtos;

namespace Nm.Reservation
{
    public class GetReservationManagerInfosInput : PagedAndSortedResultRequestDto
    {
        public string Name
        {
            get;
            set;
        }
    }
}
