using LP.UserProfile.Domain.User_Area.Validators;
using SharedKernel.BaseAbstractions;

namespace LP.UserProfile.Domain.User_Area
{
    public sealed class User : EntityBase<int>
    {
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set { EnsureIsValid(new LastNameValidator(), value); _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get => _firstName;
            set { EnsureIsValid(new LastNameValidator(), value); _lastName = value; }
        }

        public User(int id) : base(id)
        {
        }
    }
}
