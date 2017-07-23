
using Microsoft.EntityFrameworkCore;

namespace Shared.Infrasctructure.EntityFramework
{
    public abstract class BaseEFRepository
    {
        private DbContext _context;

        protected BaseEFRepository(DbContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
