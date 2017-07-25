using SharedKernel.BaseAbstractions;
using Shared.Infrasctructure.ObjectExtensions;

namespace LP.UserProfile.Domain.User_Area
{
    public sealed class User : EntityBase<int>, IAggregateRoot
    {
        #region [PROPS]
        private PersonalInformation _personalInformation;
        public PersonalInformation PersonalInformation
        {
            get => _personalInformation;
            set { value.NotNull(); _personalInformation = value; }
        }

        private Address _address;
        public Address Address
        {
            get => _address;
            set { value.NotNull(); _address = value; }
        }

        private LoginData _loginData;
        public LoginData LoginData
        {
            get => _loginData;
            set { value.NotNull(); _loginData = value; }
        }
        #endregion

        private User(){}
        private User(PersonalInformation personalInformation, Address address, LoginData loginData)
        {
            PersonalInformation = personalInformation;
            Address = address;
            LoginData = loginData;
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
