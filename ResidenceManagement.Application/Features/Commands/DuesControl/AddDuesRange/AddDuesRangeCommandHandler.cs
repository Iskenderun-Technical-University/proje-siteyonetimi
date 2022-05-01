using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.DuesControl.AddDuesRange
{
    public class AddDuesRangeCommandHandler : IRequestHandler<AddDuesRangeCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDuesRepository _duesRepository;

        public AddDuesRangeCommandHandler(IMapper mapper, IDuesRepository duesRepository)
        {
            _mapper = mapper;
            _duesRepository = duesRepository;
        }

        public async Task<BaseResponse> Handle(AddDuesRangeCommand request, CancellationToken cancellationToken)
        {
            var checkDues = await _duesRepository.GetAsync(r => r.Year == request.Year);

            if (checkDues != null)
                throw new NotEmptyException(checkDues.Year.ToString());


            for (int addMonth = 1; addMonth <= 12; addMonth++)
            {
                await _duesRepository.AddAsync(new Dues() { Fee = request.Fee, Year = request.Year, Month = addMonth });
            }

            return new BaseResponse(true);
        }
    }
}
