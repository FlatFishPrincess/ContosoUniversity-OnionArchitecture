using Application.interfaces;
using Application.interfaces.Repositories;
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
            private readonly IOfficeAssignmentRepository _repository;
            public GetAllOfficeAssignmentsQueryHandler(IOfficeAssignmentRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<OfficeAssignment>> Handle(GetAllOfficeAssignmentsQuery query, CancellationToken cancellationToken)
            {
                var entityList = await _repository.GetAllAsync();
                if (entityList == null)
                {
                    return null;
                }
                return entityList.AsReadOnly();
            }
        }
    }
}
