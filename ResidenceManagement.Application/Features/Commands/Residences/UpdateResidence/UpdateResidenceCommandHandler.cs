using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.CustomExceptions;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.UpdateResidence
{
    public class UpdateResidenceCommandHandler : IRequestHandler<UpdateResidenceCommand, UpdateResidenceResponse>
    {
        private IResidenceRepository _residenceRepository;
        private IMapper _mapper;

        public UpdateResidenceCommandHandler(IResidenceRepository residenceRepository, IMapper mapper)
        {
            _residenceRepository = residenceRepository;
            _mapper = mapper;
        }

        public async Task<UpdateResidenceResponse> Handle(UpdateResidenceCommand request, CancellationToken cancellationToken)
        {
            
            var updateResidence =await _residenceRepository.GetByIdAsync(request.Id);
            if (updateResidence == null)
            {
                throw new NotFoundException(nameof(Residences), request.Id);
            }
            _mapper.Map(request, updateResidence, typeof(UpdateResidenceCommand), typeof(Residence));

            await _residenceRepository.UpdateAsync(updateResidence);
            return new UpdateResidenceResponse(true, updateResidence);
        }
    }
}
