using Application.interfaces;
using Application.interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OfficeAssignmentFeatures.Commands
{
    public class UpdateOfficeAssignmentCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public int? InstructorID { get; set; }

        public class UpdateOfficeAssignmentCommandHandler : IRequestHandler<UpdateOfficeAssignmentCommand, int>
        {
            private readonly IOfficeAssignmentRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public UpdateOfficeAssignmentCommandHandler(IOfficeAssignmentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateOfficeAssignmentCommand command, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(command.ID);

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.Location = command.Location;
                    entity.InstructorID = command.InstructorID;
                    await _repository.UpdateAsync(entity);
                    await _unitOfWork.Commit();
                    return entity.ID;
                }
            }
        }
    }
}
