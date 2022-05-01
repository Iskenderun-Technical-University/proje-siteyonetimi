using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Messages.CheckReadMessage
{
    public class CheckMessageCommandHandler : IRequestHandler<CheckReadMessageCommand, BaseResponse>
    {
        private readonly IMessageRepository _messageRepository;

        public CheckMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<BaseResponse> Handle(CheckReadMessageCommand request, CancellationToken cancellationToken)
        {
            var checkMessageItem = await _messageRepository.GetAsync(r=>r.Id == request.MessageId && r.ReceiverId == request.UserId);
            if (checkMessageItem == null)
                throw new NotFoundException(request);
            if (!checkMessageItem.IsRead)
            {
                checkMessageItem.IsRead = true;
                await _messageRepository.UpdateAsync(checkMessageItem);
                return new BaseResponse(true, "Mesaj okundu olarak işaretlendi.");

            }
            else
            {
                checkMessageItem.IsRead = false;
                await _messageRepository.UpdateAsync(checkMessageItem);
                return new BaseResponse(true, "Mesaj okunmadı olarak işaretlendi.");
            }

        }
    }
}
