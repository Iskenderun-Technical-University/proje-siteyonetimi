using MediatR;
using ResidenceManagement.Application.Models.PaymentControl;
using ResidenceManagement.Application.Responses;

using System.Collections.Generic;


namespace ResidenceManagement.Application.Features.Queries.Invoices.GetInvoices
{
    public class GetInvoiceListQuery : IRequest<BaseDataResponse<IReadOnlyList<PaymentDto>>>
    {
       
    }
}
