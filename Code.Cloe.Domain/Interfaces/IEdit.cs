using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Interfaces
{
    public interface IEdit<TEntity>
    {
        /// <summary>
        /// Edita un elemento del listado
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        TEntity? Edit(TEntity item);
        Task<TEntity?> EditAsync(TEntity item);
    }
}
