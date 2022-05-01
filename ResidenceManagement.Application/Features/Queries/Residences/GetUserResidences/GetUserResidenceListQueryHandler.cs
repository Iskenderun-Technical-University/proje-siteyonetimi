using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Models.UserResidences;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.Residences.GetUserResidences
{
    public class GetUserResidenceListQueryHandler : IRequestHandler<GetUserResidenceListQuery, IReadOnlyList<UserResidenceDto>>
    {
        private IUserResidenceRepository _userResidenceRepository;
        private IMapper _mapper;
       
        public List<Expression<Func<UserResidence, object>>> Includes { get; } = new List<Expression<Func<UserResidence, object>>>();
        public GetUserResidenceListQueryHandler(IUserResidenceRepository userResidenceRepository, IMapper mapper)
        {
            _userResidenceRepository = userResidenceRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<UserResidenceDto>> Handle(GetUserResidenceListQuery request, CancellationToken cancellationToken)
        {
            
            string[] includes = { "Residence" , "User", "Residence.ResidenceType", "ResidentType" };
            var list = await _userResidenceRepository.GetAllAsync(includeStrings:includes);
            return _mapper.Map<IReadOnlyList<UserResidenceDto>>(list);
        }
    }
}
