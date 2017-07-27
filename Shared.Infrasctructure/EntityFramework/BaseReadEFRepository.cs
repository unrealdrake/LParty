using Microsoft.EntityFrameworkCore;

namespace Shared.Infrasctructure.EntityFramework
{
    public abstract class BaseReadEFRepository: BaseEFRepository
    {
        protected BaseReadEFRepository(DbContext context) : base(context)
        {
        }
    }
}
