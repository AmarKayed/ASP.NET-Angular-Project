using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.BLL.Interfaces
{
    public interface IStudentAddressManager
    {
        Task<StudentAddressModels> GetByStudentId(int studentId);
        Task UpdateByStudentId(int studentId, StudentAddressModels studentAddressModels);

        Task<List<StudentAddressModels>> GetAll();
        Task<StudentAddressModels> GetById(int id);
        Task Create(int studentId, StudentAddressModels studentAddressModel);
        Task Update(int id, StudentAddressModels studentAddressModel);
        Task Delete(int id);
    }
}
