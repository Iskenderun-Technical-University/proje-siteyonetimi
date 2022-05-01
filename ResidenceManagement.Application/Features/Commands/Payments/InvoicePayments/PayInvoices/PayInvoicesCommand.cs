using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Payments.InvoicePayments.PayInvoices
{
    public class PayInvoicesCommand : IRequest<BaseResponse>
    {
        public int ResidenceInvoiceId { get; set; }
        public int Fee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CardNumber { get; set; }

    }
}
