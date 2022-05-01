using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Models.Messages;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.Messages.GetMessages
{
    public class GetMessageQueryHandler : IRequestHandler<GetMessageQuery, BaseDataResponse<GetMessageListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        protected string[] includes = { "Sender", "Receiver" };

        public GetMessageQueryHandler(IMapper mapper, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
        }

        public async Task<BaseDataResponse<GetMessageListDto>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            
            var currentMessages = new GetMessageListDto();
            var getSendMessageList =await _messageRepository.GetAllAsync(
                                        r => r.SenderId == request.UserId,includeStrings:includes);
            var getReceiveMessageList = await _messageRepository.GetAllAsync(r => 
                                        r.ReceiverId == request.UserId,includeStrings:includes);

            currentMessages.RecievingList = _mapper.Map<IReadOnlyList<MessageDto>>(getReceiveMessageList);
            currentMessages.SendingList = _mapper.Map<IReadOnlyList<MessageDto>>(getSendMessageList);

           
            return new BaseDataResponse<GetMessageListDto>(true,currentMessages);
        }
    }
}
