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

namespace Application.Features.DepartmentFeatures.Queries
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<Department>>
    {
        public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<Department>>
        {
            private readonly IDepartmentRepository _repository;
            public GetAllDepartmentsQueryHandler(IDepartmentRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Department>> Handle(GetAllDepartmentsQuery query, CancellationToken cancellationToken)
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
