using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.UserResidences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.UserResidences.GetUserResidenceByResident
{
    public class GetResidenceByResidentQueryHandler : IRequestHandler<GetResidenceByResidentQuery, List<UserResidenceDto>>
    {
        private readonly IUserResidenceRepository _userResidenceRepository;
        private readonly IMapper _mapper;

        public GetResidenceByResidentQueryHandler(IUserResidenceRepository userResidenceRepository, IMapper mapper)
        {
            _userResidenceRepository = userResidenceRepository;
            _mapper = mapper;
        }

        public async Task<List<UserResidenceDto>> Handle(GetResidenceByResidentQuery request, CancellationToken cancellationToken)
        {
            string[] includes = { "Residence", "ResidentType", "User", "Residence.ResidenceType" };
            var id = request.UserId;
            var residenceDetail = await _userResidenceRepository.GetAllAsync(u => u.UserId == id,includeStrings:includes);
            if (residenceDetail == null || residenceDetail.Count == 0)
                throw new NotFoundException("Dairesi yok",id);
           
            return _mapper.Map<List<UserResidenceDto>>(residenceDetail);
        }
    }
}
