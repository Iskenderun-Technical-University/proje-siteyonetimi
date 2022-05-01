using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Domain.Commons
{
    public class PaymentBase : EntityBase
    {
        public int Fee { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

    }
}
