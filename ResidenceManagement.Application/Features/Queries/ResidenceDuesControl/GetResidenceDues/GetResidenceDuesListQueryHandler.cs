using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Features.Queries.ResidenceDues.GetResidenceDues;
using ResidenceManagement.Application.Models.ResidenceDuesControl;
using ResidenceManagement.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.ResidenceDues.GetResidenceDuess
{
  
    public class GetResidenceDuesListQueryHandler : IRequestHandler<GetResidenceDuesListQuery, BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>>
    {
        private readonly IResidenceDuesRepository _residenceDuesRepository;
        private readonly IMapper _mapper;

        public GetResidenceDuesListQueryHandler(IResidenceDuesRepository residenceDuesRepository, IMapper mapper)
        {
            _residenceDuesRepository = residenceDuesRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>> Handle(GetResidenceDuesListQuery request, CancellationToken cancellationToken)
        {
            string[] includes = { "UserResidence", "Dues", "UserResidence.User", "UserResidence.Residence", "UserResidence.ResidentType" };
            var residenceDuesList = await _residenceDuesRepository.GetAllAsync(includeStrings: includes);
            if (residenceDuesList.Count == 0)
                throw new NotFoundException(request);
            var returnList = _mapper.Map<IReadOnlyList<ResidenceDuesDto>>(residenceDuesList);
            return new BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>(true, returnList);
        }
    }
}
