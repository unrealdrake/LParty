using System;
using LP.UserProfile.Domain.User_Area.Validators;
using SharedKernel.BaseAbstractions;

namespace LP.UserProfile.Domain.User_Area
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

        public override bool Equals(PersonalInformation otherAddress)
        {
            return this.FirstName.Equals(otherAddress.FirstName, StringComparison.OrdinalIgnoreCase)
                && this.LastName.Equals(otherAddress.LastName, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PersonalInformation)) return false;

            return this.Equals((PersonalInformation)obj);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() + this.LastName.GetHashCode();
        }
    }
}
