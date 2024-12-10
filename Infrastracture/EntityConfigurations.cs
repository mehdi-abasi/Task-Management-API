using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50).HasDefaultValueSql("('')");
            builder.Property(x => x.Description).IsRequired().HasDefaultValueSql("('')");
        }
    }
    public class EmploeeConfiguration : BaseConfiguration<TblEmploee>
    {
       

        public override void Configure(EntityTypeBuilder<TblEmploee> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValueSql("((0))");
            builder.Property(x => x.JoinDate).IsRequired().HasDefaultValueSql("('2000-01-01 00:00:00')");
            
        }
    }
    public class TaskConfiguration : BaseConfiguration<TblTask>
    {


        public override void Configure(EntityTypeBuilder<TblTask> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50).HasDefaultValueSql("('')");
            builder.Property(x => x.TblEmploeeID).IsRequired().HasDefaultValueSql("((0))");
            builder.Property(x => x.IsCompleted).IsRequired().HasDefaultValueSql("((0))");
            builder.Property(x => x.StartDate).IsRequired().HasDefaultValueSql("('2000-01-01 00:00:00')");
            builder.Property(x => x.DueDate).IsRequired().HasDefaultValueSql("('2000-01-01 00:00:00')");

        }
    }
}
