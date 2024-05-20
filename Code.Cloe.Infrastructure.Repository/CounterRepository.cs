using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Infrastructure.Repository
{
    internal class CounterRepository : IRepositoryBase<Counter, Guid>
    {
        private RepositoryContext RepositoryContext { get; }

        public CounterRepository(RepositoryContext repositoryContext) { 
            this.RepositoryContext = repositoryContext;
        }

        public Counter Add(Counter item)
        {
            item.ID = Guid.NewGuid();
            item.CreateDateTime = DateTime.Now;
            item.IsDeleted = false;
            this.RepositoryContext.Counters.Add(item);
            return item;
        }

        public async Task<Counter> AddAsync(Counter item)
        {
            item.ID = Guid.NewGuid();
            item.CreateDateTime = DateTime.Now;
            item.IsDeleted = false;
            await this.RepositoryContext.Counters.AddAsync(item);
            return item;
        }

        public void Commit()
        {
            this.RepositoryContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await this.RepositoryContext.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            var toDelete = this.RepositoryContext.Counters.Where(c => c.ID == id).FirstOrDefault();
            if (toDelete != null)
            {
                toDelete.IsDeleted = true;
                toDelete.DeleteDateTime = DateTime.Now;
                this.RepositoryContext.Entry(toDelete).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var toDelete = await this.RepositoryContext.Counters.Where(c => c.ID == id).FirstOrDefaultAsync();
            if (toDelete != null)
            {
                toDelete.IsDeleted = true;
                toDelete.DeleteDateTime = DateTime.Now;
                this.RepositoryContext.Entry(toDelete).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public Counter? Edit(Counter item)
        {
            var toModify = this.RepositoryContext.Counters.Where(c => c.ID == item.ID).FirstOrDefault();
            if (toModify != null)
            {
                toModify.ModifyDateTime = DateTime.Now;
                toModify.Number = item.Number;
                toModify.Type = item.Type;
                this.RepositoryContext.Entry(toModify).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return toModify;
        }

        public async Task<Counter?> EditAsync(Counter item)
        {
            var toModify = await this.RepositoryContext.Counters.Where(c => c.ID == item.ID).FirstOrDefaultAsync();
            if (toModify != null)
            {
                toModify.ModifyDateTime = DateTime.Now;
                toModify.Number = item.Number;
                toModify.Type = item.Type;
                this.RepositoryContext.Entry(toModify).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return toModify;
        }

        public Counter? Get(Guid id)
        {
            return this.RepositoryContext.Counters.Where(c => c.ID == id).FirstOrDefault();
        }

        public async Task<Counter?> GetAsync(Guid id)
        {
            return await this.RepositoryContext.Counters.Where(c => c.ID == id).FirstOrDefaultAsync();
        }

        public List<Counter> List()
        {
            return this.RepositoryContext.Counters.ToList();
        }

        public async Task<List<Counter>> ListAsync()
        {
            return await this.RepositoryContext.Counters.ToListAsync();
        }

        public IQueryable<Counter> Where(Expression<Func<Counter, bool>> predicate)
        {
            return this.RepositoryContext.Counters.Where(predicate);
        }
    }
}
