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

namespace Application.Features.InstructorFeatures.Commands
{
    public class CreateInstructorCommand : IRequest<int>
    {
        public DateTime HireDate { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public Guid ConcurrencyToken { get; set; } = Guid.NewGuid();

        public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, int>
        {
            private readonly IInstructorRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public CreateInstructorCommandHandler(IInstructorRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateInstructorCommand command, CancellationToken cancellationToken)
            {
                var entity = new Instructor();
                entity.HireDate = command.HireDate;
                entity.LastName = command.LastName;
                entity.FirstMidName = command.FirstMidName;
                await _repository.AddAsync(entity);
                await _unitOfWork.Commit();
                return entity.ID;
            }
        }
    }
}
