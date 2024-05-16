using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Infrastructure.Repository
{
    internal class ContactRepository : IRepositoryBase<Contact, Guid>
    {
        private RepositoryContext db;

        internal ContactRepository(RepositoryContext db)
        {
            this.db = db;
        }

        public Contact Add(Contact item)
        {
            throw new NotImplementedException("Use SubjectRepository to this");
        }

        public Task<Contact> AddAsync(Contact item)
        {
            throw new NotImplementedException("Use SubjectRepository to this");
        }

        public void Commit()
        {
            this.db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await this.db.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException("Use SubjectRepository to this");
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException("Use SubjectRepository to this");
        }

        public Contact? Edit(Contact item)
        {
            throw new NotImplementedException("Use SubjectRepository to this");
        }

        public Task<Contact?> EditAsync(Contact item)
        {
            throw new NotImplementedException("Use SubjectRepository to this");
        }

        public Contact? Get(Guid id)
        {
            return this.db.Contacts.Where(c => c.ID == id).FirstOrDefault();
        }

        public async Task<Contact?> GetAsync(Guid id)
        {
            return await this.db.Contacts.Where(c => c.ID == id).FirstOrDefaultAsync();
        }

        public List<Contact> List()
        {
            return this.db.Contacts.ToList();
        }

        public async Task<List<Contact>> ListAsync()
        {
            return await this.db.Contacts.ToListAsync();
        }

        public IQueryable<Contact> Where(Expression<Func<Contact, bool>> predicate)
        {
            return this.db.Contacts.Where(predicate);
        }
    }
}
