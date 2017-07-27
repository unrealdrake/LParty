using LP.UserProfile.Domain.User_Area;
using SharedKernel.BaseAbstractions.Repository;

namespace LP.UserProfile.Repository
{
    public interface IWriteUserProfileRepository: IWriteRepository<User>
    {
        void Delete(User user);
        void AddNewProfile(User userProfile);
    }
}
