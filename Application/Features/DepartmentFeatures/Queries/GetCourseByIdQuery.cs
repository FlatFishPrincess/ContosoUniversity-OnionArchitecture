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

namespace Application.Features.DepartmentFeatures.Queries
{
    public class GetDepartmentByIdQuery : IRequest<Department>
    {
        public int ID { get; set; }
        public class GetCourseByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
        {
            private readonly IDepartmentRepository _repository;
            public GetCourseByIdQueryHandler(IDepartmentRepository repository)
            {
                _repository = repository;
            }
            public async Task<Department> Handle(GetDepartmentByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(query.ID);
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
