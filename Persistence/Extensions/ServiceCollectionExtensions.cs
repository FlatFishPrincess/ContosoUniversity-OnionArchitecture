using Application.interfaces;
using Application.interfaces.Helpers;
using Application.interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Helpers;
using Persistence.Repositories;
using System.Reflection;

namespace Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IOfficeAssignmentRepository, OfficeAssignmentRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }

        public static void AddHelpers(this IServiceCollection services)
        {
            services.AddScoped<ISortHelper<Course>, SortHelper<Course>>();
            services.AddScoped<ISortHelper<Department>, SortHelper<Department>>();
            services.AddScoped<ISortHelper<Enrollment>, SortHelper<Enrollment>>();
            services.AddScoped<ISortHelper<Instructor>, SortHelper<Instructor>>();
            services.AddScoped<ISortHelper<OfficeAssignment>, SortHelper<OfficeAssignment>>();
            services.AddScoped<ISortHelper<Student>, SortHelper<Student>>();
        }
    }
}