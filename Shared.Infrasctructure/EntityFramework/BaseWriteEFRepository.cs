using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedKernel.BaseAbstractions;

namespace Shared.Infrasctructure.EntityFramework
{
    public abstract class BaseWriteEFRepository<TRoot> : BaseReadEFRepository<TRoot> where TRoot : class, IAggregateRoot
    {
        protected BaseWriteEFRepository(DbContext context) : base(context)
        {
        }


        public async Task AddAsync(TRoot entity)
        {
            Context.Set<TRoot>().Add(entity);
            await Context.SaveChangesAsync();
        }
    }
}
