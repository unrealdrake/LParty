﻿using LP.UserProfile.Domain.User_Area.Core;
using SharedKernel.BaseAbstractions.Repository;

namespace LP.UserProfile.Domain.User_Area.Repositories
{
    public interface IWriteUserProfileRepository: IWriteRepository<User>
    {
        void Delete(User userProfile);
        void AddNewProfile(User userProfile);
        void ClearAll();
    }
}
