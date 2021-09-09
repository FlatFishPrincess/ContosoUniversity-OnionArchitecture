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
    public class UpdateEnrollmentCommand : IRequest<int>
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public class UpdateEnrollmentCommandHandler : IRequestHandler<UpdateEnrollmentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateEnrollmentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateEnrollmentCommand command, CancellationToken cancellationToken)
            {
                var entity = _context.Enrollments.Where(a => a.ID == command.ID).FirstOrDefault();

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.CourseID = command.CourseID;
                    entity.StudentID = command.StudentID;
                    entity.Grade = command.Grade;
                    await _context.SaveChangesAsync();
                    return entity.ID;
                }
            }
        }
    }
}
