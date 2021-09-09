using Application.interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CourseFeatures.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateStudentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                var entity = _context.Students.Where(a => a.Id == command.Id).FirstOrDefault();

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.LastName = command.LastName;
                    entity.FirstMidName = command.FirstMidName;
                    entity.EnrollmentDate = command.EnrollmentDate;
                    await _context.SaveChangesAsync();
                    return entity.Id;
                }
            }
        }
    }
}
