﻿using System;
using LP.UserProfile.Domain.User_Area.Validators;
using SharedKernel.BaseAbstractions;

namespace LP.UserProfile.Domain.User_Area
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
        #endregion 

        private Address(string city)
        {
            this.City = city;
        }

        public static Address Create(string city, string country)
        {
            return new Address(city);
        }

        public override bool Equals(Address otherAddress)
        {
            return this.City.Equals(otherAddress.City, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Address)) return false;

            return this.Equals((Address)obj);
        }

        public override int GetHashCode()
        {
            return this.City.GetHashCode();
        }
    }
}