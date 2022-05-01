using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Models.Residences
{
    public class AddResidenceRange
    {
        public int BlockNumber { get; set; }
        public int FloorPerBlock { get; set; }
        public int HousePerBlock { get; set; }
    }
}
