using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
