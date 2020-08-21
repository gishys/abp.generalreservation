using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Nm.Reservation
{
    public class ReservationManagerInfoDto: FullAuditedEntityDto<Guid>
    {
        public string Name
        {
            get;
            set;
        }
        public int OpenDays
        {
            get;
            set;
        }
        public bool IncludeDay
        {
            get;
            set;
        }
        public ICollection<ReservationConditionDto> ReservationConditions
        {
            get;
            set;
        }
    }
}
