using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Features.Queries.ResidenceDues.GetResidenceDuessByUser;
using ResidenceManagement.Application.Features.Queries.ResidenceInvoices.GetResidenceInvoicesByUser;
using ResidenceManagement.Application.Models.ResidenceDuesControl;
using ResidenceManagement.Application.Models.ResidenceInvoices;
using ResidenceManagement.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.ResidenceInvoice.GetResidenceDuesByUser
{
    public class GetResidenceDuesByUserQueryHandler : IRequestHandler<GetResidenceDuesByUserQuery, BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>>
    {
        private readonly IResidenceDuesRepository _residenceDuesRepository;
        private readonly IMapper _mapper;
        public GetResidenceDuesByUserQueryHandler(IResidenceDuesRepository residenceDuesRepository, IMapper mapper)
        {
            _residenceDuesRepository = residenceDuesRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>> Handle(GetResidenceDuesByUserQuery request, CancellationToken cancellationToken)
        {
            string[] includes = { "UserResidence", "Dues", "UserResidence.Residence", "UserResidence.User", "UserResidence.ResidentType" };
            var id = request.UserId;
            var residenceDuesList = await _residenceDuesRepository.GetAllAsync(r => r.UserResidence.UserId == request.UserId, includeStrings: includes);

            if (residenceDuesList.Count == 0)
                throw new NotFoundException(request);
            var returnList = _mapper.Map<IReadOnlyList<ResidenceDuesDto>>(residenceDuesList);
            return new BaseDataResponse<IReadOnlyList<ResidenceDuesDto>>(true, returnList);
        }
    }
}
