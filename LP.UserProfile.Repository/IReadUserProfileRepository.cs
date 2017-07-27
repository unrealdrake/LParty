using System.Collections.ObjectModel;
using SharedKernel.Repository;
using LP.UserProfile.Domain.User_Area;

namespace LP.UserProfile.Repository
{
    public interface IReadUserProfileRepository: IReadRepository<User>
    {
        ReadOnlyCollection<User> GetAllUsers();
    }
}
