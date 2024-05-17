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
        public SubjectDTO DTO { get; }

        public string? Name => this.DTO.Name;

        /// <summary>
        /// Dirección
        /// </summary>
        public string? Address => this.DTO.Address;

        /// <summary>
        /// Código postal
        /// </summary>        
        public string? PostalCode => this.DTO.PostalCode;

        /// <summary>
        /// Población
        /// </summary>
        public string? Location => this.DTO.Location;

        /// <summary>
        /// Provincia
        /// </summary>
        public string? Province => this.DTO.Province;

        

        /// <summary>
        /// Listado de formas de contacto de un sujeto
        /// </summary>
        public List<ContactDTO>? Contacts 
        {
            get
            {
                this.LoadData();
                return this.DTO.Contacts;
            }
        }

        public bool DataLoaded { get; private set; } = false;

        public SubjectDTOProxy(SubjectDTO model) 
        {  
            this.DTO = model; 
        }

        public void Initialize()
        {
            this.DTO.Contacts = null;
            //-----
            this.DataLoaded = false;
        }

        public void LoadData()
        {
            if (this.DTO.Contacts == null)
            {
                var serviceContact = new ListContactService(Repository.Factory.Repository.Create<Contact>());
                this.DTO.Contacts = serviceContact.ListBySubjectDTO(this.DTO);
            }
            //-----
            this.DataLoaded = true;
        }

        public Task LoadDataAsync()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var txt = this.DTO.ToString() + Environment.NewLine;
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
