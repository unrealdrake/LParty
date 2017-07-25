using System;
using SharedKernel.BaseAbstractions;

namespace SharedKernel.Repository
{
    public interface IBaseRepository<TRoot> : IDisposable where TRoot : IAggregateRoot
    {
    }
}
