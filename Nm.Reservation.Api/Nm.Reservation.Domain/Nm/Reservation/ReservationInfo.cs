namespace Nm.Reservation
{
    public class ReservationInfo
    {
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// 预约编号
        /// </summary>
        public string Number
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
        /// 有效期
        /// </summary>
        public ReservationPeriod ValidityPeriod
        {
            get;
            set;
        }
        /// <summary>
        /// 预约状态
        /// </summary>
        public ReservationStatus Status
        {
            get;
            set;
        }
    }
}
