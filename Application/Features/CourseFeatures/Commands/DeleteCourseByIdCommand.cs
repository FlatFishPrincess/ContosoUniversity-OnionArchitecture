using Application.interfaces;
using Application.interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CourseFeatures.Commands
{
    public class DeleteCourseByIdCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class DeleteCourseByIdCommandHandler : IRequestHandler<DeleteCourseByIdCommand, int>
        {
            private readonly ICourseRepository _repositoy;
            private IUnitOfWork _unitOfWork { get; set; }
            public DeleteCourseByIdCommandHandler(ICourseRepository repositoy, IUnitOfWork unitOfWork)
            {
                _repositoy = repositoy;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(DeleteCourseByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _repositoy.GetByIdAsync(command.ID);
                if (entity == null) return default;
                await _repositoy.DeleteAsync(entity);
                await _unitOfWork.Commit(); ;
                return entity.ID;
            }
        }
    }
}
