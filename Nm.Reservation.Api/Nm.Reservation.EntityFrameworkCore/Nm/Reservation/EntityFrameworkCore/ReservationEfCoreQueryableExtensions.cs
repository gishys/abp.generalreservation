using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Nm.Reservation.EntityFrameworkCore
{
    public static class ReservationEfCoreQueryableExtensions
    {
        public static IQueryable<ReservationManagerInfo> IncludeDetails(
            this IQueryable<ReservationManagerInfo> queryable, bool inlude = true)
        {
            if (!inlude)
                return queryable;
            return queryable.Include(d => d.ReservationConditions);
        }
    }
}
