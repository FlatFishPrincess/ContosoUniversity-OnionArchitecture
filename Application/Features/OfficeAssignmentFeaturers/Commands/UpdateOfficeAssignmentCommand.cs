using Application.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OfficeAssignmentFeatures.Commands
{
    public class UpdateOfficeAssignmentCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public int? InstructorID { get; set; }

        public class UpdateOfficeAssignmentCommandHandler : IRequestHandler<UpdateOfficeAssignmentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateOfficeAssignmentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateOfficeAssignmentCommand command, CancellationToken cancellationToken)
            {
                var entity = _context.OfficeAssignments.Where(a => a.ID == command.ID).FirstOrDefault();

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.Location = command.Location;
                    entity.InstructorID = command.InstructorID;
                    await _context.SaveChangesAsync();
                    return entity.ID;
                }
            }
        }
    }
}
