using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Nm.Reservation.EntityFrameworkCore
{
    public class EfCoreReservationManagerInfoRepository
        : EfCoreRepository<ReservationDbContext, ReservationManagerInfo, Guid>,
        IReservationManagerInfoRepository
    {
        public EfCoreReservationManagerInfoRepository(
            IDbContextProvider<ReservationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        public List<ReservationManagerInfo> GetListByName(
            string name, int skipCount, int maxResultCount, bool fuzzy = true, bool includeDetails = true)
        {
            return DbSet
                .IncludeDetails(includeDetails)
                .Where(d => fuzzy ? d.Name.Contains(name) : d.Name == name)
                .OrderBy(d => d.Name)
                .PageBy(skipCount, maxResultCount).ToList();
        }
        public List<ReservationManagerInfo> GetList(
            int skipCount, int maxResultCount, bool includeDetails = true)
        {
            return DbSet
                .IncludeDetails(includeDetails)
                .OrderBy(d => d.Name)
                .PageBy(skipCount, maxResultCount).ToList();
        }
    }
}
