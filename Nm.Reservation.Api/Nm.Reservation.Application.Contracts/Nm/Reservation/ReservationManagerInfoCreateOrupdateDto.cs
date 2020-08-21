using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nm.Reservation
{
    public class ReservationManagerInfoCreateOrupdateDto
    {
        [Required]
        [StringLength(ReservationManagerInfoConsts.MaxNameLength)]
        public string Name
        {
            get;
            set;
        }
        [Required]
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
        public ICollection<ReservationConditionCreateDto> ConditionCreateDtos
        {
            get;
            set;
        }
    }
}
