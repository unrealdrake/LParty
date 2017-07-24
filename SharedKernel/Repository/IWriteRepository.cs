using SharedKernel.BaseAbstractions;

namespace SharedKernel.Repository
{
    public interface IWriteRepository<TRoot> : IBaseRepository<TRoot> where TRoot : IAggregateRoot
    {
    }
}
