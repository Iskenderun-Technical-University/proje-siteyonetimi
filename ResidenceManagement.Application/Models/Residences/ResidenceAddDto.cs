using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Models.Residences
{
    public class ResidenceAddDto
    {
        public int Block { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public bool IsFull { get; set; }
        public int ResidenceTypeId { get; set; }
      
    }
}
