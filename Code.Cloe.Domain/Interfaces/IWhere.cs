using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Interfaces
{
    public interface IWhere<TEntity>
    {
        IQueryable<TEntity> Where(Expression<Func<TEntity,bool>> predicate);
    }
}
