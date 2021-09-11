using Application.interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DepartmentFeatures.Commands
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }

        public Guid ConcurrencyToken { get; set; } = Guid.NewGuid();

        public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateDepartmentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
            {
                var entity = new Department();
                entity.Name = command.Name;
                entity.Budget = command.Budget;
                entity.StartDate = command.StartDate;
                entity.InstructorID = command.InstructorID;
                _context.Departments.Add(entity);
                await _context.SaveChangesAsync();
                return entity.ID;
            }
        }
    }
}
