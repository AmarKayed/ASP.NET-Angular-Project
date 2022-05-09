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

        public async Task<List<StudentAddressModels>> GetAll()
        {
            var studentAddresses = await (await GetAllQuery()).ToListAsync();
            var list = new List<StudentAddressModels>();
            foreach (var studentAddress in studentAddresses)
            {
                var studentModel = new StudentAddressModels
                {
                    City = studentAddress.City,
                    Country = studentAddress.Country
                };
                list.Add(studentModel);
            }
            return list;
            // Inainte de a schimba Task<List<StudentAddress>> in Task<List<StudentAddressModels>>
            /*
            var studentAddresses = await (await GetAllQuery()).ToListAsync();
            return studentAddresses;
            */
        }

        public async Task<StudentAddress> GetById(int id)
        {
            var studentAddress = await _context.StudentAddresses.FindAsync(id);
            return studentAddress;
        }

        public async Task Create(StudentAddress studentAddress)
        {
            await _context.StudentAddresses.AddAsync(studentAddress);
            await _context.SaveChangesAsync();
        }

        public async Task Update(StudentAddress studentAddress)
        {
            _context.StudentAddresses.Update(studentAddress);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(StudentAddress studentAddress)
        {
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
