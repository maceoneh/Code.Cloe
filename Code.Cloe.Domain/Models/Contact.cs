using Code.Cloe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Models
{
    public record Contact : ISoftDelete
    {
        public Guid ID { get; set; } 
        public Guid IDSubject { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; } 
        public string? eMail { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteDateTime { get; set; }

        public Contact(Guid ID, Guid IDSubject, string? Name, string? PhoneNumber, string? eMail)
        { 
            this.ID = ID;
            this.IDSubject = IDSubject;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.eMail = eMail;
        }

        public Contact(string? Name, string? PhoneNumber, string? eMail)
        {            
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.eMail = eMail;
        }
    }
}
