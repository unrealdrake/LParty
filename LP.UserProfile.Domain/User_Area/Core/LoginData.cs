using LP.UserProfile.Domain.User_Area.Core.Validators;
using SharedKernel.BaseAbstractions;

namespace LP.UserProfile.Domain.User_Area.Core
{
    public sealed class LoginData : ValueObjectBase<LoginData>
    {
        #region [PROPS]
        private string _login;
        public string Login
        {
            get => _login;
            private set { EnsureIsValid(new LoginValidator(), value, "Login"); _login = value; }
        }

        private string _password;
        public string Password
        {
            get => _password;
            private set { EnsureIsValid(new PasswordValidator(), value, "Password"); _password = value; }
        }
        #endregion

        private LoginData() { }
        private LoginData(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public static class Factory
        {
            public static LoginData Create(string login, string password)
            {
                return new LoginData(login, password);
            }
        }
    }
}
