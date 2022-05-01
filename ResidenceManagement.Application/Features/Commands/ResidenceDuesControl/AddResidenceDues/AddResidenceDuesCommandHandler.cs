using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.AddResidenceDues
{
    public class AddResidenceDuesCommandHandler : IRequestHandler<AddResidenceDuesCommand, BaseResponse>
    {
        private readonly IResidenceDuesRepository _residenceDuesRepository;
        private readonly IMapper _mapper;

        public AddResidenceDuesCommandHandler(IResidenceDuesRepository residenceDuesRepository, IMapper mapper)
        {
            _residenceDuesRepository = residenceDuesRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddResidenceDuesCommand request, CancellationToken cancellationToken)
        {
            var check =await _residenceDuesRepository.GetAsync(r=>r.DuesId == request.DuesId && r.UserResidenceId == request.UserResidenceId);
            if (check != null)
                throw new NotEmptyException(request.DuesId.ToString());
            await _residenceDuesRepository.AddAsync(_mapper.Map<ResidenceDues>(request));
            return new BaseResponse(true, "Ekleme işlemi başarılı");
        }
    }
}
