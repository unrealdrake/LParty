using LP.UserProfile.Domain.User_Area.Core.Validators;
using SharedKernel.BaseAbstractions;

namespace LP.UserProfile.Domain.User_Area.Core
{
    public sealed class Address : ValueObjectBase<Address>
    {
        private int Id { get; set; }
        private int UserId { get; set; }
        private User User { get; set; }

        #region [PROPS]
        private string _city;
        public string City
        {
            get => _city;
            private set { EnsureIsValid(new CityValidator(), value, "City"); _city = value; }
        }
        #endregion 
        private Address() { }
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
