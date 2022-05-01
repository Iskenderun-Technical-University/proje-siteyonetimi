using ResidenceManagement.Domain.Commons;
using ResidenceManagement.Domain.Entities.Auths;
using System.Collections.Generic;

namespace ResidenceManagement.Domain.Entities.Managements
{
    public class UserResidence : EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ResidenceId { get; set; }
        public Residence Residence { get; set; }
        public int ResidentTypeId { get; set; }
        public ResidentType ResidentType { get; set; }
        public IEnumerable<ResidenceInvoice> ResidenceInvoices { get; set; }
        public IEnumerable<ResidenceDues> ResidenceDuesses { get; set; }


    }


}
