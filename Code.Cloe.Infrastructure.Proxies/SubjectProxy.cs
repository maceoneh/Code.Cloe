using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Factories.Services;
using Code.Cloe.Infrastructure.Proxies.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Code.Cloe.Infrastructure.Proxies
{
    public class SubjectProxy : IModelProxy<Subject>
    {
        public Subject Model { get; }

        public SubjectProxy(Subject model)
        {
            this.Model = model;
        }

        public Guid ID => this.Model.ID;

        /// <summary>
        /// Nombre
        /// </summary>
        public string? Name => this.Model.Name;

        /// <summary>
        /// Dirección
        /// </summary>
        public string? Address => this.Model.Address;

        /// <summary>
        /// Código postal
        /// </summary>        
        public string? PostalCode => this.Model.PostalCode;

        /// <summary>
        /// Población
        /// </summary>
        public string? Location => this.Model.Location;

        /// <summary>
        /// Provincia
        /// </summary>
        public string? Province => this.Model.Province;

        /// <summary>
        /// Listado de teléfonos asociados al sujeto
        /// </summary>
        public Task<List<Contact>> ContactsAsync 
        {
            get
            {
                return Task.Factory.StartNew<List<Contact>>(() => 
                {
                    this.LoadContacts();
                    return this.Model.Contacts == null ? new List<Contact>() : this.Model.Contacts;
                });                
            }
        }

        public List<Contact> Contacts
        {
            get
            {
                this.LoadContacts();
                return this.Model.Contacts == null ? new List<Contact>() : this.Model.Contacts;
            }
        }

        private void LoadContacts()
        {
            if (this.Model.Contacts == null)
            {
                this.Model.Contacts = new List<Contact>();
                //-----
                var phoneService = Create.ServiceBase<Contact>();
                var phones = phoneService.Where(p => p.SubjectID == this.ID);
                foreach (var item in phones)
                {
                    this.Model.Contacts.Add(item);
                }
            }
        }

        private async Task LoadContactsAsync()
        {
            if (this.Model.Contacts == null)
            {
                this.Model.Contacts = new List<Contact>();
                //-----
                var phoneService = Create.ServiceBase<Contact>();
                var phones = await phoneService.Where(p => p.SubjectID == this.ID).ToListAsync();
                foreach (var item in phones)
                {
                    this.Model.Contacts.Add(item);
                }
            }
        }

        public override string ToString()
        {
            this.LoadContacts();
            return this.Model.ToString();
        }

        public void LoadData()
        {
            this.LoadContacts();
        }

        public async Task LoadDataAsync()
        {
            await this.LoadContactsAsync();
        }

        public void Initialize()
        {
            this.Model.Contacts = null;
        }
    }
}
