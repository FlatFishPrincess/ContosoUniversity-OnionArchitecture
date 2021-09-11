using Application.interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OfficeAssignmentFeatures.Commands
{
    public class CreateOfficeAssignmentCommand : IRequest<int>
    {
        public string Location { get; set; }
        public int? InstructorID { get; set; }


        public class CreateInstructorCommandHandler : IRequestHandler<CreateOfficeAssignmentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateInstructorCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateOfficeAssignmentCommand command, CancellationToken cancellationToken)
            {
                var entity = new OfficeAssignment();
                entity.Location = command.Location;
                entity.InstructorID = command.InstructorID;
                _context.OfficeAssignments.Add(entity);
                await _context.SaveChangesAsync();
                return entity.ID;
            }
        }
    }
}
