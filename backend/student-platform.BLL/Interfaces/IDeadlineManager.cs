using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.BLL.Interfaces
{
    public interface IDeadlineManager
    {
        Task<List<DeadlineModels>> GetByStudentId(int studentId);

        Task<List<DeadlineModels>> GetAll();
        Task<DeadlineModels> GetById(int id);
        Task Create(int studentId, DeadlineModels deadlineModel);
        Task Update(int id, DeadlineModels deadlineModel);
        Task Delete(int id);
    }
}
