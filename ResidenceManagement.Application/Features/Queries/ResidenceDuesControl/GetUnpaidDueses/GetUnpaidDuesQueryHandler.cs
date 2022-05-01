using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.ResidenceDuesControl;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.ResidenceDuesControl.GetUnpaidDueses
{
    public class GetUnpaidDuesQueryHandler : IRequestHandler<GetUnpaidDuesQuery, BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>>
    {
        private readonly IResidenceDuesRepository _residenceDuesRepository;
        private readonly IMapper _mapper;

        public GetUnpaidDuesQueryHandler(IResidenceDuesRepository residenceDuesRepository, IMapper mapper)
        {
            _residenceDuesRepository = residenceDuesRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>> Handle(GetUnpaidDuesQuery request, CancellationToken cancellationToken)
        {
            string[] includes = { "UserResidence", "Dues", "UserResidence.Residence", "UserResidence.User", "UserResidence.ResidentType" };
            var residenceDuesList = await _residenceDuesRepository.GetAllAsync(r => r.IsPaid == false, includeStrings: includes);

            if (residenceDuesList.Count == 0)
                throw new NotFoundException(request);
            var returnList = _mapper.Map<IReadOnlyList<ResidenceDuesDto>>(residenceDuesList);
            return new BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>(true, returnList);
        }
    }
}
