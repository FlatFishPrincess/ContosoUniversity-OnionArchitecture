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
    public class CreateStudentCommand : IRequest<int>
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // public ICollection<Enrollment> Enrollments { get; set; }
        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
        {
            private readonly IStudentRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public CreateStudentCommandHandler(IStudentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {
                var entity = new Student();
                entity.LastName = command.LastName;
                entity.FirstMidName = command.FirstMidName;
                entity.EnrollmentDate = command.EnrollmentDate;
                await _repository.AddAsync(entity);
                await _unitOfWork.Commit();
                return entity.ID;
            }
        }
    }
}
