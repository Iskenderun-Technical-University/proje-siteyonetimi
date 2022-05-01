using MediatR;
using ResidenceManagement.Application.Models.PaymentControl;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.DuesController.GetDues
{
    public class GetDuesListQuery : IRequest<BaseDataResponse<IReadOnlyList<PaymentDto>>>
    {
    }
}
