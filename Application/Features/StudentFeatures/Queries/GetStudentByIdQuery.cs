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
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int ID { get; set; }
        public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
        {
            private readonly IStudentRepository _repository;
            public GetStudentByIdQueryHandler(IStudentRepository repository)
            {
                _repository = repository;
            }
            public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(query.ID);
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
