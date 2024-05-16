using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Repository.Configs;
using Microsoft.EntityFrameworkCore;

namespace Code.Cloe.Infrastructure.Repository.Contexts
{
    internal class RepositoryContext : DbContext, IMigrate
    {
        internal string Folder { get; private set; }        
        internal DbSet<Subject> Subjects { get; set; }
        internal DbSet<Contact> Contacts { get; set; }

        public RepositoryContext()
        {
            this.Folder = "";
        }

        public RepositoryContext(string folder)
        {
            if (Directory.Exists(folder))
            {
                this.Folder = folder;
            }
            else
            {
                throw new ArgumentException(folder + " not exists");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var filename = Path.Combine(this.Folder, "code.cloe.db");
            optionsBuilder.UseSqlite("Data Source=" + filename);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConfigSubject());
            modelBuilder.ApplyConfiguration(new ConfigContact());
        }

        public void Migrate()
        {
            this.Database.Migrate();
        }

        public async Task MigrateAsync()
        {
            await this.Database.MigrateAsync();
        }
    }
}
