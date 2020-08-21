using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Nm.Reservation
{
    public interface IReservationManagerInfoAppService
    {
        ReservationManagerInfoDto Create(ReservationManagerInfoCreateOrupdateDto inputDto);
        PagedResultDto<ReservationManagerInfoDto> GetListByName(GetReservationManagerInfosInput input, bool fuzzy = true);
        PagedResultDto<ReservationManagerInfoDto> GetList(PagedAndSortedResultRequestDto input);
        void Delete(Guid id);
        ReservationManagerInfoDto Update(Guid id, ReservationManagerInfoCreateOrupdateDto inputDto);
    }
}
