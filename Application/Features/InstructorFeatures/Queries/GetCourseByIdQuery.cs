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

namespace Application.Features.InstructorFeatures.Queries
{
    public class GetInstructorByIdQuery : IRequest<Instructor>
    {
        public int ID { get; set; }
        public class GetInstructorByIdQueryHandler : IRequestHandler<GetInstructorByIdQuery, Instructor>
        {
            private readonly IInstructorRepository _repository;
            public GetInstructorByIdQueryHandler(IInstructorRepository repository)
            {
                _repository = repository;
            }
            public async Task<Instructor> Handle(GetInstructorByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(query.ID);
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
