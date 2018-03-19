using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Core.Specifications;
using Shared.Infrasctructure.EntityFramework;
using System;
using System.Linq.Expressions;

namespace LP.UserProfile.EFRepository.SpecificationOverridings
{
    internal class UserExistsByLoginSpec_EF : UserExistsByLoginSpec, IEfSpecificationOverriding
    {
        public UserExistsByLoginSpec_EF(UserExistsByLoginSpec originalSpec) : base(originalSpec.Login)
        {
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return usr => UserProfileEFContext.UserExistsByLogin(usr.LoginData.Login);
        }
    }
}
