using LP.UserProfile.Domain.User_Area;

namespace LP.UserProfile.Repository
{
    public interface IWriteUserProfileRepository: IReadUserProfileRepository
    {
        void Delete(User user);
        void AddNewProfile(User userProfile);
    }
}
