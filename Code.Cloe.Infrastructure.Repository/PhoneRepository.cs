using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Infrastructure.Repository
{
    public class PhoneRepository : IRepositoryBase<Phone, Guid>
    {
        private RepositoryContext db;

        public PhoneRepository(RepositoryContext db)
        {
            this.db = db;
        }

        public Phone Add(Phone item)
        {
            item.ID = Guid.NewGuid();
            this.db.Phones.Add(item);
            return item;
        }

        public async Task<Phone> AddAsync(Phone item)
        {
            item.ID = Guid.NewGuid();
            await this.db.Phones.AddAsync(item);
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
            var entry = this.db.Phones.FirstOrDefault(x => x.ID == id);
            if (entry != null)
            { 
                this.db.Phones.Remove(entry);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entry = await this.db.Phones.FirstOrDefaultAsync(x => x.ID == id);
            if (entry != null)
            {
                this.db.Phones.Remove(entry);
            }
        }

        public Phone? Edit(Phone item)
        {
            var entry = this.db.Phones.FirstOrDefault(x => x.ID == item.ID);
            if (entry != null)
            { 
                entry.PhoneNumber = item.PhoneNumber;
                entry.NameContact = item.NameContact;
                this.db.Phones.Entry(entry).State = EntityState.Modified;
            }
            return entry;
        }

        public async Task<Phone?> EditAsync(Phone item)
        {
            var entry = await this.db.Phones.FirstOrDefaultAsync(x => x.ID == item.ID);
            if (entry != null)
            {
                entry.PhoneNumber = item.PhoneNumber;
                entry.NameContact = item.NameContact;
                this.db.Phones.Entry(entry).State = EntityState.Modified;
            }
            return entry;
        }

        public Phone? Get(Guid id)
        {
            return this.db.Phones.FirstOrDefault(x => x.ID == id);
        }

        public async Task<Phone?> GetAsync(Guid id)
        {
            return await this.db.Phones.FirstOrDefaultAsync(x => x.ID == id);
        }

        public List<Phone> List()
        {
            return this.db.Phones.ToList();
        }

        public async Task<List<Phone>> ListAsync()
        {
            return await this.db.Phones.ToListAsync();
        }
    }
}
