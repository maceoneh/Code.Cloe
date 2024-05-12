using Code.Cloe.Application.Interfaces;
using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Application.Services
{
    public class ContactService : IServiceBase<Contact, Guid>
    {
        private readonly IRepositoryBase<Contact, Guid> PhoneRepository;

        public ContactService(IRepositoryBase<Contact, Guid> subjectRepository)
        {
            this.PhoneRepository = subjectRepository;
        }

        public Contact Add(Contact item)
        {
            if (item == null)
            { 
                throw new ArgumentNullException("Phone object cant be null");
            }
            //-----
            item.ID = Guid.NewGuid();
            //----
            this.PhoneRepository.Add(item);
            //----
            return item;
        }

        public async Task<Contact> AddAsync(Contact item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Phone object cant be null");
            }
            //-----
            item.ID = Guid.NewGuid();
            //----
            await this.PhoneRepository.AddAsync(item);
            //----
            return item;
        }

        public void Delete(Guid id)
        {
            this.PhoneRepository.Delete(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await this.PhoneRepository.DeleteAsync(id);
        }

        public Contact? Edit(Contact item)
        {
            return this.PhoneRepository.Edit(item);
        }

        public async Task<Contact?> EditAsync(Contact item)
        {
            return await this.PhoneRepository.EditAsync(item);
        }

        public Contact? Get(Guid id)
        {
            return this.PhoneRepository.Get(id);
        }

        public async Task<Contact?> GetAsync(Guid id)
        {
            return await this.PhoneRepository.GetAsync(id);
        }

        public List<Contact> List()
        {
            return this.PhoneRepository.List();
        }

        public async Task<List<Contact>> ListAsync()
        {
            return await this.PhoneRepository.ListAsync();
        }

        public IQueryable<Contact> Where(Expression<Func<Contact, bool>> predicate)
        {
            return this.PhoneRepository.Where(predicate);
        }
    }
}
