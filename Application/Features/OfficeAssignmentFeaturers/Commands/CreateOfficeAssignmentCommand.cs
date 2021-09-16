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

namespace Application.Features.OfficeAssignmentFeatures.Commands
{
    public class CreateOfficeAssignmentCommand : IRequest<int>
    {
        public string Location { get; set; }
        public int? InstructorID { get; set; }


        public class CreateInstructorCommandHandler : IRequestHandler<CreateOfficeAssignmentCommand, int>
        {
            private readonly IOfficeAssignmentRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public CreateInstructorCommandHandler(IOfficeAssignmentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateOfficeAssignmentCommand command, CancellationToken cancellationToken)
            {
                var entity = new OfficeAssignment();
                entity.Location = command.Location;
                entity.InstructorID = command.InstructorID;
                await _repository.AddAsync(entity);
                await _unitOfWork.Commit();
                return entity.ID;
            }
        }
    }
}
