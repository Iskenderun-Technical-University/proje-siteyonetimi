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

namespace ResidenceManagement.Application.Features.Queries.ResidenceInvoices.GetResidenceInvoices
{
  
    public class GetResidenceInvoiceListQueryHandler : IRequestHandler<GetResidenceInvoiceListQuery, BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>>
    {
        private readonly IResidenceInvoiceRepository _residenceInvoiceRepository;
        private readonly IMapper _mapper;

        public GetResidenceInvoiceListQueryHandler(IResidenceInvoiceRepository residenceInvoiceRepository, IMapper mapper)
        {
            _residenceInvoiceRepository = residenceInvoiceRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>> Handle(GetResidenceInvoiceListQuery request, CancellationToken cancellationToken)
        {
            //var residenceInvoiceList =await _residenceInvoiceRepository.GetAllAsync(r => r.UserResidence.UserId == request.UserId);
            string[] includes = { "UserResidence", "Invoice", "UserResidence.User", "UserResidence.Residence", "UserResidence.ResidentType" };
            var residenceInvoiceList = await _residenceInvoiceRepository.GetAllAsync(includeStrings: includes);
            if (residenceInvoiceList.Count == 0)
                throw new NotFoundException(request);
            var returnList = _mapper.Map<IReadOnlyList<ResidenceInvoiceDto>>(residenceInvoiceList);
            return new BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>(true, returnList);
        }
    }
}
