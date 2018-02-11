﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LP.UserProfile.Domain.User_Area.Core;
using SharedKernel.BaseAbstractions.Repository;

namespace LP.UserProfile.Domain.User_Area.Repositories
{
    public interface IReadUserProfileRepository: IReadRepository<User>
    {
        Task<ReadOnlyCollection<User>> GetAllUsersAsync();
    }
}
