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
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public int ID { get; set; }
        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
        {
            private readonly IApplicationDbContext _context;
            public GetCourseByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Course> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = _context.Courses.Where(a => a.ID == query.ID).FirstOrDefault();
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
