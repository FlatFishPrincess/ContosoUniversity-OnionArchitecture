using Application.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DepartmentFeatures.Commands
{
    public class UpdateDepartmentCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }

        public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateDepartmentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
            {
                var entity = _context.Departments.Where(a => a.ID == command.ID).FirstOrDefault();

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.Name = command.Name;
                    entity.Budget = command.Budget;
                    entity.StartDate = command.StartDate;
                    entity.InstructorID = command.InstructorID;
                    await _context.SaveChangesAsync();
                    return entity.ID;
                }
            }
        }
    }
}
