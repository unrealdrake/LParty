using System.Collections.ObjectModel;
using LP.UserProfile.Domain.User_Area;
using SharedKernel.BaseAbstractions.Repository;

namespace LP.UserProfile.Repository
{
    public interface IReadUserProfileRepository: IReadRepository<User>
    {
        ReadOnlyCollection<User> GetAllUsers();
    }
}
