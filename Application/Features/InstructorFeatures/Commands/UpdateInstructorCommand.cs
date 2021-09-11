using Application.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InstructorFeatures.Commands
{
    public class UpdateInstructorCommand : IRequest<int>
    {
        public int ID { get; set; }
        public DateTime HireDate { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateInstructorCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateInstructorCommand command, CancellationToken cancellationToken)
            {
                var entity = _context.Instructors.Where(a => a.ID == command.ID).FirstOrDefault();

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.HireDate = command.HireDate;
                    entity.LastName = command.LastName;
                    entity.FirstMidName = command.FirstMidName;
                    await _context.SaveChangesAsync();
                    return entity.ID;
                }
            }
        }
    }
}
