using System.Collections.ObjectModel;
using SharedKernel.Repository;
using LP.UserProfile.Domain.User_Area;

namespace LP.UserProfile.Repository
{
    public interface IUserProfileRepository: IBaseRepository<User>
    {
        void ClearAll();
        void AddNewProfile(User userProfile);
        ReadOnlyCollection<User> GetAllUsers();
    }
}
