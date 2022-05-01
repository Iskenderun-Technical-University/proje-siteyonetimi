using MediatR;
using ResidenceManagement.Application.Responses;

namespace ResidenceManagement.Application.Features.Commands.Invoices.AddInvoiceRange
{
    public class AddInvoiceRangeCommand : IRequest<BaseResponse>
    {
        public int Fee { get; set; }
        public int Year { get; set; }
    }
}
