using Application.interfaces;
using Application.interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.StudentFeatures.Queries
{
    public class GetStudentDetailByIdQuery : IRequest<GetStudentDetailByIdResponse>
    {
        public int ID { get; set; }
        public class GetStudentDetailByIdQueryHandler : IRequestHandler<GetStudentDetailByIdQuery, GetStudentDetailByIdResponse>
        {
            private readonly IStudentRepository _repository;
            private readonly IMapper _mapper;
            public GetStudentDetailByIdQueryHandler(IStudentRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<GetStudentDetailByIdResponse> Handle(GetStudentDetailByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetStudentDetailById(query.ID);
                var mappedEntity = _mapper.Map<GetStudentDetailByIdResponse>(entity);
                if (entity == null) return null;
                return mappedEntity;
            }
        }
    }
}
