using Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DepartmentFeatures.Commands
{
    public class DeleteDepartmentByIdCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class DeleteDepartmentByIdCommandHandler : IRequestHandler<DeleteDepartmentByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteDepartmentByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteDepartmentByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _context.Departments.Where(a => a.ID == command.ID).FirstOrDefaultAsync();
                if (entity == null) return default;
                _context.Departments.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.ID;
            }
        }
    }
}
