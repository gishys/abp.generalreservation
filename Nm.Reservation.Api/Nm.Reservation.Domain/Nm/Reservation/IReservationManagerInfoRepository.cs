using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;

namespace Nm.Reservation
{
    public interface IReservationManagerInfoRepository : IBasicRepository<ReservationManagerInfo, Guid>
    {
        List<ReservationManagerInfo> GetListByName(
            string name, int skipCount, int maxResultCount, bool fuzzy = true, bool includeDetails = true);
        List<ReservationManagerInfo> GetList(
            int skipCount, int maxResultCount, bool includeDetails = true);
    }
}
