using Code.Cloe.Application.Interfaces;
using Code.Cloe.Application.Services.Subjects.DTO;
using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Application.Services.Subjects
{
    public class ListContactService : IServiceList<ContactDTO, Guid>
    {
        private readonly IRepositoryBase<Contact, Guid> Repository;

        public ListContactService(IRepositoryBase<Contact, Guid> repository) 
        { 
            this.Repository = repository;
        }

        public ContactDTO? Get(Guid id)
        {
            var model = this.Repository.Get(id);
            if (model != null) {
                return new ContactDTO { 
                    ID = model.ID,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                };
            }
            return null;
        }

        public async Task<ContactDTO?> GetAsync(Guid id)
        {
            var model = await this.Repository.GetAsync(id);
            if (model != null)
            {
                return new ContactDTO
                {
                    ID = model.ID,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                };
            }
            return null;
        }

        public List<ContactDTO> List()
        {
            var models = this.Repository.List();
            var resultList = new List<ContactDTO>(models.Count);
            foreach (var model in models)
            {
                resultList.Add(new ContactDTO { 
                    ID = model.ID,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                });
            }
            return resultList;
        }

        public async Task<List<ContactDTO>> ListAsync()
        {
            var models = await this.Repository.ListAsync();
            var resultList = new List<ContactDTO>(models.Count);
            foreach (var model in models)
            {
                resultList.Add(new ContactDTO
                {
                    ID = model.ID,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                });
            }
            return resultList;
        }

        internal List<ContactDTO> ListByGuid(params Guid[] IDSubjects)
        {
            var models = this.Repository.Where(c => IDSubjects.Contains(c.IDSubject)).ToList();
            var resultList = new List<ContactDTO>(models.Count);
            foreach (var item in models)
            {
                resultList.Add(new ContactDTO { 
                    ID = item.ID,
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber
                });
            }
            return resultList;
        }

        public List<ContactDTO> ListBySubjectDTO(SubjectDTO subject)
        {
            var models = this.Repository.Where(c => c.IDSubject == subject.ID).ToList();
            var resultList = new List<ContactDTO>(models.Count);
            foreach (var item in models)
            {
                resultList.Add(new ContactDTO
                {
                    ID = item.ID,
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber
                });
            }
            return resultList;
        }
    }
}
