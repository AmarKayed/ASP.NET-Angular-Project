using Microsoft.EntityFrameworkCore;
using student_platform.DAL.Entities;
using student_platform.DAL.Interfaces;
using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.DAL.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;
        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(int studentId, TeacherModels teacherModel)
        {
            Teacher teacher = new Teacher
            {
                Name = teacherModel.Name,
                Course = teacherModel.Course
            };

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

            StudentTeacher studentTeacher = new StudentTeacher()
            {
                StudentId = studentId,
                TeacherId = teacher.Id
            };

            await _context.StudentTeachers.AddAsync(studentTeacher);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Teacher teacher = await _context.Teachers.FindAsync(id);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TeacherModels>> GetAll()
        {

            var teachers = await (await GetAllQuery()).ToListAsync();
            var list = new List<TeacherModels>();
            foreach (var teacher in teachers)
            {
                var teacherModel = new TeacherModels
                {
                    Name = teacher.Name,
                    Course = teacher.Course
                };
                list.Add(teacherModel);
            }
            return list;
            // Inainte de a schimba Task<List<Teacher>> in Task<List<TeacherModels>>
            /*
            var teachers = await (await GetAllQuery()).ToListAsync();
            return teachers;
            */
        }

        public async Task<IQueryable<Teacher>> GetAllQuery()
        {
            var query = _context.Teachers.AsQueryable();
            return query;
        }

        public async Task<TeacherModels> GetById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            var teacherModel = new TeacherModels
            {
                Name = teacher.Name,
                Course = teacher.Course
            };
            return teacherModel;
        }

        public async Task Update(int id, TeacherModels teacherModel)
        {
            Teacher teacher = await _context.Teachers.FindAsync(id);
            teacher.Name = teacherModel.Name; teacher.Course = teacherModel.Course;
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

    }
}
