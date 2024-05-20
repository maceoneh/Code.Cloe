using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Models
{
    public record Detail
    {
        public Guid IDMasterDetail { get; set; }
        public int LineNumber { get; set; }
        public string Code { get; set; }
    }
}
