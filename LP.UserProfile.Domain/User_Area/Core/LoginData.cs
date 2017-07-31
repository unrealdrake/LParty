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
            set { EnsureIsValid(new LoginValidator(), value); _login = value; }
        }
        #endregion

        private LoginData() { }
        private LoginData(string login)
        {
            Login = login;
        }

        public static class Factory
        {
            public static LoginData Create(string login)
            {
                return new LoginData(login);
            }
        }
    }
}
