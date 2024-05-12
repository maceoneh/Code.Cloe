using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity, TEntityId> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IList<TEntity, TEntityId>, ITransaction, IWhere<TEntity>
    {

    }
}
