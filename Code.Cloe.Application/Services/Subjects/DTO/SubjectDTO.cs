using Code.Cloe.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Application.Services.Subjects.DTO
{
    public class SubjectDTO
    {
        internal Guid ID { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Dirección
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Código postal
        /// </summary>        
        public string? PostalCode { get; set; }

        /// <summary>
        /// Población
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Provincia
        /// </summary>
        public string? Province { get; set; } 
        
        /// <summary>
        /// Listado de formas de contacto de un sujeto
        /// </summary>
        public List<ContactDTO>? Contacts { get; set; }

        public override string ToString()
        {
            var text = "Nombre: " + this.Name + " Dirección: " + this.Address + " Población: " + this.Location + " Provincia: " + this.Province + " CP: " + this.PostalCode;           
            return text.TrimEnd();
        }
    }
}
