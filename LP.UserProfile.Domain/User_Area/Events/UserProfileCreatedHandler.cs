using SharedKernel.DomainEvents;

namespace LP.UserProfile.Domain.User_Area.Events
{
    public class UserProfileCreatedHandler: IHandles<UserProfileCreatedEvent>
    {
        public void Handle(UserProfileCreatedEvent domainEvent)
        {
            
        }
    }
}
