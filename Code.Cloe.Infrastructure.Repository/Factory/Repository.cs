using Code.Cloe.Application.Interfaces;
using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Infrastructure.Repository.Factory
{
    static public class Repository
    {
        static public IRepositoryBase<TEntity, Guid> Create<TEntity>()
        {
            RepositoryContext dbContext = (RepositoryContext)Factory.Context.GetMigrate();            
            var entityType = typeof(TEntity);
            if (entityType == typeof(Subject))
            {
                return (IRepositoryBase<TEntity, Guid>)new SubjectRepository(dbContext);
            }
            else if (entityType == typeof(Contact))
            {
                return (IRepositoryBase<TEntity, Guid>)new ContactRepository(dbContext);
            }
            else if (entityType == typeof(Counter))
            {
                return (IRepositoryBase<TEntity, Guid>)new CounterRepository(dbContext);
            }
            else
            {
                throw new ArgumentException("TEntity not support");
            }
        }
    }
}
