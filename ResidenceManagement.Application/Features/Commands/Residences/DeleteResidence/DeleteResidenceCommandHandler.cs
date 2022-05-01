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

namespace ResidenceManagement.Application.Features.Commands.Residences.DeleteResidence
{
    public class DeleteResidenceCommandHandler : IRequestHandler<DeleteResidenceCommand, DeleteResidenceResponse>
    {
        private IResidenceRepository _residenceRepository;
        private IMapper _mapper;

        public DeleteResidenceCommandHandler(IResidenceRepository residenceRepository, IMapper mapper)
        {
            _residenceRepository = residenceRepository;
            _mapper = mapper;
        }

        public async Task<DeleteResidenceResponse> Handle(DeleteResidenceCommand request, CancellationToken cancellationToken)
        {
            var deleteItem = new Residence();
            deleteItem.Id = request.ResidenceId;
    

            return new DeleteResidenceResponse(_residenceRepository.RemoveAsync(deleteItem).IsCompletedSuccessfully?true:false);

        }
    }
}
