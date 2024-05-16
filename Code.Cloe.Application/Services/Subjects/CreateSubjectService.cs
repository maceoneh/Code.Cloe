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
    public class CreateSubjectService : IServiceCreate<SubjectDTO>
    {
        private readonly IRepositoryBase<Subject, Guid> SubjectRepository;

        public CreateSubjectService(IRepositoryBase<Subject, Guid> subjectRepository)
        {
            this.SubjectRepository = subjectRepository;
        }

        public SubjectDTO Add(SubjectDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("SubjectDTO can't be null");
            }
            //----- Se cargan los modelos
            List<Contact>? modelContacts = null;
            if (item.Contacts != null)
            {
                modelContacts = new List<Contact>(item.Contacts.Count);
                foreach (var contact in item.Contacts)
                {
                    modelContacts.Add(new Contact(contact.Name, contact.PhoneNumber, null));
                }
            }            
            var newModel = this.SubjectRepository.Add(new Subject(item.ID, item.Name, item.Address, item.PostalCode, item.Location, item.Province));            
            this.SubjectRepository.Commit();
            //----- Se asignan los nuevos IDs
            item.ID = newModel.ID;
            if (modelContacts != null && item.Contacts != null)
            {
                for (int i = 0; i < modelContacts.Count; i++)
                {
                    item.Contacts[i].ID = newModel.ID;
                }
            }
            return item;
        }

        public async Task<SubjectDTO> AddAsync(SubjectDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("SubjectDTO can't be null");
            }
            //----- Se cargan los modelos
            List<Contact>? modelContacts = null;
            if (item.Contacts != null)
            {
                modelContacts = new List<Contact>(item.Contacts.Count);
                foreach (var contact in item.Contacts)
                {
                    modelContacts.Add(new Contact(contact.Name, contact.PhoneNumber, null));
                }
            }
            var newModel = await this.SubjectRepository.AddAsync(new Subject(item.ID, item.Name, item.Address, item.PostalCode, item.Location, item.Province) {  Contacts = modelContacts });
            this.SubjectRepository.Commit();
            //----- Se asignan los nuevos IDs
            item.ID = newModel.ID;
            if (modelContacts != null && item.Contacts != null)
            {
                for (int i = 0; i < modelContacts.Count; i++)
                {
                    item.Contacts[i].ID = newModel.ID;
                }
            }
            return item;
        }
    }
}
