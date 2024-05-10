using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Repository.Configs;
using Microsoft.EntityFrameworkCore;

namespace Code.Cloe.Infrastructure.Repository.Contexts
{
    public class RepositoryContext : DbContext
    {
        internal string Folder { get; private set; }
        internal DbSet<Subject> Subjects { get; set; }

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
        }

        public void Migrate()
        {
            this.Database.Migrate();
        }

        public async void MigrateAsync()
        {
            await this.Database.MigrateAsync();
        }
    }
}
