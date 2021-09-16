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

namespace Application.Features.CourseFeatures.Queries
{
    public class GetAllEnrollmentsQuery : IRequest<IEnumerable<Enrollment>>
    {
        public class GetAllEnrollmentsQueryHandler : IRequestHandler<GetAllEnrollmentsQuery, IEnumerable<Enrollment>>
        {
            private readonly IEnrollmentRepository _repository;
            public GetAllEnrollmentsQueryHandler(IEnrollmentRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Enrollment>> Handle(GetAllEnrollmentsQuery query, CancellationToken cancellationToken)
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
