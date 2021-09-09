using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<Student> Students { get; set; }

        DbSet<Instructor> Instructors { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        Task<int> SaveChangesAsync();
    }
}
