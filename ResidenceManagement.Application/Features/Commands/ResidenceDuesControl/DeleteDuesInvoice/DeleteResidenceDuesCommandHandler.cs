using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.DeleteResidenceDues
{
    public class DeleteResidenceDuesCommandHandler : IRequestHandler<DeleteResidenceDuesCommand, BaseResponse>
    {
        private IResidenceDuesRepository _residenceDuesRepository;

        public DeleteResidenceDuesCommandHandler(IResidenceDuesRepository residenceDuesRepository)
        {
            _residenceDuesRepository = residenceDuesRepository;
        }

        public async Task<BaseResponse> Handle(DeleteResidenceDuesCommand request, CancellationToken cancellationToken)
        {
            var checkResidenceDues = await _residenceDuesRepository.GetByIdAsync(request.Id);
            if (checkResidenceDues == null)
                throw new NotFoundException(request);
            await _residenceDuesRepository.RemoveAsync(checkResidenceDues);
            return new BaseResponse(true);
        }
    }
}
