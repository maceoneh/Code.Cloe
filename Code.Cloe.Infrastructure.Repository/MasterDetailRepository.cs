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
    internal class MasterDetailRepository : IRepositoryBase<MasterDetail, Guid>
    {
        private RepositoryContext RepositoryContext { get; }
        public MasterDetailRepository(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext; ;
        }
        public MasterDetail Add(MasterDetail item)
        {
            item.ID = Guid.NewGuid();
            item.IsDeleted = false;
            item.CreateDateTime = DateTime.Now;
            this.RepositoryContext.MasterDetails.Add(item);
            return item;
        }

        public async Task<MasterDetail> AddAsync(MasterDetail item)
        {
            item.ID = Guid.NewGuid();
            item.IsDeleted = false;
            item.CreateDateTime = DateTime.Now;
            await this.RepositoryContext.MasterDetails.AddAsync(item);
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
            var toDelete = this.RepositoryContext.MasterDetails.Where(md => md.ID == id).FirstOrDefault();
            if (toDelete != null)
            {
                toDelete.IsDeleted = true;
                toDelete.DeleteDateTime = DateTime.Now;
                this.RepositoryContext.Entry(toDelete).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var toDelete = await this.RepositoryContext.MasterDetails.Where(md => md.ID == id).FirstOrDefaultAsync();
            if (toDelete != null)
            {
                toDelete.IsDeleted = true;
                toDelete.DeleteDateTime = DateTime.Now;
                this.RepositoryContext.Entry(toDelete).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public MasterDetail? Edit(MasterDetail item)
        {
            var toModify = this.RepositoryContext.MasterDetails.Where(md => md.ID == item.ID).FirstOrDefault();
            if (toModify != null)
            {
                toModify.ModifyDateTime = DateTime.Now;
                toModify.Type = item.Type;
                toModify.Number = item.Number;
                toModify.Name = item.Name;
                toModify.Date = item.Date;
                toModify.Address = item.Address;
                toModify.Location = item.Location;                                
                toModify.Province = item.Province;
                toModify.Detail = item.Detail;
                this.RepositoryContext.MasterDetails.Entry(toModify).State = EntityState.Modified;
            }
            return toModify;
        }

        public async Task<MasterDetail?> EditAsync(MasterDetail item)
        {
            var toModify = await this.RepositoryContext.MasterDetails.Where(md => md.ID == item.ID).FirstOrDefaultAsync();
            if (toModify != null)
            {
                toModify.ModifyDateTime = DateTime.Now;
                toModify.Type = item.Type;
                toModify.Number = item.Number;
                toModify.Name = item.Name;
                toModify.Date = item.Date;
                toModify.Address = item.Address;
                toModify.Location = item.Location;
                toModify.Province = item.Province;
                toModify.Detail = item.Detail;
                this.RepositoryContext.MasterDetails.Entry(toModify).State = EntityState.Modified;
            }
            return toModify;
        }

        public MasterDetail? Get(Guid id)
        {
            return this.RepositoryContext.MasterDetails.Where(md =>md.ID == id).FirstOrDefault();
        }

        public async Task<MasterDetail?> GetAsync(Guid id)
        {
            return await this.RepositoryContext.MasterDetails.Where(md => md.ID == id).FirstOrDefaultAsync();
        }

        public List<MasterDetail> List()
        {
            return this.RepositoryContext.MasterDetails.ToList();
        }

        public async Task<List<MasterDetail>> ListAsync()
        {
            return await this.RepositoryContext.MasterDetails.ToListAsync();
        }

        public IQueryable<MasterDetail> Where(Expression<Func<MasterDetail, bool>> predicate)
        {
            return this.RepositoryContext.MasterDetails.Where(predicate);
        }
    }
}
