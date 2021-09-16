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

namespace Application.Features.OfficeAssignmentFeatures.Commands
{
    public class DeleteOfficeAssignmentByIdCommand : IRequest<int>
    {
        public int ID { get; set; }
        public class DeleteOfficeAssignmentByIdCommandHandler : IRequestHandler<DeleteOfficeAssignmentByIdCommand, int>
        {
            private readonly IOfficeAssignmentRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public DeleteOfficeAssignmentByIdCommandHandler(IOfficeAssignmentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(DeleteOfficeAssignmentByIdCommand command, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(command.ID);
                if (entity == null) return default;
                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit();
                return entity.ID;
            }
        }
    }
}
