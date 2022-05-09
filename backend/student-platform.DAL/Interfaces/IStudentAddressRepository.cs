using student_platform.DAL.Entities;
using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Interfaces
{
    public interface IStudentAddressRepository
    {
        Task<List<StudentAddressModels>> GetAll();
        Task<StudentAddress> GetById(int id);
        Task Create(StudentAddress studentAddress);
        Task Update(StudentAddress studentAddress);
        Task Delete(StudentAddress studentAddress);
        Task<IQueryable<StudentAddress>> GetAllQuery();
    }
}
