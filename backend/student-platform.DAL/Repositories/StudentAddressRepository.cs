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
    public class StudentAddressRepository : IStudentAddressRepository
    {
        private readonly AppDbContext _context;
        public StudentAddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StudentAddressModels> GetByStudentId(int studentId)
        {
            var studentAddress = await _context.StudentAddresses.Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
            if (studentAddress == null)
                return null;
            StudentAddressModels studentAddressModel = new StudentAddressModels()
            {
                City = studentAddress.City,
                Country = studentAddress.Country
            };
            return studentAddressModel;
        }

        public async Task UpdateByStudentId(int studentId, StudentAddressModels studentAddressModel)
        {
            var studentAddress = await _context.StudentAddresses.Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
            if (studentAddress != null)
            {
                studentAddress.City = studentAddressModel.City;
                studentAddress.Country = studentAddressModel.Country;
                _context.StudentAddresses.Update(studentAddress);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<List<StudentAddressModels>> GetAll()
        {
            var studentAddresses = await (await GetAllQuery()).ToListAsync();
            var list = new List<StudentAddressModels>();
            foreach (var studentAddress in studentAddresses)
            {
                var studentAddressModel = new StudentAddressModels
                {
                    City = studentAddress.City,
                    Country = studentAddress.Country
                };
                list.Add(studentAddressModel);
            }
            return list;
            // Inainte de a schimba Task<List<StudentAddress>> in Task<List<StudentAddressModels>>
            /*
            var studentAddresses = await (await GetAllQuery()).ToListAsync();
            return studentAddresses;
            */
        }

        public async Task<StudentAddressModels> GetById(int id)
        {
            var studentAddress = await _context.StudentAddresses.FindAsync(id);
            StudentAddressModels studentAddressModel = new StudentAddressModels
            {
                City = studentAddress.City,
                Country = studentAddress.Country
            };
            return studentAddressModel;
        }

        public async Task Create(int studentId, StudentAddressModels studentAddressModel)
        {
            if ((await _context.StudentAddresses.FirstOrDefaultAsync(x => x.StudentId == studentId)) != null)
                return;
            StudentAddress studentAddress = new StudentAddress
            {
                City = studentAddressModel.City,
                Country = studentAddressModel.Country,
                StudentId = studentId
            };
            await _context.StudentAddresses.AddAsync(studentAddress);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, StudentAddressModels studentAddressModel)
        {
            StudentAddress studentAddress = await _context.StudentAddresses.FindAsync(id);
            studentAddress.City = studentAddressModel.City; 
            studentAddress.Country = studentAddressModel.Country;
            _context.StudentAddresses.Update(studentAddress);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            StudentAddress studentAddress = await _context.StudentAddresses.FindAsync(id);
            _context.StudentAddresses.Remove(studentAddress);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<StudentAddress>> GetAllQuery()
        {
            var query = _context.StudentAddresses.AsQueryable();
            return query;
        }
    }
}
