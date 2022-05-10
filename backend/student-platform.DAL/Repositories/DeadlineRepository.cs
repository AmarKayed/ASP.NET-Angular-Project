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
        public async Task Create(DeadlineModels deadlineModel)
        {
            var deadline = new Deadline
            {
                Title = deadlineModel.Title,
                DaysLeft = deadlineModel.DaysLeft
            };
            await _context.Deadlines.AddAsync(deadline);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Deadline deadline)
        {
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
            var deadlineModel = new DeadlineModels
            {
                Title = deadline.Title,
                DaysLeft = deadline.DaysLeft
            };
            return deadlineModel;
        }

        public async Task Update(Deadline deadline)
        {
            _context.Deadlines.Update(deadline);
            await _context.SaveChangesAsync();
        }

    }
}
