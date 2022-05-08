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
    public class StudentTeacherConfiguration : IEntityTypeConfiguration<StudentTeacher>
    {
        public void Configure(EntityTypeBuilder<StudentTeacher> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StudentId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.TeacherId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.StudentTeachers)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.StudentTeachers)
                .HasForeignKey(x => x.TeacherId);
        }
    }
}
