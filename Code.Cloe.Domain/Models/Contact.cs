using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Models
{
    public record Contact(string? Name, string? PhoneNumber, string? eMail)
    {
        public Guid ID { get; set; } 
        public Guid IDSubject { get; set; }

        public Contact(Guid ID, Guid IDSubject, string? Name, string? PhoneNumber, string? eMail) : this(Name, PhoneNumber, eMail)
        { 
            this.ID = ID;
            this.IDSubject = IDSubject;
        }
    }
}
