using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Interfaces
{
    public interface IDelete<TEntityId>
    {
        void Delete(TEntityId id);
        Task DeleteAsync(TEntityId id);
    }
}
