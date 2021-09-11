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

namespace Application.Features.DepartmentFeatures.Queries
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<Department>>
    {
        public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<Department>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllDepartmentsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Department>> Handle(GetAllDepartmentsQuery query, CancellationToken cancellationToken)
            {
                var entityList = await _context.Departments.ToListAsync();
                if (entityList == null)
                {
                    return null;
                }
                return entityList.AsReadOnly();
            }
        }
    }
}
