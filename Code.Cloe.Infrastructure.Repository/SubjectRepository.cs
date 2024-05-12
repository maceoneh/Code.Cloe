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
    public class SubjectRepository : IRepositoryBase<Subject, Guid>
    {
        private RepositoryContext db;

        public SubjectRepository(RepositoryContext db) 
        {
            this.db = db;
        }

        public Subject Add(Subject item)
        {
            item.ID = Guid.NewGuid();
            this.db.Subjects.Add(item);
            return item;
        }

        public async Task<Subject> AddAsync(Subject item)
        {
            item.ID = Guid.NewGuid();
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
            var to_delete = this.db.Subjects.Where(e => e.ID == id).FirstOrDefault();
            if (to_delete != null)
            {
                this.db.Subjects.Remove(to_delete);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var to_delete = await this.db.Subjects.Where(e => e.ID == id).FirstOrDefaultAsync();
            if (to_delete != null)
            {
                this.db.Subjects.Remove(to_delete);
            }
        }

        public Subject? Edit(Subject item)
        {
            var to_modify = this.db.Subjects.Where(e => e.ID == item.ID).FirstOrDefault();
            if (to_modify != null)
            {
                to_modify.Name = item.Name;
                to_modify.Address = item.Address;
                to_modify.Province = item.Province;
                to_modify.Location = item.Location;
                to_modify.PostalCode = item.PostalCode;
                to_modify.Phones = item.Phones;
                this.db.Subjects.Entry(to_modify).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return to_modify;
        }

        public async Task<Subject?> EditAsync(Subject item)
        {
            var to_modify = await this.db.Subjects.Where(e => e.ID == item.ID).FirstOrDefaultAsync();
            if (to_modify != null)
            {
                to_modify.Name = item.Name;
                to_modify.Address = item.Address;
                to_modify.Province = item.Province;
                to_modify.Location = item.Location;
                to_modify.PostalCode = item.PostalCode;
                to_modify.Phones = item.Phones;
                this.db.Entry(to_modify).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return to_modify;
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
