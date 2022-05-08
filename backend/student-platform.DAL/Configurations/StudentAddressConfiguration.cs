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
    public class StudentAddressConfiguration : IEntityTypeConfiguration<StudentAddress>
    {
        public void Configure(EntityTypeBuilder<StudentAddress> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.City)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Country)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.HasOne(x => x.Student)
                .WithOne(x => x.StudentAddress)
                .HasForeignKey<StudentAddress>(x => x.StudentId);
        }
    }
}
