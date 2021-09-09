using Application.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CourseFeatures.Commands
{
    public class UpdateCourseCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

        public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCourseCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
            {
                var entity = _context.Courses.Where(a => a.ID == command.ID).FirstOrDefault();

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.Title = command.Title;
                    entity.Credits = command.Credits;
                    entity.DepartmentID = command.DepartmentID;
                    await _context.SaveChangesAsync();
                    return entity.ID;
                }
            }
        }
    }
}
