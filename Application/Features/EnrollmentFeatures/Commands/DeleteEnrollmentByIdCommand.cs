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
    public class DeleteEnrollmentByIdCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class DeleteEnrollmentByIdCommandHandler : IRequestHandler<DeleteEnrollmentByIdCommand, int>
        {
            private readonly IEnrollmentRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public DeleteEnrollmentByIdCommandHandler(IEnrollmentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(DeleteEnrollmentByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(command.ID);
                if (entity == null) return default;
                await _repository.DeleteAsync(entity);
                await _unitOfWork.Commit();
                return entity.ID;
            }
        }
    }
}
