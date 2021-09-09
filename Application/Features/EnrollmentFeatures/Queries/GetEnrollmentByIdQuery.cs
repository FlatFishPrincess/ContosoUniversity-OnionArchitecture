using Application.interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CourseFeatures.Queries
{
    public class GetEnrollmentByIdQuery : IRequest<Enrollment>
    {
        public int Id { get; set; }
        public class GetEnrollmentByIdQueryHandler : IRequestHandler<GetEnrollmentByIdQuery, Enrollment>
        {
            private readonly IApplicationDbContext _context;
            public GetEnrollmentByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Enrollment> Handle(GetEnrollmentByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = _context.Enrollments
                                .Where(a => a.Id == query.Id)
                                .FirstOrDefault();
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
