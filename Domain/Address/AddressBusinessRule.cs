using SharedKernel.BaseAbstractions;

namespace Domain.Address
{
    public sealed class AddressBusinessRule
    {
        public static readonly BusinessRule CityRequired = new BusinessRule("City is required field");
        public static readonly BusinessRule CountryRequired = new BusinessRule("Country is required field");
    }
}
