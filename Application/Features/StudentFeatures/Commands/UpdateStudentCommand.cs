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
    public class UpdateStudentCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
        {
            private readonly IStudentRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public UpdateStudentCommandHandler(IStudentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(command.ID);

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.LastName = command.LastName;
                    entity.FirstMidName = command.FirstMidName;
                    entity.EnrollmentDate = command.EnrollmentDate;
                    await _repository.UpdateAsync(entity);
                    await _unitOfWork.Commit();
                    return entity.ID;
                }
            }
        }
    }
}
