using student_platform.BLL.Interfaces;
using student_platform.DAL.Entities;
using student_platform.DAL.Interfaces;
using student_platform.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.BLL.Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRepo;
        public StudentManager(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }


        public async Task<List<StudentJoinStudentAddressModels>> GetAddress()
        {
            return (await _studentRepo.GetAddress());
        }

        public async Task<List<string>> GetMajor(string major)
        {
            var students = await _studentRepo.GetMajor(major);
            List<string> names = new List<string>();
            foreach(var student in students)
            {
                names.Add(student.Name);
            }
            return names;
        }

        public async Task<Object> GetMajorCount()
        {
            return await _studentRepo.GetMajorCount();
        }

        public async Task<List<string>> ModifyStudent()
        {
            var students = await _studentRepo.GetAll();
            var list = new List<string>();

            foreach (var student in students)
            {
                list.Add($"StudentName: {student.Name}");
            }

            return list;
        }

        public async Task<Object> GetJoin()
        {
            return await _studentRepo.GetJoin();
        }

        public async Task<int> GetIdByEmail(string email)
        {
            return await _studentRepo.GetIdByEmail(email);
        }



        public async Task<List<StudentModels>> GetAll()
        {
            return (await _studentRepo.GetAll());
        }
        public async Task<StudentModels> GetById(int id)
        {
            return (await _studentRepo.GetById(id));
        }
        public async Task Create(StudentModels studentModel)
        {
            await _studentRepo.Create(studentModel);
        }
        public async Task Update(int id, StudentModels studentModel)
        {
            await _studentRepo.Update(id, studentModel);
        }
        public async Task Delete(int id)
        {
            await _studentRepo.Delete(id);
        }

    }
}
