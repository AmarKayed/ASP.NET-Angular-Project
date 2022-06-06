using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
        public string Email { get; set; }
        public virtual StudentAddress StudentAddress { get; set; }
        public virtual ICollection<Deadline> Deadlines { get; set; }
        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
