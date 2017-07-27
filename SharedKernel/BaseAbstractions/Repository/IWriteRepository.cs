namespace SharedKernel.BaseAbstractions.Repository
{
    public interface IWriteRepository<TRoot> : IBaseRepository<TRoot> where TRoot : IAggregateRoot
    {
    }
}
