using MediatR;
using ResidenceManagement.Application.Models.PaymentControl;
using ResidenceManagement.Application.Responses;

namespace ResidenceManagement.Application.Features.Commands.Invoices.AddInvoice
{
    public class AddInvoiceCommand : PaymentDto, IRequest<BaseDataResponse<PaymentDto>>
    {
     
    }
}
