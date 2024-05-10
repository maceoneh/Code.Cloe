using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Cloe.Domain.Interfaces;

namespace Code.Cloe.Application.Interfaces
{
    public interface IServiceBase<TEntity, TEntityId> : IAdd<TEntity>, IDelete<TEntityId>, IEdit<TEntity>, IList<TEntity, TEntityId>
    {

    }
}
