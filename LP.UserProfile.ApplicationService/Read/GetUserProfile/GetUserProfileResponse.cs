using System;

namespace LP.UserProfile.ApplicationService.Read.GetUserProfile
{
    public class GetUserProfileResponse
    {
        public GetUserProfileResponse(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentException(nameof(lastName));
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}