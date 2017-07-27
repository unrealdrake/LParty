using System;

namespace SharedKernel.BaseAbstractions.Repository
{
    public interface IBaseRepository<TRoot> : IDisposable where TRoot : IAggregateRoot
    {
    }
}
