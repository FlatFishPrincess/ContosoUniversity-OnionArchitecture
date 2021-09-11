using Application.interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InstructorFeatures.Queries
{
    public class GetInstructorByIdQuery : IRequest<Instructor>
    {
        public int ID { get; set; }
        public class GetInstructorByIdQueryHandler : IRequestHandler<GetInstructorByIdQuery, Instructor>
        {
            private readonly IApplicationDbContext _context;
            public GetInstructorByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Instructor> Handle(GetInstructorByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = _context.Instructors.Where(a => a.ID == query.ID).FirstOrDefault();
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
