using System;
using System.Collections.Generic;
using System.Text;

namespace Nm.Reservation
{
    /// <summary>
    /// 预约资源池
    /// </summary>
    public class ReservationResourcePool
    {
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// 预约资源总数
        /// </summary>
        public int Total
        {
            get;
            set;
        }
        public int BookableNumber
        {
            get;
            set;
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable
        {
            get;
            set;
        }
        /// <summary>
        /// 是否可以重放
        /// </summary>
        public bool Replay
        {
            get;
            set;
        }
        /// <summary>
        /// 时间Id
        /// </summary>
        public string DatetimeId
        {
            get;
            set;
        }
        /// <summary>
        /// 位置Id
        /// </summary>
        public string LocationId
        {
            get;
            set;
        }
        /// <summary>
        /// 办理事物Id
        /// </summary>
        public string TransactionId
        {
            get;
            set;
        }
        /// <summary>
        /// 附记
        /// </summary>
        public string ScriptPost
        {
            get;
            set;
        }
    }
}
