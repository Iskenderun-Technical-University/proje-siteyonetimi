using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.AddResidenceRange
{
    public class AddResidenceRangeCommandHandler : IRequestHandler<AddResidenceRangeCommand, AddResidenceRangeResponse>
    {
        private readonly IResidenceRepository _residenceRepository;
        private readonly IMapper _mapper;

        public AddResidenceRangeCommandHandler(IResidenceRepository residenceRepository, IMapper mapper)
        {
            _residenceRepository = residenceRepository;
            _mapper = mapper;
        }


        public async Task<AddResidenceRangeResponse> Handle(AddResidenceRangeCommand request, CancellationToken cancellationToken)
        {
            int maxDoorNumber = (request.FloorPerBlock * request.HousePerBlock);
            int maxBlock = request.BlockNumber;
            int maxFloor = request.FloorPerBlock;

            var startedNumber = 1;
            var n = await _residenceRepository.GetAllAsync();
            int currentFoor = 1;
            if (n.Count != 0)
                startedNumber = n.Select(u => u.Block).Max() + 1;

            for (int i = 1; i <= maxBlock; i++)
            {
                for (int j = 1; j <= maxDoorNumber;)
                {
                    for (int k = 1; k <= request.HousePerBlock; k++)
                    {
                        var res = new Residence();
                        res.Block = startedNumber;
                        res.Floor = currentFoor;
                        res.DoorNumber = j;
                        res.ResidenceTypeId = request.ResidenceTypeId;
                        await _residenceRepository.AddAsync(res);
                        j++;

                    }
                    currentFoor++;
                }
                currentFoor = 1;
                startedNumber++;

            }
            return new AddResidenceRangeResponse(true);
        }


    }
}
