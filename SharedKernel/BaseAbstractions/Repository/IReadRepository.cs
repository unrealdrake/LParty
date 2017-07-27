namespace SharedKernel.BaseAbstractions.Repository
{
    public interface IReadRepository<TRoot> : IBaseRepository<TRoot> where TRoot : IAggregateRoot
    {
    }
}
