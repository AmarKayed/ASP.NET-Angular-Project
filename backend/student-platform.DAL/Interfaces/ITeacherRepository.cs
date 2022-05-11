using student_platform.DAL.Entities;
using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<TeacherModels>> GetAll();
        Task<TeacherModels> GetById(int id);
        Task Create(int studentId, TeacherModels teacherModel);
        Task Update(int id, TeacherModels teacherModel);
        Task Delete(int id);
        Task<IQueryable<Teacher>> GetAllQuery();
    }
}
