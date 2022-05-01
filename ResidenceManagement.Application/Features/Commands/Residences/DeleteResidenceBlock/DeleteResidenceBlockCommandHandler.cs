using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.DeleteResidenceBlock
{
    public class DeleteResidenceBlockCommandHandler : IRequestHandler<DeleteResidenceBlockCommand,DeleteResidenceBlockResponse>
    {
        private IResidenceRepository _residenceRepository;
        private IMapper _mapper;

        public DeleteResidenceBlockCommandHandler(IResidenceRepository residenceRepository, IMapper mapper)
        {
            _residenceRepository = residenceRepository;
            _mapper = mapper;
        }

        public async Task<DeleteResidenceBlockResponse> Handle(DeleteResidenceBlockCommand request, CancellationToken cancellationToken)
        {
            var ifExistBlock =await _residenceRepository.GetAllAsync(b=>b.Block == request.BlockNumber);
            await _residenceRepository.RemoveRangeAsync(ifExistBlock);

            return new DeleteResidenceBlockResponse(ifExistBlock.Count==0?false:true);
        }
    }
}
