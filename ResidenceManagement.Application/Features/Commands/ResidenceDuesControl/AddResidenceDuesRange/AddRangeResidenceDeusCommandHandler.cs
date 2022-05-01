using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.AddResidenceDuesRange
{
    public class AddRangeResidenceDeusCommandHandler : IRequestHandler<AddRangeResidenceDuesCommand, BaseResponse>
    {
        private readonly IResidenceDuesRepository _residenceDuesRepository;
        private readonly IDuesRepository _duesRepository;
        private readonly IUserResidenceRepository _userResidenceRepository;

        public AddRangeResidenceDeusCommandHandler(IResidenceDuesRepository residenceDuesRepository, IDuesRepository duesRepository, IMapper mapper, IResidenceRepository residenceRepository, IUserResidenceRepository userResidenceRepository)
        {
            _residenceDuesRepository = residenceDuesRepository;
            _duesRepository = duesRepository;
            _userResidenceRepository = userResidenceRepository;
        }

        public async Task<BaseResponse> Handle(AddRangeResidenceDuesCommand request, CancellationToken cancellationToken)
        {

            var residenceInvoce = await _residenceDuesRepository.GetAllAsync(r => r.Dues.Year == request.Year);
            if (residenceInvoce.Count != 0)
                throw new NotEmptyException("Toplu aidat girilemez. Aidat bilgisi ekli.");

            var duesList =await _duesRepository.GetAllAsync(p=>p.Year == request.Year);
            if (duesList == null)
                throw new NotFoundException(request);

            var residenceList = await _userResidenceRepository.GetAllAsync(p => p.Residence.IsFull);
            if (residenceList == null)
                throw new NotEmptyException("Boş daire yok.");
            
            foreach(var residence in residenceList)
            {
                foreach (var dues in duesList)
                {
                    var addResidenceDues = new ResidenceDues();
                    addResidenceDues.UserResidenceId = residence.ResidenceId;
                    addResidenceDues.DuesId = dues.Id;
                    await _residenceDuesRepository.AddAsync(addResidenceDues);
                }
                 
            }

            return new BaseResponse(true);

        }
    }
}
