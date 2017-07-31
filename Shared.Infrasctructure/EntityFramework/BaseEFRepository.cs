using System;
using Microsoft.EntityFrameworkCore;

namespace Shared.Infrasctructure.EntityFramework
{
    public abstract class BaseEFRepository : IDisposable
    {
        protected readonly DbContext Context;

        protected BaseEFRepository(DbContext context)
        {
            Context = context;
            Context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
