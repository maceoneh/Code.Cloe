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
        static public string? RepositoryFolder { get; set; }
        static public IRepositoryBase<TEntity, Guid> Create<TEntity>()
        {
            RepositoryContext dbContext;
            if (string.IsNullOrEmpty(RepositoryFolder))
            {
                dbContext = new RepositoryContext();
            }
            else
            { 
                dbContext = new RepositoryContext(RepositoryFolder);
            }
            var entityType = typeof(TEntity);
            if (entityType == typeof(Subject))
            {
                return (IRepositoryBase<TEntity, Guid>)new SubjectRepository(dbContext);
            }
            else
            {
                throw new ArgumentException("TEntity not support");
            }
        }
    }
}
