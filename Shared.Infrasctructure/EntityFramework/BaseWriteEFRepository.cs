using Microsoft.EntityFrameworkCore;
using SharedKernel.BaseAbstractions;

namespace Shared.Infrasctructure.EntityFramework
{
    public abstract class BaseWriteEFRepository<TRoot> : BaseEFRepository where TRoot : class, IAggregateRoot 
    {
        protected BaseWriteEFRepository(DbContext context) : base(context)
        {
        }

        public void Delete(TRoot entity)
        {
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public void Add(TRoot entity)
        {
            Context.Set<TRoot>().Add(entity);
            Context.SaveChanges();
        }
    }
}
