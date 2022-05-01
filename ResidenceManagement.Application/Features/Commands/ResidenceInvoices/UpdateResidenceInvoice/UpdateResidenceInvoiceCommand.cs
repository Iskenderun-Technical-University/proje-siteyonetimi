using MediatR;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceInvoices.UpdateResidenceInvoice
{
    public class UpdateResidenceInvoiceCommand : IRequest<BaseDataResponse<ResidenceInvoice>>
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
    }
}
