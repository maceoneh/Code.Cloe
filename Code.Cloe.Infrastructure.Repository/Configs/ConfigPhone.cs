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
    internal class ConfigPhone : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("phones");
            builder.HasKey(p => p.ID);
            builder.HasOne<Subject>().WithMany(p => p.Phones).HasForeignKey(s => s.SubjectID);
        }
    }
}
