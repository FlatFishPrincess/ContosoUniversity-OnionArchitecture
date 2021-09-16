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

namespace Application.Features.CourseFeatures.Commands
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        // public ICollection<Enrollment> Enrollments { get; set; }
        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
        {
            private readonly ICourseRepository _repositoy;
            private IUnitOfWork _unitOfWork { get; set; }
            public CreateCourseCommandHandler(ICourseRepository repositoy, IUnitOfWork unitOfWork)
            {
                _repositoy = repositoy;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
            {
                var entity = new Course();
                entity.Title = command.Title;
                entity.Credits = command.Credits;
                entity.DepartmentID = command.DepartmentID;
                // entity.Enrollments = command.Enrollments;
                await _repositoy.AddAsync(entity);
                await _unitOfWork.Commit(); ;
                return entity.ID;
            }
        }
    }
}
