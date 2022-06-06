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
        Task<StudentAddressModels> GetByStudentId(int studentId);
        Task UpdateByStudentId(int studentId, StudentAddressModels studentAddressModels);

        Task<List<StudentAddressModels>> GetAll();
        Task<StudentAddressModels> GetById(int id);
        Task Create(int studentId, StudentAddressModels studentAddressModel);
        Task Update(int id, StudentAddressModels studentAddressModel);
        Task Delete(int id);
        Task<IQueryable<StudentAddress>> GetAllQuery();
    }
}
