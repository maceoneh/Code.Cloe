using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Infrastructure.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Infrastructure.Repository.Factory
{
    static public class Context
    {
        static public string? RepositoryFolder { get; set; }

        public static IMigrate GetMigrate()
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
            return dbContext;
        }
    }
}
