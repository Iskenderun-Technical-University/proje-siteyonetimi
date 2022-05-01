using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.PaymentControl;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.DuesController.GetDues
{
    public class GetDuesListQueryHandler : IRequestHandler<GetDuesListQuery, BaseDataResponse<IReadOnlyList<PaymentDto>>>
    {
        private readonly IDuesRepository _duesRepository;
        private readonly IMapper _mapper;

        public GetDuesListQueryHandler(IDuesRepository duesRepository, IMapper mapper)
        {
            _duesRepository = duesRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<IReadOnlyList<PaymentDto>>> Handle(GetDuesListQuery request, CancellationToken cancellationToken)
        {
            var duesList = await _duesRepository.GetAllAsync();
            if (duesList == null)
                throw new NotFoundException(request);
            var returnList = _mapper.Map<IReadOnlyList<PaymentDto>>(duesList);
            return new BaseDataResponse<IReadOnlyList<PaymentDto>>(true, returnList);
        }
    }
}
