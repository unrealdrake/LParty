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
        #endregion

        private User(){}
        private User(PersonalInformation personalInformation, Address address)
        {
            //PersonalInformation = personalInformation;
            //Address = address;
        }


        public static class Factory
        {
            public static User Create(PersonalInformation personalInformation, Address address)
            {
                return new User(personalInformation, address);
            }
        }
    }
}
