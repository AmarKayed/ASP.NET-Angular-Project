﻿using Microsoft.EntityFrameworkCore;
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
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
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
                    Major = student.Major
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
                Major = student.Major
            };
            return studentModel;
        }

        public async Task Create(StudentModels studentModel)
        {
            var student = new Student { 
                Name = studentModel.Name,
                Major = studentModel.Major
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
