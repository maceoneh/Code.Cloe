using Code.Cloe.Domain.Interfaces;

namespace Code.Cloe.Application.Interfaces
{
    public interface IServiceList<TEntity, TEntityId> : IList<TEntity, TEntityId>
    {
    }
}
