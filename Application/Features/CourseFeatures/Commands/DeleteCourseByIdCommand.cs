using Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CourseFeatures.Commands
{
    public class DeleteCourseByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCourseByIdCommandHandler : IRequestHandler<DeleteCourseByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCourseByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCourseByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _context.Courses.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (entity == null) return default;
                _context.Courses.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
        }
    }
}
