using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceInvoices.DeleteResidenceInvoice
{
    public class DeleteResidenceInvoiceCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
