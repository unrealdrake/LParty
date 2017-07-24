using SharedKernel.BaseAbstractions;

namespace SharedKernel.Repository
{
    public interface IReadRepository<TRoot> : IBaseRepository<TRoot> where TRoot : IAggregateRoot
    {
    }
}
