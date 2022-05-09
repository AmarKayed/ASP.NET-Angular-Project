using student_platform.DAL.Entities;
using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentModels>> GetAll();
        Task<Student> GetById(int id);
        Task Create(Student student);
        Task Update(Student student);
        Task Delete(Student student);
        Task<IQueryable<Student>> GetAllQuery();
    }
}
