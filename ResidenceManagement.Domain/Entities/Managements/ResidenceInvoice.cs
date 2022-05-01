using ResidenceManagement.Domain.Commons;

namespace ResidenceManagement.Domain.Entities.Managements
{
    public class ResidenceInvoice : EntityBase
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int UserResidenceId { get; set; }
        public UserResidence UserResidence { get; set; }
        public bool IsPaid { get; set; }

    }
}
