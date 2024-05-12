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
    public class PhoneService : IServiceBase<Phone, Guid>
    {
        private readonly IRepositoryBase<Phone, Guid> PhoneRepository;

        public PhoneService(IRepositoryBase<Phone, Guid> subjectRepository)
        {
            this.PhoneRepository = subjectRepository;
        }

        public Phone Add(Phone item)
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

        public async Task<Phone> AddAsync(Phone item)
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

        public Phone? Edit(Phone item)
        {
            return this.PhoneRepository.Edit(item);
        }

        public async Task<Phone?> EditAsync(Phone item)
        {
            return await this.PhoneRepository.EditAsync(item);
        }

        public Phone? Get(Guid id)
        {
            return this.PhoneRepository.Get(id);
        }

        public async Task<Phone?> GetAsync(Guid id)
        {
            return await this.PhoneRepository.GetAsync(id);
        }

        public List<Phone> List()
        {
            return this.PhoneRepository.List();
        }

        public async Task<List<Phone>> ListAsync()
        {
            return await this.PhoneRepository.ListAsync();
        }

        public IQueryable<Phone> Where(Expression<Func<Phone, bool>> predicate)
        {
            return this.PhoneRepository.Where(predicate);
        }
    }
}
