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
    public class DeadlineRepository : IDeadlineRepository
    {
        private readonly AppDbContext _context;
        public DeadlineRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<DeadlineModels>> GetByStudentId(int studentId)
        {
            List<Deadline> deadlines = await _context.Deadlines.Where(x => x.StudentId == studentId).ToListAsync();
            var list = new List<DeadlineModels>();
            foreach (Deadline deadline in deadlines)
            {
                DeadlineModels deadlineModel = new DeadlineModels
                {
                    Title = deadline.Title,
                    DaysLeft = deadline.DaysLeft
                };
                list.Add(deadlineModel);
            }
            return list;
        }

        public async Task Create(int studentId, DeadlineModels deadlineModel)
        {
            var deadline = new Deadline
            {
                Title = deadlineModel.Title,
                DaysLeft = deadlineModel.DaysLeft,
                StudentId = studentId
            };
            await _context.Deadlines.AddAsync(deadline);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Deadline deadline = await _context.Deadlines.FindAsync(id);
            _context.Deadlines.Remove(deadline);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DeadlineModels>> GetAll()
        {

            var deadlines = await (await GetAllQuery()).ToListAsync();
            var list = new List<DeadlineModels>();
            foreach (var deadline in deadlines)
            {
                var deadlineModel = new DeadlineModels
                {
                    Title = deadline.Title,
                    DaysLeft = deadline.DaysLeft
                };
                list.Add(deadlineModel);
            }
            return list;
            // Inainte de a schimba Task<List<Deadline>> in Task<List<DeadlineModels>>
            /*
            var deadlines = await (await GetAllQuery()).ToListAsync();
            return deadlines;
            */
        }

        public async Task<IQueryable<Deadline>> GetAllQuery()
        {
            var query = _context.Deadlines.AsQueryable();
            return query;
        }

        public async Task<DeadlineModels> GetById(int id)
        {
            var deadline = await _context.Deadlines.FindAsync(id);
            if (deadline != null)
            {
                var deadlineModel = new DeadlineModels
                {
                    Title = deadline.Title,
                    DaysLeft = deadline.DaysLeft
                };
                return deadlineModel;
            }
            else
                return null;
        }

        public async Task Update(int id, DeadlineModels deadlineModel)
        {
            Deadline deadline = await _context.Deadlines.FindAsync(id);
            deadline.Title = deadlineModel.Title; deadline.DaysLeft = deadlineModel.DaysLeft;
            _context.Deadlines.Update(deadline);
            await _context.SaveChangesAsync();
        }

    }
}
