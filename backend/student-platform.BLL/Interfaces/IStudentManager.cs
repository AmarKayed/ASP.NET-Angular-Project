using student_platform.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.BLL.Interfaces
{
    public interface IStudentManager
    {
        Task<List<StudentJoinStudentAddressModels>> GetAddress();
        Task<List<string>> GetMajor(string major);
        Task<Object> GetMajorCount();
        Task<List<string>> ModifyStudent();
        Task<Object> GetJoin();
        Task<int> GetIdByEmail(string email);


        Task<List<StudentModels>> GetAll();
        Task<StudentModels> GetById(int id);
        Task Create(StudentModels studentModel);
        Task Update(int id, StudentModels studentModel);
        Task Delete(int id);
    }
}
