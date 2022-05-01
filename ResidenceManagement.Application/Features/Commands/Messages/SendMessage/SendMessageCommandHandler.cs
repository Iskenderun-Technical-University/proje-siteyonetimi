using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, BaseDataResponse<Message>>
    {
        private IMapper _mapper;
        private IMessageRepository _messageRepository;

        public SendMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<Message>> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var sendingMessage = _mapper.Map<Message>(request);

            await _messageRepository.AddAsync(sendingMessage);
            return new BaseDataResponse<Message>(true, sendingMessage);
        }
    }
}
