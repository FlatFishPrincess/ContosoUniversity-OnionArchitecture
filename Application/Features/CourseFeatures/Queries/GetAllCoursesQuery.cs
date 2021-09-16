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
    public class GetAllCoursesQuery : IRequest<IEnumerable<Course>>
    {
        public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<Course>>
        {
            private readonly ICourseRepository _repositoy;
            public GetAllCoursesQueryHandler(ICourseRepository repositoy)
            {
                _repositoy = repositoy;
            }
            public async Task<IEnumerable<Course>> Handle(GetAllCoursesQuery query, CancellationToken cancellationToken)
            {
                var entityList = await _repositoy.GetAllAsync();
                if (entityList == null)
                {
                    return null;
                }
                return entityList.AsReadOnly();
            }
        }
    }
}
