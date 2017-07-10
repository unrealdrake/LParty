using SharedKernel.BaseAbstractions;

namespace SharedKernel.Repository
{
    public abstract class BaseRepository<TRoot> where TRoot: IAggregateRoot
    {
    }
}
