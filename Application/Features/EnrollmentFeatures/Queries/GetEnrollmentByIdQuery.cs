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

namespace Application.Features.CourseFeatures.Queries
{
    public class GetEnrollmentByIdQuery : IRequest<Enrollment>
    {
        public int ID { get; set; }
        public class GetEnrollmentByIdQueryHandler : IRequestHandler<GetEnrollmentByIdQuery, Enrollment>
        {
            private readonly IEnrollmentRepository _repository;
            public GetEnrollmentByIdQueryHandler(IEnrollmentRepository repository)
            {
                _repository = repository;
            }
            public async Task<Enrollment> Handle(GetEnrollmentByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(query.ID);
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
