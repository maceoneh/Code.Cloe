using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Models
{
    /// <summary>
    /// Modelo destina a contener un sujeto, que seria una clase base de un elemento más complejo como un cliente, un proveedor
    /// ,...
    /// </summary>
    public class Subject
    {
        public Guid ID { get; set; }

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
        [MaxLength(5)]
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
        /// Listado de teléfonos asociados al sujeto
        /// </summary>
        public List<Contact>? Contacts { get; set; }

        public override string ToString()
        {
            var text = "Nombre: " + this.Name + " Dirección: " + this.Address + " Población: " + this.Location + " Provincia: " + this.Province + " CP: " + this.PostalCode;
            if (this.Contacts != null)
            {
                foreach (var phone in this.Contacts)
                { 
                    text += phone.ToString() + " ";
                }
            }
            return text.TrimEnd();
        }
    }
}
