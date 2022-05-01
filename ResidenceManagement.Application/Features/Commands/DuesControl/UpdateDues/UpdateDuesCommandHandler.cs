using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.DuesControl.UpdateDues
{
    public class UpdateDuesCommandHandler : IRequestHandler<UpdateDuesCommand, BaseDataResponse<Dues>>
    {
        private readonly IDuesRepository _duesRepository;

        public UpdateDuesCommandHandler(IDuesRepository duesRepository)
        {
            _duesRepository = duesRepository;
        }

        public async Task<BaseDataResponse<Dues>> Handle(UpdateDuesCommand request, CancellationToken cancellationToken)
        {
            var checkDues = await _duesRepository.GetByIdAsync(request.Id);
            if (checkDues == null)
                throw new NotFoundException(request);
            checkDues.Fee = request.Fee;

            await _duesRepository.UpdateAsync(checkDues);
            return new BaseDataResponse<Dues>(true, checkDues);
        }
    }
}
