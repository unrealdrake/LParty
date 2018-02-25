using System;
using System.Linq.Expressions;
using Shared.Infrasctructure.ObjectExtensions;
using SharedKernel.BaseAbstractions.Specification;

namespace LP.UserProfile.Domain.User_Area.Core.Specifications
{
    public class UserByEmailAndPasswordSpec : Specification<User>
    {
        private readonly string _login;
        private readonly string _password;

        public UserByEmailAndPasswordSpec(string email, string password)
        {
            _login = email;
            _password = password;
            email.NotNullOrEmpty();
            password.NotNullOrEmpty();
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return usr => usr.LoginData.Login.ToLower() == _login.ToLower() && usr.LoginData.Password == _password;
        }
    }
}
