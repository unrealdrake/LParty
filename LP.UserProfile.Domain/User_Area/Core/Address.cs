using LP.UserProfile.Domain.User_Area.Core.Validators;
using SharedKernel.BaseAbstractions;

namespace LP.UserProfile.Domain.User_Area.Core
{
    public sealed class Address : ValueObjectBase<Address>
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public User User { get; set; }

        #region [PROPS]
        private string _city;
        public string City
        {
            get => _city;
            set { EnsureIsValid(new CityValidator(), value); _city = value; }
        }
        #endregion 

        private Address(string city)
        {
            this.City = city;
        }

        public static class Factory
        {
            public static Address Create(string city)
            {
                return new Address(city);
            }
        }
    }
}
