﻿using LP.UserProfile.Repository;
using LP.UserProfile.Domain.User_Area;
using Microsoft.EntityFrameworkCore;

namespace LP.UserProfile.EFRepository
{
    public class WriteUserProfileRepository : ReadUserProfileRepository, IWriteUserProfileRepository
    {
        private readonly UserProfileEFContext _efContext;

        public WriteUserProfileRepository(UserProfileEFContext efContext) : base(efContext)
        {
            _efContext = efContext;
        }

        public void Delete(User user)
        {
            _efContext.Entry(user).State = EntityState.Deleted;
            _efContext.Entry(user).Reference(u => u.PersonalInformation).Load();
            _efContext.Entry(user.PersonalInformation).State = EntityState.Deleted;
            _efContext.Entry(user).Reference(u => u.LoginData).Load();
            _efContext.Entry(user.LoginData).State = EntityState.Deleted;

            _efContext.SaveChanges();
        }

        public void AddNewProfile(User userProfile)
        {
            _efContext.UserProfiles.Add(userProfile);
            _efContext.SaveChanges();
        }
    }
}
