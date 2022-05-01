using MediatR;
using ResidenceManagement.Application.Models.Messages;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.Messages.GetMessages
{
    public class GetMessageQuery : IRequest<BaseDataResponse<GetMessageListDto>>
    {
        public int UserId { get; set; }
    }
}
