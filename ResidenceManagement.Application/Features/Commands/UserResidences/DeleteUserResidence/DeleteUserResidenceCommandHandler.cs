using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.UserResidences.DeleteUserResidence
{
    public class DeleteUserResidenceCommandHandler : IRequestHandler<DeleteUserResidenceCommand, BaseResponse>
    {
        private readonly IUserResidenceRepository _userResidenceRepository;
        private readonly IMapper _mapper;

        public DeleteUserResidenceCommandHandler(IUserResidenceRepository userResidenceRepository, IMapper mapper)
        {
            _userResidenceRepository = userResidenceRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(DeleteUserResidenceCommand request, CancellationToken cancellationToken)
        {
            var delelteItem =await _userResidenceRepository.GetByIdAsync(request.DeleteItemId);
            if (delelteItem == null)
                throw new NotFoundException(request);
            await _userResidenceRepository.RemoveAsync(delelteItem);
            return new BaseResponse(true);
        }
    }
}
