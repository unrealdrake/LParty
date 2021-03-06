﻿using Microsoft.EntityFrameworkCore;

namespace Shared.Infrasctructure.EntityFramework
{
    public static class EntityFrameworkExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
