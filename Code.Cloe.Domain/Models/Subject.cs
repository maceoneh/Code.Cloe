using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Models
{
    public record Subject(string? Name, string? Address, string? PostalCode, string? Location, string? Province)
    {
        public Guid ID { get; set; }
        public List<Contact>? Contacts { get; init; }

        public Subject(Guid ID, string? Name, string? Address, string? PostalCode, string? Location, string? Province) :
            this(Name, Address, PostalCode, Location, Province)
        { 
            this.ID = ID;
        }
    }
}
