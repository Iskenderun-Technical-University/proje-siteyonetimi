using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.ResidenceInvoices;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.ResidenceInvoices.GetResidenceInvoicesByUser
{
    public class GetResidenceInvoiceByUserQueryHandler : IRequestHandler<GetResidenceInvoiceByUserQuery, BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>>
    {
        private readonly IResidenceInvoiceRepository _residenceInvoiceRepository;
        private readonly IMapper _mapper;
        public GetResidenceInvoiceByUserQueryHandler(IResidenceInvoiceRepository residenceInvoiceRepository, IMapper mapper)
        {
            _residenceInvoiceRepository = residenceInvoiceRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>> Handle(GetResidenceInvoiceByUserQuery request, CancellationToken cancellationToken)
        {
            string[] includes = { "UserResidence","Invoice", "UserResidence.Residence", "UserResidence.User", "UserResidence.ResidentType" };
            var id = request.UserId;
            var residenceInvoiceList = await _residenceInvoiceRepository.GetAllAsync(r => r.UserResidence.UserId == request.UserId, includeStrings: includes); 
            
            if (residenceInvoiceList.Count == 0)
                throw new NotFoundException(request);
            var returnList = _mapper.Map<IReadOnlyList<ResidenceInvoiceDto>>(residenceInvoiceList);
            return new BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>(true, returnList);
        }
    }
}
