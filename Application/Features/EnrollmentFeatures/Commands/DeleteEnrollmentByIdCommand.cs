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
    public class DeleteEnrollmentByIdCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class DeleteEnrollmentByIdCommandHandler : IRequestHandler<DeleteEnrollmentByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteEnrollmentByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteEnrollmentByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _context.Enrollments.Where(a => a.ID == command.ID).FirstOrDefaultAsync();
                if (entity == null) return default;
                _context.Enrollments.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.ID;
            }
        }
    }
}
