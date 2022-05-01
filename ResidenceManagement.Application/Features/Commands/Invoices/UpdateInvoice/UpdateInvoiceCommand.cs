using MediatR;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;

namespace ResidenceManagement.Application.Features.Commands.Invoices.UpdateInvoice
{
    public class UpdateInvoiceCommand : IRequest<BaseDataResponse<Invoice>>
    {
        public int Id { get; set; }
        public int Fee { get; set; }
    }
}
