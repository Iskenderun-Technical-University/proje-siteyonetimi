using ResidenceManagement.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Domain.Entities.Managements
{
    public class ResidenceDues : EntityBase
    {
        public int DuesId { get; set; }
        public Dues Dues { get; set; }
        public int UserResidenceId { get; set; }
        public UserResidence UserResidence { get; set; }
        public bool IsPaid { get; set; }
        
    }
}
