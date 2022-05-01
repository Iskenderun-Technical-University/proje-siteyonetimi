using MediatR;
using ResidenceManagement.Application.Responses;

namespace ResidenceManagement.Application.Features.Commands.ResidenceInvoices.AddResidenceInvoice
{
    public class AddResidenceInvoiceCommand : IRequest<BaseResponse>
    {
        public int InvoiceId { get; set; }
        public int UserResidenceId { get; set; }
    }
}
