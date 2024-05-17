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
    internal class SubjectRepository : IRepositoryBase<Subject, Guid>
    {
        private RepositoryContext db;

        internal SubjectRepository(RepositoryContext db)
        {
            this.db = db;
        }

        public Subject Add(Subject item)
        {
            item.ID = Guid.NewGuid();
            item.CreateDateTime = DateTime.Now;
            this.db.Subjects.Add(item);
            return item;
        }

        public async Task<Subject> AddAsync(Subject item)
        {
            item.ID = Guid.NewGuid();
            item.CreateDateTime = DateTime.Now;
            await this.db.Subjects.AddAsync(item);
            return item;
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
            //var to_delete = this.db.Subjects.Where(e => e.ID == id).FirstOrDefault();
            //if (to_delete != null)
            //{
            //    this.db.Subjects.Remove(to_delete);
            //}
            var toDelete = this.db.Subjects.Where(e => e.ID == id).FirstOrDefault();
            if (toDelete != null)
            {
                toDelete.IsDeleted = true;
                toDelete.DeleteDateTime = DateTime.Now;
                this.db.Subjects.Entry(toDelete).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            //var to_delete = await this.db.Subjects.Where(e => e.ID == id).FirstOrDefaultAsync();
            //if (to_delete != null)
            //{
            //    this.db.Subjects.Remove(to_delete);
            //}
            var toDelete = this.db.Subjects.Where(e => e.ID == id).FirstOrDefault();
            if (toDelete != null)
            {
                toDelete.IsDeleted = true;
                toDelete.DeleteDateTime = DateTime.Now;
                this.db.Subjects.Entry(toDelete).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public Subject? Edit(Subject item)
        {
            var toModify = this.db.Subjects.Where(e => e.ID == item.ID).FirstOrDefault();
            if (toModify != null)
            {
                toModify.Name = item.Name;
                toModify.Address = item.Address;
                toModify.PostalCode = item.PostalCode;
                toModify.Location = item.Location;
                toModify.Province = item.Province;    
                toModify.Contacts = item.Contacts;
                toModify.ModifyDateTime = DateTime.Now;
                this.db.Subjects.Entry(toModify).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return toModify;
        }

        public async Task<Subject?> EditAsync(Subject item)
        {
            var toModify = await this.db.Subjects.Where(e => e.ID == item.ID).FirstOrDefaultAsync();
            if (toModify != null)
            {
                toModify.Name = item.Name;
                toModify.Address = item.Address;
                toModify.PostalCode = item.PostalCode;
                toModify.Location = item.Location;
                toModify.Province = item.Province;
                toModify.Contacts = item.Contacts;
                toModify.ModifyDateTime = DateTime.Now;
                this.db.Entry(toModify).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return toModify;
        }

        public Subject? Get(Guid id)
        {
            return this.db.Subjects.Where(e => e.ID == id).FirstOrDefault();
        }

        public async Task<Subject?> GetAsync(Guid id)
        {
            return await this.db.Subjects.Where(e => e.ID == id).FirstOrDefaultAsync();
        }

        public List<Subject> List()
        {
            return this.db.Subjects.ToList();
        }

        public async Task<List<Subject>> ListAsync()
        {
            return await this.db.Subjects.ToListAsync();
        }

        public IQueryable<Subject> Where(Expression<Func<Subject, bool>> predicate)
        {
            return this.db.Subjects.Where<Subject>(predicate);
        }
    }
}
