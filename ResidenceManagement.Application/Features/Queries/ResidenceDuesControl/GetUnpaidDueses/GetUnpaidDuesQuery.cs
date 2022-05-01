using MediatR;
using ResidenceManagement.Application.Models.ResidenceDuesControl;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.ResidenceDuesControl.GetUnpaidDueses
{
    public class GetUnpaidDuesQuery : IRequest<BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>>
    {
    }
}
