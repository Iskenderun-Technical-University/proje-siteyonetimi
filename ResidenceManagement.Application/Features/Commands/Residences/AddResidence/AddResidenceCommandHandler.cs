using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.Residences;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.AddResidence
{
    public class AddResidenceCommandHandler : IRequestHandler<AddResidenceCommand, AddResidenceResponse>
    {
        private IResidenceRepository _residenceRepository;
        private IMapper _mapper;

        public AddResidenceCommandHandler(IResidenceRepository residenceRepository, IMapper mapper)
        {
            _residenceRepository = residenceRepository;
            _mapper = mapper;
        }

        public async Task<AddResidenceResponse> Handle(AddResidenceCommand request, CancellationToken cancellationToken)
        {
            var isEx = await _residenceRepository.GetAsync(res=>res.Block == request.Block && res.Floor == request.Floor && res.DoorNumber == request.DoorNumber);


            if (isEx != null)
                return new AddResidenceResponse(false);
           
            var entity = _mapper.Map<Residence>(request);
            await _residenceRepository.AddAsync(entity);
            
            return new AddResidenceResponse(status:true,residence:entity);
        }
    }
}
