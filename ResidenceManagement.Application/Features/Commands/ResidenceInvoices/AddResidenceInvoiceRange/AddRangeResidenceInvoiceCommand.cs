using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceInvoices.AddResidenceInvoiceRange
{
    public class AddRangeResidenceInvoiceCommand : IRequest<BaseResponse>
    {
        public int Year { get; set; }
    }
}
