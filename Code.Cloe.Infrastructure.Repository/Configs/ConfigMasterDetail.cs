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
    internal class ConfigMasterDetail : IEntityTypeConfiguration<MasterDetail>
    {
        public void Configure(EntityTypeBuilder<MasterDetail> builder)
        {
            builder.ToTable("master");
            builder.HasKey(md => md.ID);
            builder.HasQueryFilter(md => !md.IsDeleted);
        }
    }
}
