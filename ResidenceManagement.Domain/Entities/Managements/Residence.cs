using ResidenceManagement.Domain.Commons;
using System.Collections.Generic;

namespace ResidenceManagement.Domain.Entities.Managements
{
    public class Residence : EntityBase
    {
        public int Block { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public bool IsFull { get; set; }
        public int ResidenceTypeId { get; set; }
        public ResidenceType ResidenceType { get; set; }
        public IEnumerable<UserResidence> UserResidences { get; set; }
    }

    
}
