using Application.interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OfficeAssignmentFeatures.Queries
{
    public class GetOfficeAssignmentByIdQuery : IRequest<OfficeAssignment>
    {
        public int ID { get; set; }
        public class GetInstructorByIdQueryHandler : IRequestHandler<GetOfficeAssignmentByIdQuery, OfficeAssignment>
        {
            private readonly IApplicationDbContext _context;
            public GetInstructorByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<OfficeAssignment> Handle(GetOfficeAssignmentByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = _context.OfficeAssignments.Where(a => a.ID == query.ID).FirstOrDefault();
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
