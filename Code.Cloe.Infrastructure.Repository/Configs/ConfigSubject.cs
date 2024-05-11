using Code.Cloe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Code.Cloe.Infrastructure.Repository.Configs
{
    internal class ConfigSubject : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("subjects");
            builder.HasKey(s => s.ID);
        }
    }
}
