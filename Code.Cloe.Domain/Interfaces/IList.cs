using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Interfaces
{
    public interface IList<TEntity, TEntityId>
    {
        /// <summary>
        /// Obtiene la lista completa de elementos guardados
        /// </summary>
        /// <returns></returns>
        List<TEntity> List();
        Task<List<TEntity>> ListAsync();

        /// <summary>
        /// Obtiene el elemento con el ID especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity? Get(TEntityId id);
        Task<TEntity?> GetAsync(TEntityId id);
    }
}
