using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.DeleteResidenceDues
{
    public class DeleteResidenceDuesCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
