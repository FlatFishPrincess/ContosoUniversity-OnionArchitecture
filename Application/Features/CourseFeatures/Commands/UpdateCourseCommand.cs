using Application.interfaces;
using Application.interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CourseFeatures.Commands
{
    public class UpdateCourseCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

        public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, int>
        {
            private readonly ICourseRepository _repositoy;
            private IUnitOfWork _unitOfWork { get; set; }
            public UpdateCourseCommandHandler(ICourseRepository repositoy, IUnitOfWork unitOfWork)
            {
                _repositoy = repositoy;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
            {
                var entity = await _repositoy.GetByIdAsync(command.ID);

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.Title = command.Title;
                    entity.Credits = command.Credits;
                    entity.DepartmentID = command.DepartmentID;
                    await _repositoy.UpdateAsync(entity);
                    await _unitOfWork.Commit(); ;
                    return entity.ID;
                }
            }
        }
    }
}
