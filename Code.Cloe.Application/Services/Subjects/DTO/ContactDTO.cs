using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Application.Services.Subjects.DTO
{
    public class ContactDTO
    {
        internal Guid ID;
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
