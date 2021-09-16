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
    public class CreateEnrollmentCommand : IRequest<int>
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        // public ICollection<Enrollment> Enrollments { get; set; }
        public class CreateEnrollmentCommandHandler : IRequestHandler<CreateEnrollmentCommand, int>
        {
            private readonly IEnrollmentRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public CreateEnrollmentCommandHandler(IEnrollmentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateEnrollmentCommand command, CancellationToken cancellationToken)
            {
                var entity = new Enrollment();
                entity.CourseID = command.CourseID;
                entity.StudentID = command.StudentID;
                entity.Grade = command.Grade;
                await _repository.AddAsync(entity);
                await _unitOfWork.Commit();
                return entity.ID;
            }
        }
    }
}
