using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Nm.Reservation
{
    /// <summary>
    /// 预约条件
    /// </summary>
    public class ReservationCondition : Entity<Guid>
    {
        /// <summary>
        /// 项名称
        /// </summary>
        public string ItemName
        {
            get;
            protected set;
        }
        /// <summary>
        /// 项值
        /// </summary>
        public string ItemValue
        {
            get;
            protected set;
        }
        /// <summary>
        /// 预约管理Id
        /// </summary>
        public Guid RMId
        {
            get;
            protected set;
        }
        /// <summary>
        /// 预约条件类型
        /// </summary>
        public ReservationConditionType RCType
        {
            get;
            protected set;
        }
        /// <summary>
        /// 附记
        /// </summary>
        public string ScriptPost
        {
            get;
            protected set;
        }
        /// <summary>
        /// 预约时间段
        /// </summary>
        public ICollection<ReservationPeriod> RPeriod
        {
            get;
            protected set;
        }
        /// <summary>
        /// 预约条件
        /// </summary>
        public ICollection<ReservationCondition> ChildResConditions
        {
            get;
            protected set;
        }
        private ReservationCondition()
        { }
        public ReservationCondition(
            Guid id, [NotNull]string itemName, [NotNull]string itemValue,
             ReservationConditionType rcType, Guid rmId, string scriptPost = null)
        {
            Id = id;
            ItemName = itemName;
            ItemValue = itemValue;
            ScriptPost = scriptPost;
            RMId = rmId;
            RCType = rcType;
            ChildResConditions = new Collection<ReservationCondition>();
            RPeriod = new Collection<ReservationPeriod>();
        }
        public void AddReservationCondition(ReservationCondition reservation)
        {
            Check.NotNull(reservation, nameof(reservation));
            ChildResConditions.Add(reservation);
        }
        public virtual void RemoveReservationCondition(ReservationCondition reservation)
        {
            Check.NotNull(reservation, nameof(reservation));
            ChildResConditions.RemoveAll(
                d => d.ItemName == reservation.ItemName && d.ItemValue == reservation.ItemValue);
        }
        public virtual ReservationCondition FindReservationCondition(string itemName)
        {
            Check.NotNull(itemName, nameof(itemName));
            return ChildResConditions.FirstOrDefault(d => d.ItemName == itemName);
        }
        public void AddResPeriod(ReservationPeriod period)
        {
            Check.NotNull(period, nameof(period));
            RPeriod.Add(period);
        }
    }
}
