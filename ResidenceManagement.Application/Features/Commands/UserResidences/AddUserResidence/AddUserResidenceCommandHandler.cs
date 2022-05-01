using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.UserResidences;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.UserResidences.AddUserResidence
{
    public class AddUserResidenceCommandHandler : IRequestHandler<AddUserResidenceCommand, AddUserResidenceResponse>
    {
        private readonly IUserResidenceRepository _userResidenceRepository;
        private readonly IResidenceRepository _residenceRepository;
        private readonly IMapper _mapper;

        public AddUserResidenceCommandHandler(IUserResidenceRepository userResidenceRepository, IMapper mapper, IResidenceRepository residenceRepository)
        {
            _userResidenceRepository = userResidenceRepository;
            _mapper = mapper;
            _residenceRepository = residenceRepository;
        }

        public async Task<AddUserResidenceResponse> Handle(AddUserResidenceCommand request, CancellationToken cancellationToken)
        {
            var isExist =  await _residenceRepository.GetAsync(u=>u.Id == request.ResidenceId);
            if (isExist.IsFull == true)
                throw new NotEmptyException("Dolu daire.");

            var entity = _mapper.Map<UserResidence>(request);
            await _userResidenceRepository.AddAsync(entity);

            isExist.IsFull = true;
            await _residenceRepository.UpdateAsync(isExist);
            return new AddUserResidenceResponse(true);

        }
    }
}
