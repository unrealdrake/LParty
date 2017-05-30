using System;
using System.Threading.Tasks;

namespace SharedKernel.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}
