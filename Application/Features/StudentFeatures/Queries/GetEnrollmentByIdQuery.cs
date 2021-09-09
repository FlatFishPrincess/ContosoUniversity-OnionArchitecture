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
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int ID { get; set; }
        public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
        {
            private readonly IApplicationDbContext _context;
            public GetStudentByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = _context.Students
                                .Where(a => a.ID == query.ID)
                                .FirstOrDefault();
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
