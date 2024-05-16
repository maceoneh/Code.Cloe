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
            builder.HasKey(c => c.ID);
            builder.HasOne<Subject>()
                .WithMany(s => s.Contacts)
                .HasForeignKey(c => c.IDSubject)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
