using System;
using SharedKernel.BaseAbstractions;

namespace Domain.Address
{
    public sealed class Address : ValueObjectBase<Address>
    {
        public string City { get; }
        public string Country { get; }

        private Address(string city, string country)
        {
            this.City = city;
            this.Country = country;
        }

        public static Address Create(string city, string country)
        {
            return new Address(city, country);
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.City))
            {
                AddBrokenRule(AddressBusinessRule.CityRequired);
            }
            if (string.IsNullOrEmpty(this.Country))
            {
                AddBrokenRule(AddressBusinessRule.CountryRequired);
            }
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
