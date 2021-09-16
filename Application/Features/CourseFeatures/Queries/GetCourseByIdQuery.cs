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
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public int ID { get; set; }
        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
        {
            private readonly ICourseRepository _repositoy;
            public GetCourseByIdQueryHandler(ICourseRepository repositoy)
            {
                _repositoy = repositoy;
            }
            public async Task<Course> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _repositoy.GetByIdAsync(query.ID);
                if (entity == null) return null;
                return entity;
            }
        }
    }
}
