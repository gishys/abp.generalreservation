using System;
using System.Collections.Generic;
using System.Text;

namespace Nm.Reservation
{
    public class ReservationConditionDto
    {
        public string ItemName
        {
            get;
            protected set;
        }
        public string ItemValue
        {
            get;
            protected set;
        }
        public ICollection<ReservationConditionDto> ChildResConditions
        {
            get;
            set;
        }
    }
}
