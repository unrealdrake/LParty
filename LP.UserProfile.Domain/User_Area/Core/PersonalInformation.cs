using LP.UserProfile.Domain.User_Area.Core.Validators;
using SharedKernel.BaseAbstractions;

namespace LP.UserProfile.Domain.User_Area.Core
{
    public sealed class PersonalInformation: ValueObjectBase<PersonalInformation>
    {
        #region [PROPS]
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set { EnsureIsValid(new FirstNameValidator(), value); _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set { EnsureIsValid(new LastNameValidator(), value); _lastName = value; }
        }
        #endregion
        public PersonalInformation() { }
        private PersonalInformation(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static class Factory
        {
            public static PersonalInformation Create(string firstName, string lastName)
            {
                return new PersonalInformation(firstName, lastName);
            }
        }
    }
}
