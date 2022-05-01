using ResidenceManagement.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Domain.Entities.Managements
{
    public class Invoice : PaymentBase
    {
        public IEnumerable<ResidenceInvoice> ResidenceInvoices { get; set; }

    }
}
