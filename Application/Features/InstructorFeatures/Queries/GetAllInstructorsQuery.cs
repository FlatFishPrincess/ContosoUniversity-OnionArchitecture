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

namespace Application.Features.InstructorFeatures.Queries
{
    public class GetAllInstructorsQuery : IRequest<IEnumerable<Instructor>>
    {
        public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstructorsQuery, IEnumerable<Instructor>>
        {
            private readonly IInstructorRepository _repository;
            public GetAllInstructorsQueryHandler(IInstructorRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Instructor>> Handle(GetAllInstructorsQuery query, CancellationToken cancellationToken)
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
