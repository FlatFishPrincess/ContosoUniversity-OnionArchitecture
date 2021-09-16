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
    public class GetAllStudentsQuery : IRequest<IEnumerable<Student>>
    {
        public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
        {
            private readonly IStudentRepository _repository;
            public GetAllStudentsQueryHandler(IStudentRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
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
