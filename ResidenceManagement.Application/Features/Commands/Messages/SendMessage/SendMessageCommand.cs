using MediatR;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageCommand : IRequest<BaseDataResponse<Message>>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
