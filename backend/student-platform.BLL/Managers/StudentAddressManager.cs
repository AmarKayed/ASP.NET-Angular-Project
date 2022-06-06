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
    public class StudentAddressManager : IStudentAddressManager
    {

        private readonly IStudentAddressRepository _studentAddressRepo;
        public StudentAddressManager(IStudentAddressRepository studentAddressRepo)
        {
            _studentAddressRepo = studentAddressRepo;
        }

        public async Task<StudentAddressModels> GetByStudentId(int studentId)
        {
            return await _studentAddressRepo.GetByStudentId(studentId);
        }

        public async Task UpdateByStudentId(int studentId, StudentAddressModels studentAddressModels)
        {
            await _studentAddressRepo.UpdateByStudentId(studentId, studentAddressModels);
        }



        public async Task<List<StudentAddressModels>> GetAll()
        {
            return (await _studentAddressRepo.GetAll());
        }
        public async Task<StudentAddressModels> GetById(int id)
        {
            return (await _studentAddressRepo.GetById(id));
        }
        public async Task Create(int studentId, StudentAddressModels studentAddressModel)
        {
            await _studentAddressRepo.Create(studentId, studentAddressModel);
        }
        public async Task Update(int id, StudentAddressModels studentAddressModel)
        {
            await _studentAddressRepo.Update(id, studentAddressModel);
        }
        public async Task Delete(int id)
        {
            await _studentAddressRepo.Delete(id);
        }
    }
}
