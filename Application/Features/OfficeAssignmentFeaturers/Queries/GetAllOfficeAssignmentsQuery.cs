using Application.interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OfficeAssignmentFeatures.Queries
{
    public class GetAllOfficeAssignmentsQuery : IRequest<IEnumerable<OfficeAssignment>>
    {
        public class GetAllOfficeAssignmentsQueryHandler : IRequestHandler<GetAllOfficeAssignmentsQuery, IEnumerable<OfficeAssignment>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllOfficeAssignmentsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OfficeAssignment>> Handle(GetAllOfficeAssignmentsQuery query, CancellationToken cancellationToken)
            {
                var entityList = await _context.OfficeAssignments.ToListAsync();
                if (entityList == null)
                {
                    return null;
                }
                return entityList.AsReadOnly();
            }
        }
    }
}
