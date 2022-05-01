using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.DuesControl.DeleteDues
{
    public class DeleteDuesCommandHandler : IRequestHandler<DeleteDuesCommand, BaseResponse>
    {
        private readonly IDuesRepository _duesRepository;

        public DeleteDuesCommandHandler(IDuesRepository duesRepository)
        {
            _duesRepository = duesRepository;
        }

        public async Task<BaseResponse> Handle(DeleteDuesCommand request, CancellationToken cancellationToken)
        {
            var checkDues = await _duesRepository.GetByIdAsync(request.Id);
            if (checkDues == null)
                throw new NotFoundException(request);
            await _duesRepository.RemoveAsync(checkDues);
            return new BaseResponse(true);
        }
    }
}
