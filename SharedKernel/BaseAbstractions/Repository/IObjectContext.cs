using System;

namespace SharedKernel.BaseAbstractions.Repository
{
    interface IObjectContext : IDisposable
    {
        void SaveChanges();
    }
}
