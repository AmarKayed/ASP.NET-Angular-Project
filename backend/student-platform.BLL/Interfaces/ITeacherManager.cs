using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.BLL.Interfaces
{
    public interface ITeacherManager
    {
        Task<List<TeacherModels>> GetAll();
        Task<TeacherModels> GetById(int id);
        Task Create(int studentId, TeacherModels teacherModel);
        Task Update(int id, TeacherModels teacherModel);
        Task Delete(int id);
    }
}
