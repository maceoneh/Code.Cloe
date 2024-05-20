using Code.Cloe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Infrastructure.Repository.Configs
{
    internal class ConfigCounter : IEntityTypeConfiguration<Counter>
    {
        public void Configure(EntityTypeBuilder<Counter> builder)
        {
            builder.ToTable("counters");
            builder.HasKey(c => c.ID);
            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
