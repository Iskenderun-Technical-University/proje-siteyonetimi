using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Models.ResidenceInvoices
{
    public class ResidenceInvoiceDto
    {
        public int Id { get; set; }
        public int InvoiceYear { get; set; }
        public int InvoiceMonth { get; set; }
        public int UserResidenceResidenceBlock { get; set; }
        public int UserResidenceResidenceFloor { get; set; }
        public int UserResidenceResidenceDoorNumber { get; set; }
        public string UserResidenceUserFirstName { get; set; }
        public string UserResidenceUserLastName { get; set; }
        public int InvoiceFee { get; set; }
        public bool IsPaid { get; set; }
        public string UserResidenceResidentTypeType { get; set; }
    }
}
