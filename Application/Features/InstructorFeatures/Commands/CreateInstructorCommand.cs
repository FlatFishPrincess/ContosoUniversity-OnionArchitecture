using Application.interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InstructorFeatures.Commands
{
    public class CreateInstructorCommand : IRequest<int>
    {
        public DateTime HireDate { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public Guid ConcurrencyToken { get; set; } = Guid.NewGuid();

        public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateInstructorCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateInstructorCommand command, CancellationToken cancellationToken)
            {
                var entity = new Instructor();
                entity.HireDate = command.HireDate;
                entity.LastName = command.LastName;
                entity.FirstMidName = command.FirstMidName;
                _context.Instructors.Add(entity);
                await _context.SaveChangesAsync();
                return entity.ID;
            }
        }
    }
}
