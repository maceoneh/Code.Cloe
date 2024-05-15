using Code.Cloe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Application.Interfaces
{
    public interface IServiceCreate<TEntity> : IAdd<TEntity>
    {
    }
}
