using Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InstructorFeatures.Commands
{
    public class DeleteInstructorByIdCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class DeleteInstructorByIdCommandHandler : IRequestHandler<DeleteInstructorByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteInstructorByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteInstructorByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _context.Instructors.Where(a => a.ID == command.ID).FirstOrDefaultAsync();
                if (entity == null) return default;
                _context.Instructors.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.ID;
            }
        }
    }
}
