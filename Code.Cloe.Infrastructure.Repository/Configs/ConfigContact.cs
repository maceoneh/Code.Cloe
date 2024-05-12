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
    internal class ConfigContact : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("contacts");
            builder.HasKey(p => p.ID);
            builder.HasOne<Subject>()
                .WithMany(p => p.Contacts)
                .HasForeignKey(s => s.SubjectID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
