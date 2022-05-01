using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.DuesControl.AddDuesRange
{
    public class AddDuesRangeCommand : IRequest<BaseResponse>
    {
        public int Fee { get; set; }
        public int Year { get; set; }
    }
}
