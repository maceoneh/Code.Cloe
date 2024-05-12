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
        public Task<List<Phone>> PhonesAsync 
        {
            get
            {
                return Task.Factory.StartNew<List<Phone>>(() => 
                {
                    this.LoadPhones();
                    return this.Model.Phones == null ? new List<Phone>() : this.Model.Phones;
                });                
            }
        }

        public List<Phone> Phones
        {
            get
            {
                this.LoadPhones();
                return this.Model.Phones == null ? new List<Phone>() : this.Model.Phones;
            }
        }

        private void LoadPhones()
        {
            if (this.Model.Phones == null)
            {
                this.Model.Phones = new List<Phone>();
                //-----
                var phoneService = Create.ServiceBase<Phone>();
                var phones = phoneService.Where(p => p.SubjectID == this.ID);
                foreach (var item in phones)
                {
                    this.Model.Phones.Add(item);
                }
            }
        }

        private async Task LoadPhonesAsync()
        {
            if (this.Model.Phones == null)
            {
                this.Model.Phones = new List<Phone>();
                //-----
                var phoneService = Create.ServiceBase<Phone>();
                var phones = await phoneService.Where(p => p.SubjectID == this.ID).ToListAsync();
                foreach (var item in phones)
                {
                    this.Model.Phones.Add(item);
                }
            }
        }

        public override string ToString()
        {
            this.LoadPhones();
            return this.Model.ToString();
        }

        public void LoadData()
        {
            this.LoadPhones();
        }

        public async Task LoadDataAsync()
        {
            await this.LoadPhonesAsync();
        }

        public void Initialize()
        {
            this.Model.Phones = null;
        }
    }
}
