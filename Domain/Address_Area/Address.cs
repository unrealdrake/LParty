using System;
using System.Collections.Generic;
using Domain.Address_Area.Validators;
using FluentValidation.Results;
using SharedKernel.BaseAbstractions;

namespace Domain.Address_Area
{
    public sealed class Address : ValueObjectBase<Address>
    {
        private string _city;

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != null)
                {
                    EnsureIsValid(new CountryValidator(), value, checkForNull);
                }
            }
        }

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
