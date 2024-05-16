using Code.Cloe.Application.Services.Subjects;
using Code.Cloe.Application.Services.Subjects.DTO;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Proxies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Infrastructure.Proxies.Services.Subjects
{
    public class SubjectDTOProxy : IDTOProxy<SubjectDTO>
    {
        public SubjectDTO Model { get; }

        private List<ContactDTO>? _Contacts = null;

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
        /// Listado de formas de contacto de un sujeto
        /// </summary>
        public List<ContactDTO>? Contacts 
        {
            get
            {
                this.LoadData();
                return this._Contacts;
            }
        }

        public SubjectDTOProxy(SubjectDTO model) 
        {  
            this.Model = model; 
        }

        public void Initialize()
        {
            this._Contacts = null;
        }

        public void LoadData()
        {
            if (this._Contacts == null)
            {
                var serviceContact = new ListContactService(Repository.Factory.Repository.Create<Contact>());
                this._Contacts = serviceContact.ListBySubjectDTO(this.Model);
            }
        }

        public Task LoadDataAsync()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var txt = this.Model.ToString() + Environment.NewLine;
            if (this.Contacts != null)
            {
                txt += "Contacto:";
                foreach (var item in this.Contacts)
                {
                    txt += Environment.NewLine + item.ToString();
                }
            }
            return txt.TrimEnd();
        }
    }
}
