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
    public class ContactServiceOLD : IServiceBase<ContactOLD, Guid>
    {
        private readonly IRepositoryBase<ContactOLD, Guid> PhoneRepository;

        public ContactServiceOLD(IRepositoryBase<ContactOLD, Guid> subjectRepository)
        {
            this.PhoneRepository = subjectRepository;
        }

        public ContactOLD Add(ContactOLD item)
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

        public async Task<ContactOLD> AddAsync(ContactOLD item)
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

        public ContactOLD? Edit(ContactOLD item)
        {
            return this.PhoneRepository.Edit(item);
        }

        public async Task<ContactOLD?> EditAsync(ContactOLD item)
        {
            return await this.PhoneRepository.EditAsync(item);
        }

        public ContactOLD? Get(Guid id)
        {
            return this.PhoneRepository.Get(id);
        }

        public async Task<ContactOLD?> GetAsync(Guid id)
        {
            return await this.PhoneRepository.GetAsync(id);
        }

        public List<ContactOLD> List()
        {
            return this.PhoneRepository.List();
        }

        public async Task<List<ContactOLD>> ListAsync()
        {
            return await this.PhoneRepository.ListAsync();
        }

        public IQueryable<ContactOLD> Where(Expression<Func<ContactOLD, bool>> predicate)
        {
            return this.PhoneRepository.Where(predicate);
        }
    }
}
