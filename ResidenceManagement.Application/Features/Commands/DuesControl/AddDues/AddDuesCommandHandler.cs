using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.PaymentControl;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.DuesControl.AddDues
{
    public class AddDuesCommandHandler : IRequestHandler<AddDuesCommand, BaseDataResponse<PaymentDto>>
    {
        private IDuesRepository _duesRepository;
        private readonly IMapper _mapper;

        public AddDuesCommandHandler(IDuesRepository duesRepository, IMapper mapper)
        {
            _duesRepository = duesRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<PaymentDto>> Handle(AddDuesCommand request, CancellationToken cancellationToken)
        {
            var checkDues = await _duesRepository.GetAsync(r => r.Year == request.Year && r.Month == request.Month);

            if (checkDues != null)
                throw new NotEmptyException(checkDues.Year.ToString() + " " + checkDues.Month.ToString());


            await _duesRepository.AddAsync(_mapper.Map<Dues>(request));

            return new BaseDataResponse<PaymentDto>(true, _mapper.Map<PaymentDto>(request)); ;
        }

    }
}
