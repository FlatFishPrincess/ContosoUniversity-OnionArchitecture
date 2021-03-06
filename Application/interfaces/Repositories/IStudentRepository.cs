using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        IQueryable<Student> SearchByName(String name);

        Task<Student> GetStudentDetailById(int id);

    }
}
