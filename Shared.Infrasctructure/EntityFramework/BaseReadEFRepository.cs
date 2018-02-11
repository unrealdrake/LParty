using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedKernel.BaseAbstractions;
using SharedKernel.BaseAbstractions.Specification;

namespace Shared.Infrasctructure.EntityFramework
{
    public abstract class BaseReadEFRepository<TRoot> : BaseEFRepository where TRoot : class, IAggregateRoot
    {
        protected BaseReadEFRepository(DbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<TRoot>> FindAsync(Specification<TRoot> specification)
        {
            return await Context.Set<TRoot>().Where(specification.ToExpression()).ToListAsync();
        }
    }
}
