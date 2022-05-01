using MediatR;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.UpdateResidenceDues
{
    public class UpdateResidenceDuesCommand : IRequest<BaseDataResponse<ResidenceDues>>
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
    }
}
