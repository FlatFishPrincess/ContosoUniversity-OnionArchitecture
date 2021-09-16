using Application.interfaces;
using Application.interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InstructorFeatures.Commands
{
    public class UpdateInstructorCommand : IRequest<int>
    {
        public int ID { get; set; }
        public DateTime HireDate { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, int>
        {
            private readonly IInstructorRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public UpdateInstructorCommandHandler(IInstructorRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateInstructorCommand command, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(command.ID);

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.HireDate = command.HireDate;
                    entity.LastName = command.LastName;
                    entity.FirstMidName = command.FirstMidName;
                    await _repository.UpdateAsync(entity);
                    await _unitOfWork.Commit();
                    return entity.ID;
                }
            }
        }
    }
}
