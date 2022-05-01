using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.UserResidences.DeleteUserResidence
{
    public class DeleteUserResidenceCommand : IRequest<BaseResponse>
    {
        public int DeleteItemId { get; set; }

    }
}
