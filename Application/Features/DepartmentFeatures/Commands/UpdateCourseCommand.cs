using Application.interfaces;
using Application.interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DepartmentFeatures.Commands
{
    public class UpdateDepartmentCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }

        public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, int>
        {
            private readonly IDepartmentRepository _repository;
            private IUnitOfWork _unitOfWork { get; set; }
            public UpdateDepartmentCommandHandler(IDepartmentRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(command.ID);

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    entity.Name = command.Name;
                    entity.Budget = command.Budget;
                    entity.StartDate = command.StartDate;
                    entity.InstructorID = command.InstructorID;
                    await _repository.UpdateAsync(entity);
                    await _unitOfWork.Commit(); ;
                    return entity.ID;
                }
            }
        }
    }
}
