using SharedKernel.BaseAbstractions;

namespace SharedKernel.Repository
{
    public interface IBaseRepository<TRoot> where TRoot: IAggregateRoot
    {
    }
}
