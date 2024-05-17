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
    public class EditSubjectService : IServiceEdit<SubjectDTO>
    {
        private readonly IRepositoryBase<Subject, Guid> RepositorySubject;

        public EditSubjectService(IRepositoryBase<Subject, Guid> repositorySubject)
        {
            RepositorySubject = repositorySubject;
        }

        public SubjectDTO? Edit(SubjectDTO item)
        {
            //----- Se vuelca el DTO en los modelos
            var model = new Subject(item.ID, item.Name, item.Address, item.PostalCode, item.Location, item.Province);
            var contactModels = new List<Contact>(item.Contacts == null ? 0 : item.Contacts.Count);
            if (item.Contacts != null)
            {
                foreach(var contact in item.Contacts)
                {
                    contactModels.Add(new Contact(contact.ID, item.ID, contact.Name, contact.PhoneNumber, null));
                }
            }
            //-----
            model = this.RepositorySubject.Edit(model);
            if (model != null)
            {
                this.RepositorySubject.Commit();
                //----- Se reasignan IDs por si se ha agregado alguno nuevo
                if (item.Contacts != null)
                {
                    for (int i = 0; i < item.Contacts.Count; i++)
                    {
                        item.Contacts[i].ID = contactModels[i].ID;
                    }
                }
                //-----
                return item;
            }
            else
            {
                return null;
            }
        }

        public async Task<SubjectDTO?> EditAsync(SubjectDTO item)
        {
            //----- Se vuelca el DTO en los modelos            
            var contactModels = new List<Contact>(item.Contacts == null ? 0 : item.Contacts.Count);
            if (item.Contacts != null)
            {
                foreach (var contact in item.Contacts)
                {
                    contactModels.Add(new Contact(contact.ID, item.ID, contact.Name, contact.PhoneNumber, null));
                }
            }
            var model = new Subject(item.ID, item.Name, item.Address, item.PostalCode, item.Location, item.Province) { Contacts = contactModels };
            //-----
            model = await this.RepositorySubject.EditAsync(model);
            if (model != null)
            {
                await this.RepositorySubject.CommitAsync();
                //----- Se reasignan IDs por si se ha agregado alguno nuevo
                if (item.Contacts != null)
                {
                    for (int i = 0; i < item.Contacts.Count; i++)
                    {
                        item.Contacts[i].ID = contactModels[i].ID;
                    }
                }
                //-----
                return item;
            }
            else
            {
                return null;
            }
        }
    }
}
