using student_platform.BLL.Interfaces;
using student_platform.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.BLL.Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRepo;
        public StudentManager(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public async Task<List<string>> ModifyStudent()
        {
            var students = await _studentRepo.GetAll();
            var list = new List<string>();

            foreach (var student in students)
            {
                list.Add($"StudentName: {student.Name}");
            }

            return list;
        }
    }
}
