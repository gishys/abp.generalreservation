using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nm.Reservation
{
    public class ReservationConditionCreateDto
    {
        [Required]
        [StringLength(ReservationConditionConsts.MaxItemNameLength)]
        public string ItemName
        {
            get;
            set;
        }
        [Required]
        [StringLength(ReservationConditionConsts.MaxItemValueLength)]
        public string ItemValue
        {
            get;
            set;
        }
        public ReservationConditionType RCType
        {
            get;
            set;
        } = ReservationConditionType.Other;
        public List<ReservationConditionCreateDto> ReservationConditions
        {
            get;
            set;
        }
        public List<ReservationPeriodCreateDto> ReservationPeriods
        {
            get;
            set;
        }
    }
}
