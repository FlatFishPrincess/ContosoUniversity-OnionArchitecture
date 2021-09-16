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
    public class UpdateEnrollmentCommand : IRequest<int>
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public class UpdateEnrollmentCommandHandler : IRequestHandler<UpdateEnrollmentCommand, int>
        {
            private readonly IEnrollmentRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public UpdateEnrollmentCommandHandler(IEnrollmentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateEnrollmentCommand command, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(command.ID);

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.CourseID = command.CourseID;
                    entity.StudentID = command.StudentID;
                    entity.Grade = command.Grade;
                    await _repository.UpdateAsync(entity);
                    await _unitOfWork.Commit();
                    return entity.ID;
                }
            }
        }
    }
}
