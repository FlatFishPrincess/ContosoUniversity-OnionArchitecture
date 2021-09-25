using Application.Extensions;
using Application.interfaces;
using Application.interfaces.Helpers;
using Application.interfaces.Repositories;
using AspNetCoreHero.Results;
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
    public class GetAllStudentsQuery : IRequest<PaginatedResult<Student>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string OrderBy { get; set; }

        public string Search { get; set; }
        public GetAllStudentsQuery(int pageNumber, int pageSize, string orderBy, string search = "")
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderBy = orderBy;
            Search = search;
            
        }
        public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, PaginatedResult<Student>>
        {
            private readonly IStudentRepository _repository;
            private ISortHelper<Student> _helper;
            public GetAllStudentsQueryHandler(IStudentRepository repository, ISortHelper<Student> helper)
            {
                _repository = repository;
                _helper = helper;
            }
            public async Task<PaginatedResult<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
            {
                var entityList = _repository.Entities;
                if (entityList == null)
                {
                    return null;
                }
                if (query.Search != null)
                {
                    entityList = _repository.SearchByName(query.Search);
                }
                var sortedEntityList = _helper.ApplySort(entityList, query.OrderBy);
                var paginatedList = await sortedEntityList
                                    .ToPaginatedListAsync(query.PageNumber, query.PageSize);
                return paginatedList;
            }
        }
    }
}
