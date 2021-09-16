using Application.interfaces;
using Application.interfaces.Repositories;
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
            private readonly IOfficeAssignmentRepository _repository;
            public GetInstructorByIdQueryHandler(IOfficeAssignmentRepository repository)
            {
                _repository = repository;
            }
            public async Task<OfficeAssignment> Handle(GetOfficeAssignmentByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(query.ID);
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
