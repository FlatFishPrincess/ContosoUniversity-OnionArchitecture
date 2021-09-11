using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();

        Task Rollback();
    }
}
