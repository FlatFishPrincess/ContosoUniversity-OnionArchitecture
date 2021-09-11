using Application.interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DepartmentFeatures.Queries
{
    public class GetDepartmentByIdQuery : IRequest<Department>
    {
        public int ID { get; set; }
        public class GetCourseByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
        {
            private readonly IApplicationDbContext _context;
            public GetCourseByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Department> Handle(GetDepartmentByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = _context.Departments.Where(a => a.ID == query.ID).FirstOrDefault();
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
