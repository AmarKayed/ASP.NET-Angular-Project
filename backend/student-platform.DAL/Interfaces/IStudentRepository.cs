using student_platform.DAL.Entities;
using student_platform.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentJoinStudentAddressModels>> GetAddress();
        Task<List<StudentModels>> GetMajor(string major);
        Task<Object> GetMajorCount();
        Task<Object> GetJoin();
        Task<int> GetIdByEmail(string email);


        Task<List<StudentModels>> GetAll();
        Task<StudentModels> GetById(int id);
        Task Create(StudentModels studentModel);
        Task Update(int id, StudentModels studentModel);
        Task Delete(int id);
        Task<IQueryable<Student>> GetAllQuery();
    }
}
