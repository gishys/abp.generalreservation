using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Nm.Reservation
{
    /// <summary>
    /// 预约管理信息
    /// </summary>
    public class ReservationManagerInfo : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            protected set;
        }
        /// <summary>
        /// 开放天数
        /// </summary>
        public int OpenDays
        {
            get;
            protected internal set;
        }
        /// <summary>
        /// 是否包含当天
        /// </summary>
        public bool IncludeDay
        {
            get;
            protected internal set;
        }
        /// <summary>
        /// 附记
        /// </summary>
        public string ScriptPost
        {
            get;
            set;
        }
        /// <summary>
        /// 预约条件集合
        /// </summary>
        public ICollection<ReservationCondition> ReservationConditions
        {
            get;
            protected internal set;
        }
        public ReservationManagerInfo(
            Guid id, [NotNull]string name, [NotNull]int openDays, string scriptPost = null)
        {
            Id = id;
            Name = name;
            OpenDays = openDays;
            ScriptPost = scriptPost;
            ReservationConditions = new Collection<ReservationCondition>();
        }
        public virtual void SetOpenDays(int days)
        {
            OpenDays = days;
        }
        public void SetIncludeDay(bool include)
        {
            IncludeDay = include;
        }
        public virtual void AddReservationCondition(ReservationCondition reservation)
        {
            Check.NotNull(reservation, nameof(reservation));
            ReservationConditions.Add(reservation);
        }
        public virtual void RemoveReservationCondition(ReservationCondition reservation)
        {
            Check.NotNull(reservation, nameof(reservation));
            ReservationConditions.RemoveAll(
                d => d.ItemName == reservation.ItemName && d.ItemValue == reservation.ItemValue);
        }
        public virtual ReservationCondition FindReservationCondition(string itemName)
        {
            return ReservationConditions.FirstOrDefault(d => d.ItemName == itemName);
        }
    }
}
