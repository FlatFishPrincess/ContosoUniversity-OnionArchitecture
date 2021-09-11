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

namespace Application.Features.InstructorFeatures.Queries
{
    public class GetAllInstructorsQuery : IRequest<IEnumerable<Instructor>>
    {
        public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstructorsQuery, IEnumerable<Instructor>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllInstructorsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Instructor>> Handle(GetAllInstructorsQuery query, CancellationToken cancellationToken)
            {
                var entityList = await _context.Instructors.ToListAsync();
                if (entityList == null)
                {
                    return null;
                }
                return entityList.AsReadOnly();
            }
        }
    }
}
