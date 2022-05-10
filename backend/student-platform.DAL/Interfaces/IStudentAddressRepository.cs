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
        Task<StudentAddressModels> GetById(int id);
        Task Create(StudentAddressModels studentAddressModel);
        Task Update(StudentAddress studentAddress);
        Task Delete(StudentAddress studentAddress);
        Task<IQueryable<StudentAddress>> GetAllQuery();
    }
}
