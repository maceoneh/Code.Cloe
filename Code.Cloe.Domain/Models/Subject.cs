using Code.Cloe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Models
{
    public record Subject : ISoftDelete
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? Location { get; set; }
        public string? Province { get; set; }
        public List<Contact>? Contacts { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteDateTime { get; set; }

        public Subject(Guid ID, string? Name, string? Address, string? PostalCode, string? Location, string? Province) 
        { 
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;                
            this.PostalCode = PostalCode;
            this.Location = Location;
            this.Province = Province;
            this.Contacts = new List<Contact>();
        }
    }
}
