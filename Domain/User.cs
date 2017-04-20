using System;
using Domain.Address_Area;
using SharedKernel.BaseAbstractions;

namespace Domain
{
    public sealed class User : EntityBase<Guid>, IAggregateRoot
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Address Address { get; }
        public Settings Settings { get; }

        private User(Guid guid, string firstName, string lastName, Address address, Settings settings) : base(guid)
        {
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException(nameof(firstName));
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException(nameof(lastName));

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address ?? throw new ArgumentException(nameof(address));
            this.Settings = settings ?? throw new ArgumentException(nameof(settings));
        }

        public static User Create(Guid guid, string firstName, string lastName, Address address, Settings settings)
        {
            return new User(guid, firstName, lastName, address, settings);
        }
    }
}
