using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.AddResidenceDuesRange
{
    public class AddRangeResidenceDuesCommand : IRequest<BaseResponse>
    {
        public int Year { get; set; }
    }
}
