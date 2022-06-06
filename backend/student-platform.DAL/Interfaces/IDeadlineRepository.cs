using student_platform.DAL.Entities;
using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Interfaces
{
    public interface IDeadlineRepository
    {
        Task<List<DeadlineModels>> GetByStudentId(int studentId);

        Task<List<DeadlineModels>> GetAll();
        Task<DeadlineModels> GetById(int id);
        Task Create(int studentId, DeadlineModels deadlineModel);
        Task Update(int id, DeadlineModels deadlineModel);
        Task Delete(int id);
        Task<IQueryable<Deadline>> GetAllQuery();
    }
}
