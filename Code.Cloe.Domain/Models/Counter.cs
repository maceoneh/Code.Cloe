using Code.Cloe.Domain.Enums;
using Code.Cloe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Domain.Models
{
    public record Counter : ISoftDelete, ICreateData, IModifyData
    {
        public Guid ID { get; set; }
        public EMasterDetailType Type { get; set; }
        public int Number { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
    }
}
