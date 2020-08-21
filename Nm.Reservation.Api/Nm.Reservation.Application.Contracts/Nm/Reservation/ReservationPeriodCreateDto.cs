using System;
using System.ComponentModel.DataAnnotations;

namespace Nm.Reservation
{
    public class ReservationPeriodCreateDto
    {
        [Required]
        public DateTime StartTime
        {
            get;
            set;
        }
        [Required]
        public DateTime EndTime
        {
            get;
            set;
        }
        [Required]
        [StringLength(ReservationPeriodConsts.MaxNameLength)]
        public string Name
        {
            get;
            set;
        }
    }
}
