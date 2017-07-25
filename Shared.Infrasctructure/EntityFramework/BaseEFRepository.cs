using System;
using Microsoft.EntityFrameworkCore;

namespace Shared.Infrasctructure.EntityFramework
{
    public abstract class BaseEFRepository: IDisposable
    {
        private readonly DbContext _context;

        protected BaseEFRepository(DbContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
