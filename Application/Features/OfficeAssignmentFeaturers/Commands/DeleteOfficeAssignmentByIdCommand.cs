using Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OfficeAssignmentFeatures.Commands
{
    public class DeleteOfficeAssignmentByIdCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class DeleteOfficeAssignmentByIdCommandHandler : IRequestHandler<DeleteOfficeAssignmentByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteOfficeAssignmentByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteOfficeAssignmentByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _context.OfficeAssignments.Where(a => a.ID == command.ID).FirstOrDefaultAsync();
                if (entity == null) return default;
                _context.OfficeAssignments.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.ID;
            }
        }
    }
}
