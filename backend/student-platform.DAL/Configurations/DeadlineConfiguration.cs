using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using student_platform.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Configurations
{
    public class DeadlineConfiguration : IEntityTypeConfiguration<Deadline>
    {
        public void Configure(EntityTypeBuilder<Deadline> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.DaysLeft)
                .HasColumnType("int")
                .IsRequired();

            builder.HasCheckConstraint("CK_DaysLeft", "[DaysLeft] >= 1");   // Doesn't allow DaysLeft to be less than 1

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Deadlines)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
