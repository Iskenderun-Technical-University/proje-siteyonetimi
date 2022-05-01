using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Models.Residences;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.Residences.GetResidences
{
    public class GetResidenceListQueryHandler : IRequestHandler<GetResidenceListQuery, IReadOnlyList<ResidenceDto>>
    {
        private IResidenceRepository _residenceRepository;
        private IMapper _mapper;

        public GetResidenceListQueryHandler(IResidenceRepository residenceRepository, IMapper mapper)
        {
            _residenceRepository = residenceRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ResidenceDto>> Handle(GetResidenceListQuery request, CancellationToken cancellationToken)
        {
            var result = await  _residenceRepository.GetAllAsync(includeString: "ResidenceType");
            
            return _mapper.Map<IReadOnlyList<ResidenceDto>>(result);
        }
    }
}
