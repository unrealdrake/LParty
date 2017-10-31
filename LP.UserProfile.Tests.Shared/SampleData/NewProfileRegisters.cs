using System.Collections.Generic;
using LP.UserProfile.Gateway.Dto;

namespace LP.UserProfile.Tests.Shared.SampleData
{
    public class NewProfileRegisters
    {
        public static IList<RegisterNewProfileDto> Profiles = new List<RegisterNewProfileDto>
        {
            new RegisterNewProfileDto
            {
                AddressCity = "London",
                FirstName = "Genny",
                LastName = "Motion",
                Login = "Graber",
                Password = "Password1"
            },
            new RegisterNewProfileDto
            {
                AddressCity = "Tokio",
                FirstName = "Boss",
                LastName = "Labmer",
                Login = "Glaven",
                Password = "Password1"
            },
            new RegisterNewProfileDto
            {
                AddressCity = "San Diego",
                FirstName = "Granny",
                LastName = "Dolton",
                Login = "Alamus",
                Password = "Password1"
            },
            new RegisterNewProfileDto
            {
                AddressCity = "Oslo",
                FirstName = "Bin",
                LastName = "Backer",
                Login = "Simlok",
                Password = "Password1"
            },
            new RegisterNewProfileDto
            {
                AddressCity = "Warsaw",
                FirstName = "Dolton",
                LastName = "Black",
                Login = "Opeun",
                Password = "Password1"
            }
        };
    }
}
