using System;
using Domain.Address_Area;
using Domain.User_Area.Validators;
using SharedKernel.BaseAbstractions;

namespace Domain.User_Area
{
    public sealed class User : EntityBase<Guid>, IAggregateRoot
    {
        #region [PROPS]
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set { EnsureIsValid(new FirstNameValidator(), value); _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set { EnsureIsValid(new LastNameValidator(), value); _lastName = value; }
        }

        public Address Address { get; }
        public Settings Settings { get; }
        #endregion

        private User(Guid guid, string firstName, string lastName, Address address, Settings settings) : base(guid)
        {
            this.Address = address ?? throw new ArgumentException(nameof(address));
            this.Settings = settings ?? throw new ArgumentException(nameof(settings));
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public static User Create(Guid guid, string firstName, string lastName, Address address, Settings settings)
        {
            return new User(guid, firstName, lastName, address, settings);
        }
    }
}
