using Microsoft.EntityFrameworkCore;

namespace Shared.Infrasctructure.EntityFramework
{
    public abstract class BaseWriteEFRepository<TRoot> : BaseReadEFRepository where TRoot : class
    {
        protected BaseWriteEFRepository(DbContext context) : base(context)
        {
        }


        public void Add(TRoot entity)
        {
            Context.Set<TRoot>().Add(entity);
            Context.SaveChanges();
        }
    }
}
