
namespace SharedKernel.DomainEvents
{
    public interface IHandles<IDomainEvent> 
    {
        void Handle(IDomainEvent domainEvent);
    }
}
