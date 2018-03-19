
namespace LP.UserProfile.Gateway.Dto
{
    public sealed class GetUserProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool UserWasFound { get; set; }
    }
}
