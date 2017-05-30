using System;
using LPBusiness.Domain.Address_Area.Validators;
using SharedKernel.BaseAbstractions;

namespace LPBusiness.Domain.Address_Area
{
    public sealed class Address : ValueObjectBase<Address>
    {
        #region [PROPS]
        private string _city;
        public string City
        {
            get => _city;
            set { EnsureIsValid(new CityValidator(), value); _city = value; }
        }

        private string _country;
        public string Country
        {
            get => _country;
            set { EnsureIsValid(new LastNameValidator(), value); _country = value; }
        }
        #endregion 

        private Address(string city, string country)
        {
            this.City = city;
            this.Country = country;
        }

        public static Address Create(string city, string country)
        {
            return new Address(city, country);
        }

        public override bool Equals(Address otherAddress)
        {
            return this.City.Equals(otherAddress.City, StringComparison.OrdinalIgnoreCase)
                   && this.Country.Equals(otherAddress.Country, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Address)) return false;

            return this.Equals((Address)obj);
        }

        public override int GetHashCode()
        {
            return this.City.GetHashCode() + this.Country.GetHashCode();
        }
    }
}
