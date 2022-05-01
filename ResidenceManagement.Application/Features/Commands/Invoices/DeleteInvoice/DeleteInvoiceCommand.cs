using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Invoices.DeleteInvoice
{
    public class DeleteInvoiceCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
