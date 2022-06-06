using Microsoft.EntityFrameworkCore;
using student_platform.DAL.Entities;
using student_platform.DAL.Interfaces;
using student_platform.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentJoinStudentAddressModels>> GetAddress()
        {
            var joinResult = await (await GetAllQuery())
                .Include(x => x.StudentAddress)
                .Where(x => x.StudentAddress != null)
                .ToListAsync();
            List<StudentJoinStudentAddressModels> studentJoinAddressList = new List<StudentJoinStudentAddressModels>();
            foreach(var join in joinResult)
            {
                StudentJoinStudentAddressModels studentJoinAddressModel = new StudentJoinStudentAddressModels
                {
                    Name = join.Name,
                    Major = join.Major,
                    Email = join.Email,
                    City = join.StudentAddress.City,
                    Country = join.StudentAddress.Country
                };
                studentJoinAddressList.Add(studentJoinAddressModel);
            }
            return studentJoinAddressList;
        }

        public async Task<List<StudentModels>> GetMajor(string major)
        {
            var students = _context.Students
                .Where(x => x.Major == major)
                .OrderBy(x => x.Name);
            List<StudentModels> studentModels = new List<StudentModels>();
            foreach(var student in students)
            {
                StudentModels studentModel = new StudentModels
                {
                    Name = student.Name,
                    Major = student.Major,
                    Email = student.Email
                };
                studentModels.Add(studentModel);
            }
            return studentModels;
        }

        public async Task<Object> GetMajorCount()
        {
            var result = await _context.Students
                .GroupBy(x => x.Major)
                .Select(x => new
                {
                    Major = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .ToListAsync();
            return result;
        }
        
        public async Task<Object> GetJoin()
        {
            var students = _context.Students;
            var join = await _context.Deadlines
                .Join(students, b => b.StudentId, a => a.Id, (b, a) => new
                {
                    a.Name,
                    a.Major,
                    b.Title,
                    b.DaysLeft,
                }).ToListAsync();

            return join;
        }


        public async Task<int> GetIdByEmail(string email)
        {
            return await _context.Students.Where(x => x.Email == email).Select(x => x.Id).FirstOrDefaultAsync();
        }




        public async Task<List<StudentModels>> GetAll()
        {
            var students = await (await GetAllQuery()).ToListAsync();
            List<StudentModels> list = new List<StudentModels>();
            foreach (var student in students)
            {
                StudentModels studentModel = new StudentModels
                {
                    Name = student.Name,
                    Major = student.Major,
                    Email = student.Email
                };
                list.Add(studentModel);
            }
            return list;
            // Inainte de a schimba Task<List<Student>> in Task<List<StudentModels>>
            /*
            var students = await (await GetAllQuery()).ToListAsync();
            return students;
            */
        }

        public async Task<StudentModels> GetById(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            StudentModels studentModel = new StudentModels
            {
                Name = student.Name,
                Major = student.Major,
                Email = student.Email
            };
            return studentModel;
        }

        public async Task Create(StudentModels studentModel)
        {
            var student = new Student { 
                Name = studentModel.Name,
                Major = studentModel.Major,
                Email = studentModel.Email
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, StudentModels studentModel)
        {
            Student student = await _context.Students.FindAsync(id);
            student.Name = studentModel.Name; student.Major = studentModel.Major;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            
            List<Deadline> studentDeadlines = await _context.Deadlines.Where(x => x.StudentId == id).ToListAsync();
            foreach(var studentDeadline in studentDeadlines)
            {
                _context.Deadlines.Remove(studentDeadline);
            }

            List<StudentAddress> studentAddresses = await _context.StudentAddresses.Where(x => x.StudentId == id).ToListAsync();
            foreach(var studentAddress in studentAddresses)
            {
                _context.StudentAddresses.Remove(studentAddress);
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<Student>> GetAllQuery()
        {
            var query = _context.Students.AsQueryable();
            return query;
        }
    }
}
