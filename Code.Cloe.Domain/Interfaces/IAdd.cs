using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Interfaces
{
    public interface IAdd<TEntity>
    {
        /// <summary>
        /// Agrega un elemento al listado
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        TEntity Add(TEntity item);
        Task<TEntity> AddAsync(TEntity item);
    }
}
