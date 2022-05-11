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
    public class TeacherManager : ITeacherManager
    {
        private readonly ITeacherRepository _teacherRepo;
        public TeacherManager(ITeacherRepository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        public async Task<List<TeacherModels>> GetAll()
        {
            return (await _teacherRepo.GetAll());
        }
        public async Task<TeacherModels> GetById(int id)
        {
            return (await _teacherRepo.GetById(id));
        }
        public async Task Create(int studentId, TeacherModels teacherModel)
        {
            await _teacherRepo.Create(studentId, teacherModel);
        }
        public async Task Update(int id, TeacherModels teacherModel)
        {
            await _teacherRepo.Update(id, teacherModel);
        }
        public async Task Delete(int id)
        {
            await _teacherRepo.Delete(id);
        }

    }
}
