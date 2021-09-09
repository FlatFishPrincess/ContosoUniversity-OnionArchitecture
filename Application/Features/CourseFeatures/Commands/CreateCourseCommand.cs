using Application.interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CourseFeatures.Commands
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        // public ICollection<Enrollment> Enrollments { get; set; }
        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCourseCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
            {
                var entity = new Course();
                entity.Title = command.Title;
                entity.Credits = command.Credits;
                entity.DepartmentID = command.DepartmentID;
                // entity.Enrollments = command.Enrollments;
                _context.Courses.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
        }
    }
}
