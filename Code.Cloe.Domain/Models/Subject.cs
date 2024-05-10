using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Models
{
    public class Subject
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        [MaxLength(5)]
        public string? PostalCode { get; set; }

        public string? Location { get; set; }

        public override string ToString()
        {
            var text = "Nombre: " + this.Name + " Address: " + this.Address;
            return text;
        }
    }
}
