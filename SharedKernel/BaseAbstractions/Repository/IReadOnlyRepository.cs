using System.Collections.Generic;
using SharedKernel.BaseAbstractions.Specification;

namespace SharedKernel.BaseAbstractions.Repository
{
    public interface IReadOnlyRepository<AggregateType, IdType> where AggregateType : IAggregateRoot
    {
        AggregateType FindBy(IdType id);
        IEnumerable<AggregateType> Find(Specification<AggregateType> specification);
    }
}
