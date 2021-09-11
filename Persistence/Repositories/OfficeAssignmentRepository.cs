using Application.interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OfficeAssignmentRepository : GenericRepository<OfficeAssignment>, IOfficeAssignmentRepository
    {
        public OfficeAssignmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
