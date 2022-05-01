using MediatR;
using ResidenceManagement.Application.Models.ResidenceInvoices;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.ResidenceInvoices.GetResidenceInvoicesByUser
{
    public class GetResidenceInvoiceByUserQuery : IRequest<BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>>
    {
        public int UserId { get; set; }

    }
}
