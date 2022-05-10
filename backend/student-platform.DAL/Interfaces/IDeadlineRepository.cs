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
        Task<List<DeadlineModels>> GetAll();
        Task<DeadlineModels> GetById(int id);
        Task Create(DeadlineModels deadlineModel);
        Task Update(Deadline deadline);
        Task Delete(Deadline deadline);
        Task<IQueryable<Deadline>> GetAllQuery();
    }
}
