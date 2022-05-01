using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.UserResidences;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.UserResidences.UpateUserResidence
{
    public class UpdateUserResidenceCommandHandler : IRequestHandler<UpdateUserResidenceCommand, BaseDataResponse<UpdateUserResidenceDto>>
    {
        private IUserResidenceRepository _userResidenceRepository;
        private readonly IMapper _mapper;

        public UpdateUserResidenceCommandHandler(IUserResidenceRepository userResidenceRepository, IMapper mapper)
        {
            _userResidenceRepository = userResidenceRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<UpdateUserResidenceDto>> Handle(UpdateUserResidenceCommand request, CancellationToken cancellationToken)
        {
            var updateUserResidence = await _userResidenceRepository.GetByIdAsync(request.Id);

            if (updateUserResidence == null)
            {
                throw new NotFoundException(nameof(UserResidence), request.Id);
            }
            var checkExist = await _userResidenceRepository.GetAsync(r=>r.ResidenceId == request.ResidenceId);
            if (checkExist != null)
                throw new NotEmptyException(request.Id.ToString());

            _mapper.Map(request, updateUserResidence, typeof(UpdateUserResidenceCommand), typeof(UserResidence));

            await _userResidenceRepository.UpdateAsync(updateUserResidence);
            //var returnResidence = _mapper.Map<UpdateUserResidenceDto>(updateUserResidence);
            return new BaseDataResponse<UpdateUserResidenceDto>(true, request);
        }
    }
}
