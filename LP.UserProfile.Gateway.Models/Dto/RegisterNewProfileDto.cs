
namespace LP.UserProfile.Gateway.Dto
{
    public sealed class RegisterNewProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string AddressCity { get; set; }
        public string Password { get; set; }
    }
}
