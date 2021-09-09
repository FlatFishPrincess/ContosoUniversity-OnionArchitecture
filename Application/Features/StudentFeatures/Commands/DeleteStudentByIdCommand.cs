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
    public class DeleteStudentByIdCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteStudentByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteStudentByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _context.Students.Where(a => a.ID == command.ID).FirstOrDefaultAsync();
                if (entity == null) return default;
                _context.Students.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.ID;
            }
        }
    }
}
