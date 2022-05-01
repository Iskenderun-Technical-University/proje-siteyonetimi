﻿using MediatR;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Messages.CheckReadMessage
{
    public class CheckReadMessageCommand : IRequest<BaseResponse>
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
    }
}
