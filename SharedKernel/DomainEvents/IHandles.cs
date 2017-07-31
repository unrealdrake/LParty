
namespace SharedKernel.DomainEvents
{
    public interface IHandles<T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}
