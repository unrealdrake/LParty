using System;
using SharedKernel.BaseAbstractions;

namespace LP.UserProfile.Domain.User_Area
{
    public sealed class User : EntityBase<int>, IAggregateRoot
    {
        #region [PROPS]
        private PersonalInformation _personalInformation;
        public PersonalInformation PersonalInformation
        {
            get => _personalInformation;
            set { EnsureNotNull(value); _personalInformation = value; }
        }

        private Address _address;
        public Address Address
        {
            get => _address;
            set { EnsureNotNull(value); _address = value; }
        }

        private LoginData _loginData;
        public LoginData LoginData
        {
            get => _loginData;
            set { EnsureNotNull(value); _loginData = value; }
        }
        #endregion

        private User(){}
        private User(PersonalInformation personalInformation, Address address, LoginData loginData)
        {
            PersonalInformation = personalInformation ?? throw new ArgumentException(nameof(personalInformation));
            Address = address ?? throw new ArgumentException(nameof(address));
            LoginData = loginData ?? throw new ArgumentException(nameof(loginData));
        }

        public static class Factory
        {
            public static User Create(PersonalInformation personalInformation, Address address, LoginData loginData)
            {
                return new User(personalInformation, address, loginData);
            }
        }
    }
}
