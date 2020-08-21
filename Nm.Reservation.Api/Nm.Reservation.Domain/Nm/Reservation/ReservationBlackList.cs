using System;
using System.Collections.Generic;
using System.Text;

namespace Nm.Reservation
{
    public class ReservationBlackList
    {
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdentityCard
        {
            get;
            set;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 限制期
        /// </summary>
        public ReservationPeriod LimitPeriod
        {
            get;
            set;
        }
        /// <summary>
        /// 启用
        /// </summary>
        public bool Enable
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
