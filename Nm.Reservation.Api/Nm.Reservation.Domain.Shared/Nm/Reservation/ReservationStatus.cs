using System;
using System.Collections.Generic;
using System.Text;

namespace Nm.Reservation
{
    public enum ReservationStatus
    {
        /// <summary>
        /// 已预约
        /// </summary>
        Reserved = 0,
        /// <summary>
        /// 已取消
        /// </summary>
        Cancelled = 1,
        /// <summary>
        /// 爽约
        /// </summary>
        BreakAnAppointment = 2,
        /// <summary>
        /// 已完成
        /// </summary>
        Completed = 3,
        /// <summary>
        /// 已关闭
        /// </summary>
        Closed = 4
    }
}
