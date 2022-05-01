using AutoMapper;
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

namespace ResidenceManagement.Application.Features.Commands.Messages.DeleteMessage
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, BaseResponse>
    {
        private readonly IMapper _mapper;

        private readonly IMessageRepository _messageRepository;
        public DeleteMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
        }

        public async Task<BaseResponse> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var deleteItem =await _messageRepository.GetAsync(r=>r.Id == request.MessageId && r.ReceiverId == request.UserId);
            if (deleteItem == null)
                throw new NotFoundException(request);

            await _messageRepository.RemoveAsync(deleteItem);
            return new BaseResponse(true,"Mesaj silindi");
        }
    }
}
