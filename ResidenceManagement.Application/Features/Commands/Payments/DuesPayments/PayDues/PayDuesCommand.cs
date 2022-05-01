using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Payments.DuesPayments.PayDues
{
    public class PayDuesCommand : IRequest<BaseResponse>
    {
        public int ResidenceDuesId { get; set; }
        public int Fee { get; set; }
    }
}
