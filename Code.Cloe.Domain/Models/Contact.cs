using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Models
{
    /// <summary>
    /// Modelo para guardar un teléfono de un contacto
    /// </summary>
    public class Contact
    {
        public Guid ID { get; set; }

        /// <summary>
        /// ID del sujeto al que pertenece
        /// </summary>
        public Guid SubjectID { get; set; }

        /// <summary>
        /// Número de telefono
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Nombre del contacto asociado al telefono
        /// </summary>
        public string? NameContact { get; set; }

        public override string ToString()
        {
            var txt = "Nombre contacto: " + this.NameContact + " Teléfono: " + this.PhoneNumber;
            return txt;
        }
    }
}
