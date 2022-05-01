using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.UpdateResidenceDues
{
    public class UpdateResidenceDuesCommandHandler : IRequestHandler<UpdateResidenceDuesCommand, BaseDataResponse<ResidenceDues>>
    {
        private readonly IResidenceDuesRepository _residenceDuesRepository;
        private readonly IMapper _mapper;

        public UpdateResidenceDuesCommandHandler(IResidenceDuesRepository residenceDuesRepository, IMapper mapper)
        {
            _residenceDuesRepository = residenceDuesRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<ResidenceDues>> Handle(UpdateResidenceDuesCommand request, CancellationToken cancellationToken)
        {
            var checkDues = await _residenceDuesRepository.GetByIdAsync(request.Id);
            if (checkDues == null)
                throw new NotFoundException(request);
            
            _mapper.Map(request, checkDues, typeof(UpdateResidenceDuesCommand), typeof(ResidenceDues));
            await _residenceDuesRepository.UpdateAsync(checkDues);
            return new BaseDataResponse<ResidenceDues>(true, checkDues);
        }
    }
}
