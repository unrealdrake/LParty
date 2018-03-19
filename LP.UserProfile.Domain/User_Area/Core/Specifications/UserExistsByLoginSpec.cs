using System;
using System.Linq.Expressions;
using Shared.Infrasctructure.ObjectExtensions;
using SharedKernel.BaseAbstractions.Specification;

namespace LP.UserProfile.Domain.User_Area.Core.Specifications
{
    public class UserExistsByLoginSpec : Specification<User>
    {
        public readonly string Login;

        public UserExistsByLoginSpec(string email)
        {
            Login = email;
            email.NotNullOrEmpty();
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return usr => usr.LoginData.Login.ToLower() == Login.ToLower();
        }
    }
}