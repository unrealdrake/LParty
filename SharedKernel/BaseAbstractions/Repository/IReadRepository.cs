using SharedKernel.BaseAbstractions.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.BaseAbstractions.Repository
{
    public interface IReadRepository<TRoot> : IBaseRepository<TRoot> where TRoot : IAggregateRoot
    {
        Task<IReadOnlyList<TRoot>> FindAsync(Specification<TRoot> specification);
    }
}
