using Application.interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Student> SearchByName(string name)
        {
            var entities = _dbContext
                            .Students
                            .Where(s => s.FirstMidName.Contains(name) || s.LastName.Contains(name));
                            
            return entities;
        }

        public async Task<Student> GetStudentDetailById(int id)
        {
            return await _dbContext
                .Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.ID == id);


            // var entity = await _dbContext.Students.FirstOrDefaultAsync(s => s.ID == id);
        }

    }
}
