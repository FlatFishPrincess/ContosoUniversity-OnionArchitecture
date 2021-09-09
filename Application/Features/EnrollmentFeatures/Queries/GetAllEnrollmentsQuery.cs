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

namespace Application.Features.CourseFeatures.Queries
{
    public class GetAllEnrollmentsQuery : IRequest<IEnumerable<Enrollment>>
    {
        public class GetAllEnrollmentsQueryHandler : IRequestHandler<GetAllEnrollmentsQuery, IEnumerable<Enrollment>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllEnrollmentsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Enrollment>> Handle(GetAllEnrollmentsQuery query, CancellationToken cancellationToken)
            {
                var entityList = await _context.Enrollments
                    .Include(e => e.Student)
                    .Include(e => e.Course)
                    .ToListAsync();

                if (entityList == null)
                {
                    return null;
                }
                return entityList.AsReadOnly();
            }
        }
    }
}
