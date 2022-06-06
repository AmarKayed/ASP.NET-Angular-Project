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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.Major)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
        }   
    }
}
