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
        Task<Teacher> GetById(int id);
        Task Create(Teacher teacher);
        Task Update(Teacher teacher);
        Task Delete(Teacher teacher);
        Task<IQueryable<Teacher>> GetAllQuery();
    }
}
