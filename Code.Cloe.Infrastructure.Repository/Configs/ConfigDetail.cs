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
    internal class ConfigDetail : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.ToTable("detail");
            builder.HasKey(d => new { d.IDMasterDetail, d.LineNumber});
            builder.HasOne<MasterDetail>()
                .WithMany(md => md.Detail)
                .HasForeignKey(d => d.IDMasterDetail)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
