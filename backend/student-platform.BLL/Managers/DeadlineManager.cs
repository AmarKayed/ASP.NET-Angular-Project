using student_platform.BLL.Interfaces;
using student_platform.DAL.Interfaces;
using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.BLL.Managers
{
    public class DeadlineManager : IDeadlineManager
    {
        private readonly IDeadlineRepository _deadlineRepo;
        public DeadlineManager(IDeadlineRepository deadlineRepo)
        {
            _deadlineRepo = deadlineRepo;
        }

        public async Task<List<DeadlineModels>> GetByStudentId(int studentId)
        {
            return await _deadlineRepo.GetByStudentId(studentId);
        }

        public async Task<List<DeadlineModels>> GetAll()
        {
            return (await _deadlineRepo.GetAll());
        }
        public async Task<DeadlineModels> GetById(int id)
        {
            return (await _deadlineRepo.GetById(id));
        }
        public async Task Create(int studentId, DeadlineModels deadlineModel)
        {
            await _deadlineRepo.Create(studentId, deadlineModel);
        }
        public async Task Update(int id, DeadlineModels deadlineModel)
        {
            await _deadlineRepo.Update(id, deadlineModel);
        }
        public async Task Delete(int id)
        {
            await _deadlineRepo.Delete(id);
        }

    }
}
