using SharedKernel.DomainEvents;

namespace LP.UserProfile.Domain.User_Area.Events
{
    public class UserProfileCreatedEvent : IDomainEvent
    {
        public int UserProfileId { get; }

        public UserProfileCreatedEvent(int userProfileId)
        {
            UserProfileId = userProfileId;
        }
    }
}
