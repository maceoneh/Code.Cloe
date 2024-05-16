using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Interfaces.Repository
{
    public interface IMigrate
    {
        public void Migrate();
        public Task MigrateAsync();
    }
}
