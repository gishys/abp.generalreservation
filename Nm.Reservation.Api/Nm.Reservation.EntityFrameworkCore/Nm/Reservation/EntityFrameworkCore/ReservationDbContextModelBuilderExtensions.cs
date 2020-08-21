using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Nm.Reservation.EntityFrameworkCore
{
    public static class ReservationDbContextModelBuilderExtensions
    {
        public static void ConfigureReservation(
            [NotNull] this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.Entity<ReservationManagerInfo>(d =>
            {
                d.ToTable("RESMANAGERINFOS");
                d.ConfigureFullAuditedAggregateRoot();
                
                d.Property(p => p.Name).IsRequired().HasMaxLength(ReservationManagerInfoConsts.MaxNameLength).HasColumnName("NAME");
                d.Property(p => p.OpenDays).IsRequired().HasColumnName("OPENDAYS");
                d.Property(p => p.IncludeDay).IsRequired().HasColumnName("INCLUDEDAY").HasDefaultValue(true);
                d.Property(p => p.ScriptPost).HasMaxLength(ReservationManagerInfoConsts.MaxScriptPostLength).HasColumnName("SCRIPTPOST");
                d.HasMany(p => p.ReservationConditions).WithOne().HasForeignKey(p => p.RMId).IsRequired();

                d.HasIndex(p => p.Name);
            });
            builder.Entity<ReservationCondition>(d =>
            {
                d.ToTable("RESCONDITIONS");
                d.Property(p => p.Id).ValueGeneratedNever();
                d.Property(p => p.ItemName).IsRequired().HasMaxLength(ReservationConditionConsts.MaxItemNameLength).HasColumnName("ITEMNAME");
                d.Property(p => p.ItemValue).IsRequired().HasMaxLength(ReservationConditionConsts.MaxItemValueLength).HasColumnName("ITEMVALUE");
                d.Property(p => p.RMId).HasColumnName("RMID");
                d.Property(p => p.ScriptPost).HasMaxLength(ReservationConditionConsts.MaxScriptPostLength).HasColumnName("SCRIPTPOST");
                d.Property(p => p.RCType).HasColumnName("RCTYPE").HasDefaultValue(ReservationConditionType.Other);
                d.HasMany(p => p.RPeriod).WithOne().HasForeignKey(p => p.RCId);

                d.HasIndex(p => p.ItemName);
                d.HasIndex(p => p.ItemValue);
            });
            builder.Entity<ReservationPeriod>(d =>
            {
                d.ToTable("RESPERIOD");
                d.Property(p => p.StartTime).IsRequired().HasColumnName("STARTTIME");
                d.Property(p => p.EndTime).IsRequired().HasColumnName("ENDTIME");
                d.Property(p => p.Name).IsRequired().HasMaxLength(ReservationPeriodConsts.MaxNameLength).HasColumnName("NAME");
                d.Property(p => p.RCId).HasColumnName("RCID");
                d.Property(p => p.ScriptPost).HasMaxLength(ReservationPeriodConsts.MaxScriptPostLength).HasColumnName("SCRIPTPOST");
            });
        }
    }
}
