using MediatR;
using ResidenceManagement.Application.Models.ResidenceDuesControl;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.ResidenceDues.GetResidenceDuessByUser
{
    public class GetResidenceDuesByUserQuery : IRequest<BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>>
    {
        public int UserId { get; set; }

    }
}
