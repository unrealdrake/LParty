using System.Threading.Tasks;
using LP.UserProfile.Domain.User_Area.Core;
using SharedKernel.BaseAbstractions.Repository;

namespace LP.UserProfile.Domain.User_Area.Repositories
{
    public interface IWriteUserProfileRepository: IWriteRepository<User>
    {
        Task DeleteAsync(User userProfile);
        Task AddNewProfileAsync(User userProfile);
        Task ClearAllAsync();
    }
}
