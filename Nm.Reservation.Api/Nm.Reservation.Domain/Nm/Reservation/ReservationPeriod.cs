using JetBrains.Annotations;
using System;
using Volo.Abp.Domain.Entities;

namespace Nm.Reservation
{
    /// <summary>
    /// 时间段
    /// </summary>
    public class ReservationPeriod : Entity<Guid>
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get;
            set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get;
            set;
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 预约条件Id
        /// </summary>
        public Guid RCId
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
        private ReservationPeriod()
        { }
        public ReservationPeriod(
            Guid id, [NotNull]DateTime startTime, [NotNull]DateTime endTime,
            [NotNull]string name, Guid rcId)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Name = name;
            RCId = rcId;
        }
    }
}
